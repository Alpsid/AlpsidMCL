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

            // Bind Form Load and button click events
            this.Load += new System.EventHandler(this.Form1_Load);
            this.btnOyna.Click += new System.EventHandler(this.btnOyna_Click);
        }

        private const string LAUNCHER_VERSION = "1.0.0";

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

            // Arka planda güncelleme kontrolünü başlat (kullanıcıyı engellemez)
            _ = CheckForUpdatesAsync();

            try
            {
                lblDurum.Text = "Minecraft sürümleri Mojang API'sinden çekiliyor...";
                progressBar1.Value = 10;

                // Load Minecraft versions
                var versions = await _launcher.GetAllVersionsAsync();
                
                cmbSurumler.Items.Clear();
                foreach (var version in versions)
                {
                    if (version.Type == "release")
                    {
                        cmbSurumler.Items.Add(version.Name);
                    }
                }

                if (cmbSurumler.Items.Count > 0)
                {
                    cmbSurumler.SelectedIndex = 0;
                    lblDurum.Text = "Sürümler yüklendi. Oyuna başlamak için Oyna butonuna basın.";
                }
                else
                {
                    lblDurum.Text = "Hata: Kararlı (Release) sürüm bulunamadı.";
                }
                progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                lblDurum.Text = "Hata: Sürüm listesi alınamadı.";
                MessageBox.Show("Minecraft sürümleri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar1.Value = 0;
            }
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

                    string currentExePath = Environment.ProcessPath ?? 
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AlpsidMCL", "MinecraftLauncher.exe");

                    await Updater.DownloadAndApplyUpdateAsync(downloadUrl, currentExePath, progress);
                }
            }
            catch (Exception ex)
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

                // Step 1: Install core vanilla version
                lblDurum.Text = $"{selectedVersion} Vanilla sürümü kuruluyor...";
                progressBar1.Value = 20;

                var fileProgress = new Progress<InstallerProgressChangedEventArgs>(progress =>
                {
                    if (progress.TotalTasks > 0)
                    {
                        int pct = (int)((double)progress.ProgressedTasks / progress.TotalTasks * 100);
                        progressBar1.Value = Math.Max(0, Math.Min(100, pct));
                    }
                    lblDurum.Text = $"İndiriliyor: {progress.Name} ({progress.ProgressedTasks}/{progress.TotalTasks})";
                });

                // Trigger Vanilla installation first
                await _launcher.InstallAsync(selectedVersion, fileProgress, new Progress<ByteProgress>(), _cts.Token);

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

                // Step 3: Download & Extract Modpack
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
    }
}
