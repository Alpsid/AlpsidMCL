using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Installers;

namespace Kurulum
{
    public partial class KurulumForm : Form
    {
        private CancellationTokenSource? _cts;

        public KurulumForm()
        {
            InitializeComponent();
            this.btnYukle.Click  += new System.EventHandler(this.btnYukle_Click);
            this.btnKaldir.Click += new System.EventHandler(this.btnKaldir_Click);

            // Kurulu olup olmadığına göre buton göster/gizle
            if (IsAlpsidMCLInstalled())
            {
                btnYukle.Visible  = false;
                btnKaldir.Visible = true;
                lblDurumYukleme.Text = "AlpsidMCL zaten yüklü. Kaldırmak için 'Kaldır' butonuna tıklayın.";
            }
            else
            {
                btnYukle.Visible  = true;
                btnKaldir.Visible = false;
            }
        }

        // ─────────────────────── Yardımcı Metodlar ───────────────────────

        private static bool IsAlpsidMCLInstalled()
        {
            string exePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "AlpsidMCL", "MinecraftLauncher.exe");
            return File.Exists(exePath);
        }

        private static bool IsNet8DesktopRuntimeInstalled()
        {
            try
            {
                string dotnetPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    "dotnet", "shared", "Microsoft.WindowsDesktop.App");
                if (!Directory.Exists(dotnetPath)) return false;
                return Directory.GetDirectories(dotnetPath, "8.*").Length > 0;
            }
            catch { return false; }
        }

        private async Task InstallDotNetRuntimeAsync(CancellationToken ct)
        {
            lblDurumYukleme.Text = ".NET 8 Masaüstü Çalışma Zamanı sürüm bilgisi alınıyor...";
            progressBarYukleme.Value = 6;

            string version = "8.0.15"; // yedek sürüm
            try
            {
                using var httpVer = new HttpClient();
                httpVer.Timeout = TimeSpan.FromSeconds(10);
                string latestUrl = "https://builds.dotnet.microsoft.com/dotnet/WindowsDesktop/8.0/latest.version";
                version = (await httpVer.GetStringAsync(latestUrl, ct)).Trim();
            }
            catch { /* yedek sürümü kullan */ }

            string downloadUrl = $"https://builds.dotnet.microsoft.com/dotnet/WindowsDesktop/{version}/windowsdesktop-runtime-{version}-win-x64.exe";
            string tempPath    = Path.Combine(Path.GetTempPath(), "dotnet8-desktop-runtime.exe");

            lblDurumYukleme.Text = $".NET 8 ({version}) indiriliyor...";

            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", "AlpsidMCL-Installer/1.0");

            using var response = await http.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead, ct);
            response.EnsureSuccessStatusCode();

            long totalBytes = response.Content.Headers.ContentLength ?? -1;
            using var netStream  = await response.Content.ReadAsStreamAsync(ct);
            using var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None);

            byte[] buffer      = new byte[65536];
            long   downloaded  = 0;
            int    bytesRead;

            while ((bytesRead = await netStream.ReadAsync(buffer, 0, buffer.Length, ct)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, bytesRead, ct);
                downloaded += bytesRead;
                if (totalBytes > 0)
                {
                    int pct = 6 + (int)(downloaded * 14.0 / totalBytes); // 6→20%
                    progressBarYukleme.Value = Math.Max(6, Math.Min(20, pct));
                    lblDurumYukleme.Text =
                        $".NET 8 indiriliyor... {downloaded / 1024 / 1024} MB / {totalBytes / 1024 / 1024} MB";
                }
            }
            fileStream.Close();

            lblDurumYukleme.Text = ".NET 8 Çalışma Zamanı yükleniyor... (UAC onayı gerekebilir)";
            progressBarYukleme.Value = 20;

            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName        = tempPath,
                Arguments       = "/quiet /norestart",
                UseShellExecute = true,
                Verb            = "runas"
            };
            var proc = System.Diagnostics.Process.Start(psi);
            if (proc != null)
                await Task.Run(() => proc.WaitForExit(), ct);

            try { File.Delete(tempPath); } catch { }
        }

        // ─────────────────────── KUR ───────────────────────

        private async void btnYukle_Click(object? sender, EventArgs e)
        {
            btnYukle.Enabled = false;
            _cts = new CancellationTokenSource();

            try
            {
                // 1. Dizinleri hazırla
                lblDurumYukleme.Text    = "Yükleme dizinleri kontrol ediliyor...";
                progressBarYukleme.Value = 5;

                string roamingAppDir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AlpsidMCL");

                Directory.CreateDirectory(roamingAppDir);
                // AlpsidMCL klasörü hem launcher hem oyun veri dizini olarak kullanılır
                // versions, libraries, assets alt klasörleri AlpsidMCL içinde oluşacak

                // 2. .NET 8 Masaüstü Çalışma Zamanı kontrolü
                if (!IsNet8DesktopRuntimeInstalled())
                {
                    lblDurumYukleme.Text = ".NET 8 Masaüstü Çalışma Zamanı bulunamadı. İndiriliyor...";
                    await InstallDotNetRuntimeAsync(_cts.Token);

                    if (!IsNet8DesktopRuntimeInstalled())
                        throw new Exception(
                            ".NET 8 Masaüstü Çalışma Zamanı yüklenemedi!\n" +
                            "Lütfen https://dotnet.microsoft.com adresinden manuel olarak yükleyin.");
                }
                else
                {
                    progressBarYukleme.Value = 25;
                }

                // 3. Gömülü launcher.exe çıkart
                lblDurumYukleme.Text     = "Launcher dosyaları %appdata%\\AlpsidMCL dizinine kuruluyor...";
                progressBarYukleme.Value  = 30;

                string targetExePath = Path.Combine(roamingAppDir, "MinecraftLauncher.exe");

                string? resourceName = null;
                var assembly = Assembly.GetExecutingAssembly();
                foreach (var name in assembly.GetManifestResourceNames())
                {
                    if (name.IndexOf("MinecraftLauncher.exe", StringComparison.OrdinalIgnoreCase) >= 0 ||
                       (name.IndexOf("Minecraft",            StringComparison.OrdinalIgnoreCase) >= 0 &&
                        name.IndexOf("exe",                  StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        resourceName = name;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(resourceName))
                    throw new FileNotFoundException("Gömülü launcher kaynak dosyası bulunamadı!");

                using (Stream stream = assembly.GetManifestResourceStream(resourceName)!)
                {
                    if (stream == null)
                        throw new FileNotFoundException("Gömülü launcher kaynak akışı yüklenemedi!");

                    using var fs = new FileStream(targetExePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    await stream.CopyToAsync(fs, _cts.Token);
                }

                progressBarYukleme.Value = 40;

                // 4. Masaüstü kısayolu
                lblDurumYukleme.Text     = "Masaüstü kısayolu oluşturuluyor...";
                CreateDesktopShortcuts(targetExePath, roamingAppDir);
                progressBarYukleme.Value = 45;

                // 5. Minecraft 1.20.1 önceden indir
                lblDurumYukleme.Text =
                    "Minecraft temel kütüphaneleri ve 1.20.1 sürümü %appdata%\\AlpsidMCL\\versions klasörüne indiriliyor...";

                var mcPath   = new MinecraftPath(roamingAppDir);
                var launcher = new MinecraftLauncher(mcPath);

                var fileProgress = new Progress<InstallerProgressChangedEventArgs>(progress =>
                {
                    if (progress.TotalTasks > 0)
                    {
                        int pct = 45 + (int)(((double)progress.ProgressedTasks / progress.TotalTasks) * 55);
                        progressBarYukleme.Value =
                            Math.Max(45, Math.Min(100, pct));
                    }
                    lblDurumYukleme.Text =
                        $"Kütüphaneler indiriliyor: {progress.Name} ({progress.ProgressedTasks}/{progress.TotalTasks})";
                });

                var byteProgress = new Progress<ByteProgress>();
                await launcher.InstallAsync("1.20.1", fileProgress, byteProgress, _cts.Token);

                progressBarYukleme.Value = 100;
                lblDurumYukleme.Text     = "Kurulum ve hazırlama başarıyla tamamlandı!";

                MessageBox.Show(
                    "AlpsidMCL ve temel oyun kütüphaneleri %appdata% dizinine kuruldu!\n" +
                    "Masaüstünüzdeki 'AlpsidMCL' kısayolunu kullanarak oyunu başlatabilirsiniz.",
                    "Kurulum Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Application.Exit();
            }
            catch (Exception ex)
            {
                lblDurumYukleme.Text = "Kurulum sırasında hata oluştu!";
                MessageBox.Show("Kurulum hatası:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnYukle.Enabled = true;
            }
        }

        // ─────────────────────── KALDIR ───────────────────────

        private void btnKaldir_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "AlpsidMCL launcher kaldırılacak.\n" +
                "Minecraft oyun dosyaları (.minecraft klasörü) silinmeyecek.\n\n" +
                "Devam etmek istiyor musunuz?",
                "Kaldır - AlpsidMCL",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                // %appdata%\AlpsidMCL klasörünü sil
                string installDir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "AlpsidMCL");

                if (Directory.Exists(installDir))
                    Directory.Delete(installDir, recursive: true);

                // Masaüstü kısayollarını sil
                var desktopPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                try
                {
                    desktopPaths.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    desktopPaths.Add(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                    string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    desktopPaths.Add(Path.Combine(userProfile, "Desktop"));
                    desktopPaths.Add(Path.Combine(userProfile, "OneDrive", "Desktop"));
                    desktopPaths.Add(Path.Combine(userProfile, "OneDrive", "Masaüstü"));
                    desktopPaths.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
                }
                catch { }

                foreach (var desktop in desktopPaths)
                {
                    try
                    {
                        string lnk = Path.Combine(desktop, "AlpsidMCL.lnk");
                        if (File.Exists(lnk)) File.Delete(lnk);
                    }
                    catch { }
                }

                MessageBox.Show(
                    "AlpsidMCL başarıyla kaldırıldı!\n" +
                    "Minecraft oyun dosyalarınız (.minecraft) korundu.",
                    "Kaldırma Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaldırma hatası:\n" + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────── Kısayol ───────────────────────

        private void CreateDesktopShortcuts(string targetExePath, string workingDir)
        {
            var desktopPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                string p1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (!string.IsNullOrEmpty(p1)) desktopPaths.Add(p1);

                string p2 = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                if (!string.IsNullOrEmpty(p2)) desktopPaths.Add(p2);

                string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                if (!string.IsNullOrEmpty(userProfile))
                {
                    desktopPaths.Add(Path.Combine(userProfile, "Desktop"));
                    desktopPaths.Add(Path.Combine(userProfile, "OneDrive", "Desktop"));
                    desktopPaths.Add(Path.Combine(userProfile, "OneDrive", "Masaüstü"));
                }

                string common = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
                if (!string.IsNullOrEmpty(common)) desktopPaths.Add(common);
            }
            catch { }

            foreach (var desktopFolder in desktopPaths)
            {
                try
                {
                    if (Directory.Exists(desktopFolder))
                    {
                        string lnkPath = Path.Combine(desktopFolder, "AlpsidMCL.lnk");
                        SaveShortcutNative(targetExePath, workingDir, lnkPath, "AlpsidMCL - Minecraft Launcher");
                    }
                }
                catch { }
            }
        }

        private static void SaveShortcutNative(string targetPath, string workingDir, string lnkPath, string description)
        {
            IShellLinkW link = (IShellLinkW)new ShellLink();
            link.SetPath(targetPath);
            link.SetWorkingDirectory(workingDir);
            link.SetDescription(description);

            System.Runtime.InteropServices.ComTypes.IPersistFile file =
                (System.Runtime.InteropServices.ComTypes.IPersistFile)link;
            file.Save(lnkPath, true);
        }
    }

    #region COM Interfaces for Native Shortcut Creation
    [ComImport]
    [Guid("00021401-0000-0000-C000-000000000046")]
    internal class ShellLink { }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214F9-0000-0000-C000-000000000046")]
    internal interface IShellLinkW
    {
        void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxDir);
        void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotkey(out short pwHotkey);
        void SetHotkey(short wHotkey);
        void GetShowCmd(out int piShowCmd);
        void SetShowCmd(int iShowCmd);
        void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
        void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        void Resolve(IntPtr hwnd, int fFlags);
        void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }
    #endregion
}
