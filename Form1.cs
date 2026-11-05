using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using CmlLib.Core.Installers;
using CmlLib.Core.Installer.Forge;
using CmlLib.Core.Installer.NeoForge;
using CmlLib.Core.Installer.NeoForge.Installers;

namespace Minecraft_launcher
{
    public partial class Form1 : Form
    {
        private MinecraftLauncher _launcher;
        private HttpClient _httpClient;
        private CancellationTokenSource? _cts;
        private CmlLib.Core.VersionMetadata.VersionMetadataCollection? _cachedVersions;

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            // AlpsidMCL klasörünü merkez Minecraft dizini olarak kullan
            string alpsidMclDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AlpsidMCL");
            Directory.CreateDirectory(alpsidMclDir);
            _launcher = new MinecraftLauncher(new MinecraftPath(alpsidMclDir));

            // Uygulama ve form simgesini yükle
            LoadAppIconAndLogo();

            // Bind Form Load and button click events
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += (s, e) => SaveConfig();
            this.btnOyna.Click += new System.EventHandler(this.btnOyna_Click);

            // Alpsid Mods menüsü olayları
            InitializeModsMenuEvents();

            // Alpsid Ayarlar menüsü ve kısayol olayları
            InitializeSettingsEvents();
        }

        private void InitializeModsMenuEvents()
        {
            btnAlpsidMods.Click += (s, e) => ToggleModsMenu();
            btnCloseModsMenu.Click += (s, e) => CloseModsMenu();

            btnNavHome.Click += (s, e) => SetModsActiveTab("Home");
            btnNavMods.Click += (s, e) => SetModsActiveTab("Mods");
            btnNavResourcePacks.Click += (s, e) => SetModsActiveTab("ResourcePacks");
            btnNavShaders.Click += (s, e) => SetModsActiveTab("Shaders");

            btnCreateModpack.Click += (s, e) =>
            {
                MessageBox.Show(
                    "Yeni Mod Paketi Sihirbazı yakında aktif olacak!\n" +
                    "Buradan mod paketinizin adını, Minecraft sürümünü (Forge/NeoForge/Fabric) seçip tek tıkla profil oluşturabileceksiniz.",
                    "Yeni Mod Paketi Oluştur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            txtModSearch.TextChanged += (s, e) =>
            {
                string query = txtModSearch.Text.Trim();
                if (!string.IsNullOrEmpty(query))
                {
                    lblModsContentPlaceholder.Text = $"🔍 '{query}' için arama yapılıyor...\r\n\r\n(Mod ve paket listeleme entegrasyonu sonraki adımda yüklenecektir)";
                }
            };

            LoadRecentModpacks();
        }

        private void ToggleModsMenu()
        {
            if (pnlModsMenu.Visible)
            {
                CloseModsMenu();
            }
            else
            {
                OpenModsMenu();
            }
        }

        private void OpenModsMenu()
        {
            pnlMcNews.Visible = false;
            pnlLauncherNews.Visible = false;
            pnlSettingsMenu.Visible = false;
            btnSettings.BackColor = System.Drawing.Color.FromArgb(49, 50, 68);
            pnlModsMenu.Visible = true;
            pnlModsMenu.BringToFront();
            btnAlpsidMods.BackColor = System.Drawing.Color.FromArgb(137, 180, 250); // Mavi aktif vurgusu
        }

        private void CloseModsMenu()
        {
            pnlModsMenu.Visible = false;
            pnlMcNews.Visible = true;
            pnlLauncherNews.Visible = true;
            btnAlpsidMods.BackColor = System.Drawing.Color.FromArgb(203, 166, 247); // Orijinal lila rengi
        }

        private void InitializeSettingsEvents()
        {
            btnSettings.Click += (s, e) => ToggleSettingsMenu();
            btnCloseSettingsMenu.Click += (s, e) => CloseSettingsMenu();

            btnFolder.Click += (s, e) =>
            {
                try
                {
                    string alpsidDir = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "AlpsidMCL");
                    Directory.CreateDirectory(alpsidDir);
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = alpsidDir,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klasör açılırken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            chkResizableWindow.CheckedChanged += (s, e) =>
            {
                if (chkResizableWindow.Checked)
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.MaximizeBox = true;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.FixedDialog;
                    this.MaximizeBox = false;
                    this.Size = new System.Drawing.Size(956, 619);
                }
            };

            chkShowSnapshots.CheckedChanged += (s, e) => _ = ReloadVersionsWithFiltersAsync();
            chkShowBetas.CheckedChanged += (s, e) => _ = ReloadVersionsWithFiltersAsync();
            chkShowAlphas.CheckedChanged += (s, e) => _ = ReloadVersionsWithFiltersAsync();

            btnBackupNow.Click += async (s, e) =>
            {
                btnBackupNow.Enabled = false;
                btnBackupNow.Text = "⏳ Yedekleniyor...";
                try
                {
                    string resultPath = await Task.Run(() => PerformBackup());
                    if (!string.IsNullOrEmpty(resultPath))
                    {
                        MessageBox.Show($"Yedekleme başarıyla tamamlandı!\nKonum: {resultPath}", "Yedekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Yedeklenecek kayıt (saves) klasörü bulunamadı veya boş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yedekleme sırasında hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnBackupNow.Enabled = true;
                    btnBackupNow.Text = "💾 Şimdi Yedek Al";
                }
            };
        }

        private void ToggleSettingsMenu()
        {
            if (pnlSettingsMenu.Visible)
            {
                CloseSettingsMenu();
            }
            else
            {
                OpenSettingsMenu();
            }
        }

        private void OpenSettingsMenu()
        {
            pnlMcNews.Visible = false;
            pnlLauncherNews.Visible = false;
            pnlModsMenu.Visible = false;
            btnAlpsidMods.BackColor = System.Drawing.Color.FromArgb(203, 166, 247);
            pnlSettingsMenu.Visible = true;
            pnlSettingsMenu.BringToFront();
            btnSettings.BackColor = System.Drawing.Color.FromArgb(137, 180, 250);
        }

        private void CloseSettingsMenu()
        {
            pnlSettingsMenu.Visible = false;
            pnlMcNews.Visible = true;
            pnlLauncherNews.Visible = true;
            btnSettings.BackColor = System.Drawing.Color.FromArgb(49, 50, 68);
        }

        private void SetModsActiveTab(string tabName)
        {
            // Sekme buton renklerini güncelle
            var activeBg = System.Drawing.Color.FromArgb(49, 50, 68);
            var activeFg = System.Drawing.Color.FromArgb(245, 224, 220);
            var inactiveBg = System.Drawing.Color.FromArgb(30, 30, 46);
            var inactiveFg = System.Drawing.Color.FromArgb(166, 173, 200);

            btnNavHome.BackColor = (tabName == "Home") ? activeBg : inactiveBg;
            btnNavHome.ForeColor = (tabName == "Home") ? activeFg : inactiveFg;

            btnNavMods.BackColor = (tabName == "Mods") ? activeBg : inactiveBg;
            btnNavMods.ForeColor = (tabName == "Mods") ? activeFg : inactiveFg;

            btnNavResourcePacks.BackColor = (tabName == "ResourcePacks") ? activeBg : inactiveBg;
            btnNavResourcePacks.ForeColor = (tabName == "ResourcePacks") ? activeFg : inactiveFg;

            btnNavShaders.BackColor = (tabName == "Shaders") ? activeBg : inactiveBg;
            btnNavShaders.ForeColor = (tabName == "Shaders") ? activeFg : inactiveFg;

            switch (tabName)
            {
                case "Home":
                    lblModsContentPlaceholder.Text =
                        "📁 TÜM MOD PAKETLERİ (HOME)\r\n\r\n" +
                        "Henüz oluşturulmuş özel bir mod paketiniz bulunmuyor.\r\n" +
                        "Sol menüdeki '➕ Mod Paketi Oluştur' butonuna tıklayarak ilk mod paketinizi hazırlayabilirsiniz.\r\n\r\n" +
                        "💡 Burası kurulu mod paketlerinizi profil olarak yöneteceğiniz ve tek tıkla oynayabileceğiniz alandır.";
                    break;

                case "Mods":
                    lblModsContentPlaceholder.Text =
                        "🧩 MOD LİSTESİ\r\n\r\n" +
                        "Popüler ve güncel modlar burada listelenecektir.\r\n" +
                        "Yukarıdaki arama çubuğunu kullanarak dilediğiniz modu aratabilirsiniz.";
                    break;

                case "ResourcePacks":
                    lblModsContentPlaceholder.Text =
                        "🎨 RESOURCE PACKS (DOKU PAKETLERİ)\r\n\r\n" +
                        "Minecraft dünyanızı özelleştirecek doku paketleri burada yer alacaktır.\r\n" +
                        "Yukarıdaki arama çubuğunu kullanarak doku paketlerini aratabilirsiniz.";
                    break;

                case "Shaders":
                    lblModsContentPlaceholder.Text =
                        "✨ SHADERS (GÖLGELENDİRİCİLER)\r\n\r\n" +
                        "Gerçekçi gölgeler ve ışık efektleri sunan shader paketleri burada yer alacaktır.\r\n" +
                        "Yukarıdaki arama çubuğunu kullanarak sisteminize uygun shader paketlerini aratabilirsiniz.";
                    break;
            }
        }

        private void LoadRecentModpacks()
        {
            lstRecentModpacks.Items.Clear();
            // Yalnızca mod paketleri listelenir, vanilla sürüm konulmaz
            string alpsidDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AlpsidMCL");
            string modpacksDir = Path.Combine(alpsidDir, "modpacks");

            if (Directory.Exists(modpacksDir))
            {
                var dirs = Directory.GetDirectories(modpacksDir);
                foreach (var dir in dirs)
                {
                    string packName = Path.GetFileName(dir);
                    lstRecentModpacks.Items.Add($"📦 {packName}");
                    if (lstRecentModpacks.Items.Count >= 5) break;
                }
            }

            if (lstRecentModpacks.Items.Count == 0)
            {
                lstRecentModpacks.Items.Add("(Henüz mod paketi yok)");
            }
        }

        private void LoadAppIconAndLogo()
        {
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new System.Drawing.Icon(iconPath);
                }

                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.png");
                if (File.Exists(logoPath))
                {
                    picLogo.Image = System.Drawing.Image.FromFile(logoPath);
                }
            }
            catch { }
        }

        private const string LAUNCHER_VERSION = "1.0.8";

        private async void Form1_Load(object? sender, EventArgs e)
        {
            // Populate RAM Options
            cmbRam.Items.Add("1 GB");
            cmbRam.Items.Add("2 GB");
            cmbRam.Items.Add("3 GB");
            cmbRam.Items.Add("4 GB");
            cmbRam.Items.Add("6 GB");
            cmbRam.Items.Add("8 GB");
            cmbRam.SelectedIndex = 1; // Default to 2 GB

            // Arka planda güncelleme kontrolünü ve haberleri başlat
            _ = CheckForUpdatesAsync();
            _ = LoadNewsAsync();

            try
            {
                lblDurum.Text = "Minecraft sürümleri Mojang API'sinden çekiliyor...";
                progressBar1.Value = 10;

                // Load Minecraft versions
                _cachedVersions = await _launcher.GetAllVersionsAsync();
                
                // Kaydedilmiş ayarları yükle
                LoadConfig();

                PopulateVersionsDropdown();
                progressBar1.Value = 100;
            }
            catch
            {
                // İnternet hatası: Yerel yüklü sürümleri tespit et
                LoadLocalInstalledVersions();
                progressBar1.Value = 0;
            }
        }

        private void PopulateVersionsDropdown()
        {
            if (_cachedVersions == null) return;

            string? currentSelection = cmbSurumler.SelectedItem?.ToString();
            cmbSurumler.Items.Clear();

            bool showSnapshots = chkShowSnapshots.Checked;
            bool showBetas = chkShowBetas.Checked;
            bool showAlphas = chkShowAlphas.Checked;

            string? latestRelease = null;
            foreach (var version in _cachedVersions)
            {
                string type = version.Type?.ToLowerInvariant() ?? "";
                bool include = false;

                if (type == "release")
                {
                    include = true;
                    if (latestRelease == null)
                        latestRelease = version.Name;
                }
                else if (type == "snapshot" && showSnapshots)
                {
                    include = true;
                }
                else if ((type == "old_beta" || type.Contains("beta")) && showBetas)
                {
                    include = true;
                }
                else if ((type == "old_alpha" || type.Contains("alpha")) && showAlphas)
                {
                    include = true;
                }

                if (include)
                {
                    cmbSurumler.Items.Add(version.Name);
                }
            }

            if (cmbSurumler.Items.Count > 0)
            {
                if (!string.IsNullOrEmpty(currentSelection) && cmbSurumler.Items.Contains(currentSelection))
                {
                    cmbSurumler.SelectedItem = currentSelection;
                }
                else
                {
                    cmbSurumler.SelectedIndex = 0;
                }

                lblDurum.Text = "Sürümler yüklendi. Oyuna başlamak için Oyna butonuna basın.";
                lblMcNewsWarning.Visible = false;
                if (!string.IsNullOrEmpty(latestRelease))
                {
                    lblMcNewsTitle.Text = $"⚔️ MINECRAFT {latestRelease} YENİLİKLERİ";
                }
            }
            else
            {
                LoadLocalInstalledVersions();
            }
        }

        private async Task ReloadVersionsWithFiltersAsync()
        {
            if (_cachedVersions == null)
            {
                try
                {
                    _cachedVersions = await _launcher.GetAllVersionsAsync();
                }
                catch { }
            }

            PopulateVersionsDropdown();
        }

        private void LoadLocalInstalledVersions()
        {
            cmbSurumler.Items.Clear();
            string alpsidVersionsDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AlpsidMCL", "versions");

            var found = new System.Collections.Generic.HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (Directory.Exists(alpsidVersionsDir))
            {
                foreach (var dir in Directory.GetDirectories(alpsidVersionsDir))
                {
                    string name = Path.GetFileName(dir);
                    string jsonFile = Path.Combine(dir, $"{name}.json");
                    if (File.Exists(jsonFile))
                    {
                        found.Add(name);
                    }
                }
            }

            // Orijinal .minecraft dizinindeki yüklü sürümleri de alternatif olarak bul
            string vanillaVersionsDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                ".minecraft", "versions");

            if (Directory.Exists(vanillaVersionsDir))
            {
                foreach (var dir in Directory.GetDirectories(vanillaVersionsDir))
                {
                    string name = Path.GetFileName(dir);
                    string jsonFile = Path.Combine(dir, $"{name}.json");
                    if (File.Exists(jsonFile))
                    {
                        found.Add(name);
                    }
                }
            }

            foreach (var ver in found)
            {
                cmbSurumler.Items.Add(ver);
            }

            if (cmbSurumler.Items.Count > 0)
            {
                cmbSurumler.SelectedIndex = 0;
                lblDurum.Text = "Çevrimdışı mod: Yüklü yerel sürümler hazır.";
                lblMcNewsWarning.Visible = true;
                lblMcNewsWarning.Text = "⚠️ Çevrimdışı Mod (Yalnızca yüklü sürümler oynanabilir)";
            }
            else
            {
                lblDurum.Text = "Hata: Yüklü sürüm bulunamadı ve internet bağlantısı yok.";
                lblMcNewsWarning.Visible = true;
                lblMcNewsWarning.Text = "⚠️ Veri Alınamadı, İnternet Bağlantısı Yok";
            }

            LoadConfig();
        }

        private async Task LoadNewsAsync()
        {
            // 1. AlpsidMCL Duyuruları - GitHub Releases'den dinamik çek
            try
            {
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Add("User-Agent", "AlpsidMCL-News/1.0");
                http.Timeout = TimeSpan.FromSeconds(6);

                string apiUrl = "https://api.github.com/repos/Alpsid/AlpsidMCL/releases/latest";
                string json = await http.GetStringAsync(apiUrl);
                using var doc = System.Text.Json.JsonDocument.Parse(json);
                var root = doc.RootElement;

                string tagName = root.TryGetProperty("tag_name", out var t) ? t.GetString() ?? "" : "";
                string releaseName = root.TryGetProperty("name", out var n) ? n.GetString() ?? "" : "";
                string body = root.TryGetProperty("body", out var b) ? b.GetString() ?? "" : "";

                if (!string.IsNullOrWhiteSpace(tagName))
                {
                    string displayName = string.IsNullOrWhiteSpace(releaseName) ? tagName : releaseName;
                    if (displayName.Length > 28)
                    {
                        displayName = displayName.Substring(0, 25) + "...";
                    }
                    lblLauncherNewsTitle.Text = $"📢 {displayName}";

                    string cleanBody = string.IsNullOrWhiteSpace(body)
                        ? "• Otomatik Güncelleme desteği devrede.\r\n• İzole %appdata%\\AlpsidMCL dizini korundu.\r\n• Performans ve kararlılık iyileştirmeleri."
                        : body.Trim();

                    lblLauncherNewsBody.Text = $"🚀 En Son Sürüm: {tagName}\r\n\r\n{cleanBody}";
                    lblLauncherNewsWarning.Visible = false;
                }
                else
                {
                    lblLauncherNewsWarning.Visible = true;
                }
            }
            catch
            {
                lblLauncherNewsWarning.Visible = true;
                lblLauncherNewsWarning.Text = "⚠️ Veri Alınamadı, İnternet Bağlantısı Yok";
            }
        }

        private string GetConfigFilePath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AlpsidMCL",
                "launcher_config.json");
        }

        private void LoadConfig()
        {
            try
            {
                string configPath = GetConfigFilePath();
                if (!File.Exists(configPath)) return;

                string json = File.ReadAllText(configPath);
                using var doc = System.Text.Json.JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("Username", out var u) && !string.IsNullOrWhiteSpace(u.GetString()))
                {
                    txtKullaniciAdi.Text = u.GetString();
                }

                if (root.TryGetProperty("SelectedRam", out var r) && !string.IsNullOrWhiteSpace(r.GetString()))
                {
                    int index = cmbRam.Items.IndexOf(r.GetString());
                    if (index >= 0) cmbRam.SelectedIndex = index;
                }

                if (root.TryGetProperty("SelectedVersion", out var v) && !string.IsNullOrWhiteSpace(v.GetString()))
                {
                    int index = cmbSurumler.Items.IndexOf(v.GetString());
                    if (index >= 0) cmbSurumler.SelectedIndex = index;
                }

                if (root.TryGetProperty("ShowSnapshots", out var snap) && snap.ValueKind == System.Text.Json.JsonValueKind.True)
                    chkShowSnapshots.Checked = true;
                if (root.TryGetProperty("ShowBetas", out var beta) && beta.ValueKind == System.Text.Json.JsonValueKind.True)
                    chkShowBetas.Checked = true;
                if (root.TryGetProperty("ShowAlphas", out var alpha) && alpha.ValueKind == System.Text.Json.JsonValueKind.True)
                    chkShowAlphas.Checked = true;
                if (root.TryGetProperty("ResizableWindow", out var rw) && rw.ValueKind == System.Text.Json.JsonValueKind.True)
                    chkResizableWindow.Checked = true;
                if (root.TryGetProperty("EnableBackup", out var eb) && eb.ValueKind == System.Text.Json.JsonValueKind.True)
                    chkEnableBackup.Checked = true;

                if (root.TryGetProperty("MaxBackupSize", out var mbs) && !string.IsNullOrWhiteSpace(mbs.GetString()))
                {
                    int idx = cmbMaxBackupSize.Items.IndexOf(mbs.GetString());
                    if (idx >= 0) cmbMaxBackupSize.SelectedIndex = idx;
                }
                if (root.TryGetProperty("BackupRetention", out var ret) && !string.IsNullOrWhiteSpace(ret.GetString()))
                {
                    int idx = cmbBackupRetention.Items.IndexOf(ret.GetString());
                    if (idx >= 0) cmbBackupRetention.SelectedIndex = idx;
                }
                if (root.TryGetProperty("BackupFrequency", out var freq) && !string.IsNullOrWhiteSpace(freq.GetString()))
                {
                    int idx = cmbBackupFrequency.Items.IndexOf(freq.GetString());
                    if (idx >= 0) cmbBackupFrequency.SelectedIndex = idx;
                }
            }
            catch { }
        }

        private void SaveConfig()
        {
            try
            {
                string configPath = GetConfigFilePath();
                string? user = txtKullaniciAdi.Text.Trim();
                string? ram = cmbRam.SelectedItem?.ToString();
                string? ver = cmbSurumler.SelectedItem?.ToString();

                var configObj = new
                {
                    Username = user,
                    SelectedRam = ram,
                    SelectedVersion = ver,
                    ShowSnapshots = chkShowSnapshots.Checked,
                    ShowBetas = chkShowBetas.Checked,
                    ShowAlphas = chkShowAlphas.Checked,
                    ResizableWindow = chkResizableWindow.Checked,
                    EnableBackup = chkEnableBackup.Checked,
                    MaxBackupSize = cmbMaxBackupSize.SelectedItem?.ToString(),
                    BackupRetention = cmbBackupRetention.SelectedItem?.ToString(),
                    BackupFrequency = cmbBackupFrequency.SelectedItem?.ToString()
                };

                string json = System.Text.Json.JsonSerializer.Serialize(configObj, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, json);
            }
            catch { }
        }

        private async Task CheckForUpdatesAsync()
        {
            try
            {
                var (hasUpdate, newVersion, downloadUrl) = await Updater.CheckForUpdateAsync(LAUNCHER_VERSION);
                if (!hasUpdate) return;

                var result = MessageBox.Show(
                    $"AlpsidMCL için yeni bir güncelleme mevcut! (v{newVersion})\n" +
                    $"Mevcut Sürüm: v{LAUNCHER_VERSION}\n\n" +
                    "Şimdi güncellemek istiyor musunuz?",
                    "Güncelleme Bulundu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    lblDurum.Text = $"Yeni sürüm indiriliyor (v{newVersion})...";
                    btnOyna.Enabled = false;

                    var progress = new Progress<int>(pct =>
                    {
                        progressBar1.Value = Math.Max(0, Math.Min(100, pct));
                        lblDurum.Text = $"Güncelleme indiriliyor: %{pct}";
                    });

                    // Güncellenecek hedef: gerçekte çalışan EXE'nin tam yolu
                    // Environment.ProcessPath çalışan uygulamanın gerçek konumunu verir
                    string targetLauncherPath = Environment.ProcessPath 
                        ?? Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                            "AlpsidMCL", 
                            "MinecraftLauncher.exe");

                    await Updater.DownloadAndApplyUpdateAsync(downloadUrl, targetLauncherPath, progress);
                }
            }
            catch
            {
                // Güncelleme başarısız olsa bile oyunun oynanmasına engel olma
                lblDurum.Text = "Güncelleme denetlenemedi.";
            }
        }

        private async void btnOyna_Click(object? sender, EventArgs e)
        {
            string userName = txtKullaniciAdi.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Lütfen geçerli bir kullanıcı adı girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSurumler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir Minecraft sürümü seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedVersion = cmbSurumler.SelectedItem.ToString() ?? "1.20.1";
            
            // Kullanıcı ayarlarını hemen kaydet
            SaveConfig();

            // Calculate RAM
            int ramMb = 2048;
            if (cmbRam.SelectedItem != null)
            {
                string selectedRam = cmbRam.SelectedItem.ToString() ?? "2 GB";
                int gb = int.Parse(selectedRam.Replace("GB", "").Trim());
                ramMb = gb * 1024;
            }

            btnOyna.Enabled = false;
            _cts = new CancellationTokenSource();

            try
            {
                // Setup launch options (Direct to main menu, no server auto-connect)
                var launchOption = new MLaunchOption
                {
                    Session = MSession.CreateOfflineSession(userName),
                    MaximumRamMb = ramMb
                };

                string targetVersion = selectedVersion;

                var fileProgress = new Progress<InstallerProgressChangedEventArgs>(progress =>
                {
                    if (progress.TotalTasks > 0)
                    {
                        int pct = (int)((double)progress.ProgressedTasks / progress.TotalTasks * 100);
                        progressBar1.Value = Math.Max(0, Math.Min(100, pct));
                    }
                    lblDurum.Text = $"İndiriliyor: {progress.Name} ({progress.ProgressedTasks}/{progress.TotalTasks})";
                });

                // Step 1: Install or verify core vanilla version
                // Çevrimdışı modda eğer sürüm zaten yüklüyse ve internet yoksa kuruluma zorlama
                try
                {
                    lblDurum.Text = $"{selectedVersion} Vanilla sürümü kontrol ediliyor...";
                    progressBar1.Value = 20;

                    // Trigger Vanilla installation
                    await _launcher.InstallAsync(selectedVersion, fileProgress, new Progress<ByteProgress>(), _cts.Token);
                }
                catch (Exception ex)
                {
                    // İnternet yoksa ama sürüm yerel olarak mevcutsa oynamaya devam et
                    string alpsidVerDir = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "AlpsidMCL", "versions", selectedVersion);

                    string vanillaVerDir = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        ".minecraft", "versions", selectedVersion);

                    // Eğer sürüm .minecraft içinde varsa ve AlpsidMCL içinde yoksa kopyala
                    if (!Directory.Exists(alpsidVerDir) && Directory.Exists(vanillaVerDir))
                    {
                        CopyDirectory(vanillaVerDir, alpsidVerDir);
                    }

                    if (!Directory.Exists(alpsidVerDir))
                    {
                        throw new Exception($"'{selectedVersion}' sürümü bilgisayarınızda yüklü değil ve internet bağlantısı bulunamadı.\nDetay: {ex.Message}");
                    }
                    lblDurum.Text = $"{selectedVersion} yerel sürüm dosyaları kullanılıyor (Çevrimdışı)...";
                }

                // Step 2: Install Mod Loader if selected
                if (rdbForge.Checked)
                {
                    lblDurum.Text = $"{selectedVersion} için Forge yükleniyor...";
                    var forgeInstaller = new ForgeInstaller(_launcher);
                    var forgeOptions = new ForgeInstallOptions
                    {
                        SkipIfAlreadyInstalled = true,
                        FileProgress = fileProgress
                    };
                    
                    targetVersion = await forgeInstaller.Install(selectedVersion, forgeOptions);
                }
                else if (rdbNeoForge.Checked)
                {
                    lblDurum.Text = $"{selectedVersion} için NeoForge yükleniyor...";
                    var neoForgeInstaller = new NeoForgeInstaller(_launcher);
                    var neoForgeOptions = new NeoForgeInstallOptions
                    {
                        SkipIfAlreadyInstalled = true,
                        FileProgress = fileProgress
                    };

                    targetVersion = await neoForgeInstaller.Install(selectedVersion, neoForgeOptions);
                }

                // Step 3: Download & Extract Modpack (yalnızca Forge/NeoForge seçiliyse)
                if (rdbForge.Checked || rdbNeoForge.Checked)
                {
                    bool modpackSuccess = await DownloadAndExtractModpackAsync();
                    if (!modpackSuccess)
                    {
                        var dialogResult = MessageBox.Show(
                            "Mod paketi indirilemedi/kurulamadı. Oyunu yine de mod paketi olmadan başlatmak istiyor musunuz?",
                            "Mod Paketi Hatası",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.No)
                        {
                            lblDurum.Text = "İptal edildi.";
                            btnOyna.Enabled = true;
                            return;
                        }
                    }
                }

                // Step 4: Launch the game directly to Main Menu
                lblDurum.Text = "Oyun hazırlanıyor ve başlatılıyor...";
                progressBar1.Value = 90;

                var process = await _launcher.BuildProcessAsync(targetVersion, launchOption, _cts.Token);
                process.Start();

                lblDurum.Text = "Oyun başarıyla başlatıldı!";
                progressBar1.Value = 100;

                await Task.Delay(3000);
                Application.Exit();
            }
            catch (Exception ex)
            {
                lblDurum.Text = "Hata oluştu!";
                MessageBox.Show("Oyun başlatılırken hata oluştu:\n" + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnOyna.Enabled = true;
            }
        }

        private async Task<bool> DownloadAndExtractModpackAsync()
        {
            string url = "https://siteniz.com";
            string mcPath = _launcher.MinecraftPath.BasePath;
            string zipPath = Path.Combine(mcPath, "modpack_temp.zip");

            try
            {
                lblDurum.Text = "Mod paketi indiriliyor (siteniz.com)...";
                progressBar1.Value = 0;

                using (var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, _cts?.Token ?? CancellationToken.None))
                {
                    response.EnsureSuccessStatusCode();
                    long? totalBytes = response.Content.Headers.ContentLength;

                    using (var contentStream = await response.Content.ReadAsStreamAsync(_cts?.Token ?? CancellationToken.None))
                    using (var fileStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    {
                        var buffer = new byte[8192];
                        long totalRead = 0;
                        int read;

                        while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length, _cts?.Token ?? CancellationToken.None)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, read, _cts?.Token ?? CancellationToken.None);
                            totalRead += read;
                            if (totalBytes.HasValue && totalBytes.Value > 0)
                            {
                                int pct = (int)((double)totalRead / totalBytes.Value * 100);
                                progressBar1.Value = Math.Max(0, Math.Min(100, pct));
                            }
                        }
                    }
                }

                // Extract Zip
                lblDurum.Text = "Mod paketi ayıklanıyor...";
                progressBar1.Value = 50;

                await Task.Run(() =>
                {
                    ZipFile.ExtractToDirectory(zipPath, mcPath, true);
                });

                if (File.Exists(zipPath))
                {
                    File.Delete(zipPath);
                }

                return true;
            }
            catch (Exception)
            {
                try
                {
                    if (File.Exists(zipPath))
                    {
                        File.Delete(zipPath);
                    }
                }
                catch { }

                return false;
            }
        }

        private static void CopyDirectory(string sourceDir, string destinationDir)
        {
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists) return;

            Directory.CreateDirectory(destinationDir);

            foreach (var file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            foreach (var subDir in dir.GetDirectories())
            {
                string nextTargetSubDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, nextTargetSubDir);
            }
        }

        private string PerformBackup()
        {
            string alpsidDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AlpsidMCL");

            string savesDir = Path.Combine(alpsidDir, "saves");
            if (!Directory.Exists(savesDir) || Directory.GetFileSystemEntries(savesDir).Length == 0)
            {
                return string.Empty;
            }

            string backupsDir = Path.Combine(alpsidDir, "backups");
            Directory.CreateDirectory(backupsDir);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string zipFileName = $"backup_{timestamp}.zip";
            string zipFilePath = Path.Combine(backupsDir, zipFileName);

            // Zip saves folder
            ZipFile.CreateFromDirectory(savesDir, zipFilePath, CompressionLevel.Optimal, false);

            // Cleanup old backups based on max retention and max size
            EnforceBackupLimits(backupsDir);

            return zipFilePath;
        }

        private void EnforceBackupLimits(string backupsDir)
        {
            try
            {
                var dirInfo = new DirectoryInfo(backupsDir);
                var zipFiles = dirInfo.GetFiles("*.zip", SearchOption.TopDirectoryOnly);
                if (zipFiles.Length == 0) return;

                // 1. Retention period filter
                string retentionSetting = cmbBackupRetention.SelectedItem?.ToString() ?? "14 Gün";
                int retentionDays = 14;
                if (retentionSetting.Contains("3")) retentionDays = 3;
                else if (retentionSetting.Contains("7")) retentionDays = 7;
                else if (retentionSetting.Contains("14")) retentionDays = 14;
                else if (retentionSetting.Contains("30")) retentionDays = 30;
                else if (retentionSetting.Contains("Süresiz")) retentionDays = 99999;

                DateTime cutoff = DateTime.Now.AddDays(-retentionDays);
                foreach (var file in zipFiles)
                {
                    if (file.CreationTime < cutoff && retentionDays < 99999)
                    {
                        try { file.Delete(); } catch { }
                    }
                }

                // 2. Max size filter (MB)
                string sizeSetting = cmbMaxBackupSize.SelectedItem?.ToString() ?? "2 GB";
                long maxBytes = 2L * 1024 * 1024 * 1024;
                if (sizeSetting.Contains("500 MB")) maxBytes = 500L * 1024 * 1024;
                else if (sizeSetting.Contains("1 GB")) maxBytes = 1024L * 1024 * 1024;
                else if (sizeSetting.Contains("2 GB")) maxBytes = 2L * 1024 * 1024 * 1024;
                else if (sizeSetting.Contains("5 GB")) maxBytes = 5L * 1024 * 1024 * 1024;
                else if (sizeSetting.Contains("10 GB")) maxBytes = 10L * 1024 * 1024 * 1024;

                var remainingFiles = dirInfo.GetFiles("*.zip", SearchOption.TopDirectoryOnly);
                System.Array.Sort(remainingFiles, (a, b) => a.CreationTime.CompareTo(b.CreationTime)); // Eskiden yeniye

                long totalBytes = 0;
                foreach (var f in remainingFiles) totalBytes += f.Length;

                int i = 0;
                while (totalBytes > maxBytes && i < remainingFiles.Length)
                {
                    try
                    {
                        totalBytes -= remainingFiles[i].Length;
                        remainingFiles[i].Delete();
                    }
                    catch { }
                    i++;
                }
            }
            catch { }
        }
    }
}
