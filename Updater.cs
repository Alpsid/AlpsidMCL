using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Minecraft_launcher
{
    /// <summary>
    /// GitHub Releases üzerinden güncelleme kontrolü ve uygulaması.
    /// </summary>
    internal static class Updater
    {
        // ─── GitHub Repo Bilgileri ───────────────────────────────────────────
        // Aşağıdaki iki sabiti kendi GitHub kullanıcı adı ve repo adınla değiştir.
        private const string GITHUB_OWNER = "Alpsid";
        private const string GITHUB_REPO  = "AlpsidMCL";

        private static readonly string ApiUrl =
            $"https://api.github.com/repos/{GITHUB_OWNER}/{GITHUB_REPO}/releases/latest";

        // ─── Güncelleme Kontrolü ────────────────────────────────────────────

        /// <summary>
        /// GitHub API'den son sürümü kontrol eder.
        /// Hata durumunda sessizce (false, "", "") döner — kullanıcıyı rahatsız etmez.
        /// </summary>
        public static async Task<(bool hasUpdate, string newVersion, string downloadUrl)>
            CheckForUpdateAsync(string currentVersion)
        {
            try
            {
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Add("User-Agent", "AlpsidMCL-Updater/1.0");
                http.Timeout = TimeSpan.FromSeconds(10);

                string json = await http.GetStringAsync(ApiUrl);
                using var doc  = JsonDocument.Parse(json);
                var root        = doc.RootElement;

                // Tag adı: "v1.0.1-fix" -> sadece "1.0.1" kısmını temizle
                string tagName = root.GetProperty("tag_name").GetString() ?? "";
                string remoteVersion = CleanVersionString(tagName);

                if (string.IsNullOrWhiteSpace(remoteVersion))
                    return (false, "", "");

                // Release asset'leri içinden özellikle MinecraftLauncher.exe dosyasını bul
                string downloadUrl = "";
                long assetSize = 0;
                if (root.TryGetProperty("assets", out var assets))
                {
                    foreach (var asset in assets.EnumerateArray())
                    {
                        string? assetName = asset.GetProperty("name").GetString();
                        if (string.Equals(assetName, "MinecraftLauncher.exe", StringComparison.OrdinalIgnoreCase))
                        {
                            downloadUrl = asset.GetProperty("browser_download_url").GetString() ?? "";
                            if (asset.TryGetProperty("size", out var s))
                            {
                                assetSize = s.GetInt64();
                            }
                            break;
                        }
                    }
                }

                // GÜVENLİK KONTROLÜ: MinecraftLauncher.exe ~1-5 MB arasındadır.
                // Eğer yanlışlıkla Kurulum.exe (60+ MB) eşleşirse asla indirme!
                if (string.IsNullOrEmpty(downloadUrl) || assetSize > 15 * 1024 * 1024)
                    return (false, "", "");

                bool hasUpdate = IsNewerVersion(remoteVersion, currentVersion);
                return (hasUpdate, remoteVersion, downloadUrl);
            }
            catch
            {
                // İnternet yoksa veya GitHub erişilemiyorsa — sessizce devam et
                return (false, "", "");
            }
        }

        // ─── Sürüm Temizleme ve Karşılaştırma ───────────────────────────────

        private static string CleanVersionString(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";
            // Baştaki 'v' veya 'V' harfini at
            raw = raw.Trim().TrimStart('v', 'V');
            // "-fix", "-beta" gibi ekleri temizle (ilk tire işaretine kadar al)
            int dashIndex = raw.IndexOf('-');
            if (dashIndex > 0)
            {
                raw = raw.Substring(0, dashIndex);
            }
            return raw.Trim();
        }

        private static bool IsNewerVersion(string remote, string current)
        {
            try
            {
                var vRemote = new Version(CleanVersionString(remote));
                var vCurrent = new Version(CleanVersionString(current));
                return vRemote > vCurrent;
            }
            catch
            {
                return false;
            }
        }

        // ─── İndir ve Uygula ────────────────────────────────────────────────

        /// <summary>
        /// Yeni EXE'yi geçici konuma indirir ve ardından updater.bat ile kendini değiştirir.
        /// Windows'ta çalışan EXE doğrudan değiştirilemez; bat trick endüstri standardı çözümdür.
        /// </summary>
        public static async Task DownloadAndApplyUpdateAsync(
            string downloadUrl,
            string currentExePath,
            IProgress<int> progress,
            CancellationToken ct = default)
        {
            string tempNewExe = Path.Combine(Path.GetTempPath(), "MinecraftLauncher_new.exe");
            string batPath    = Path.Combine(Path.GetTempPath(), "alpsidmcl_updater.bat");

            // 1. Yeni EXE'yi indir
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("User-Agent", "AlpsidMCL-Updater/1.0");

            using var response = await http.GetAsync(
                downloadUrl, HttpCompletionOption.ResponseHeadersRead, ct);
            response.EnsureSuccessStatusCode();

            long totalBytes   = response.Content.Headers.ContentLength ?? -1;
            using var netStream  = await response.Content.ReadAsStreamAsync(ct);
            using var fileStream = new FileStream(
                tempNewExe, FileMode.Create, FileAccess.Write, FileShare.None);

            byte[] buffer    = new byte[65536];
            long   downloaded = 0;
            int    bytesRead;

            while ((bytesRead = await netStream.ReadAsync(buffer, 0, buffer.Length, ct)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, bytesRead, ct);
                downloaded += bytesRead;
                if (totalBytes > 0)
                {
                    int pct = (int)(downloaded * 100.0 / totalBytes);
                    progress.Report(Math.Max(0, Math.Min(100, pct)));
                }
            }
            fileStream.Close();
            progress.Report(100);

            int currentPid = Environment.ProcessId;

            // 2. PowerShell ile garantili güncelleme uygulayıcı
            // Mevcut işlem (PID) tamamen kapanana kadar bekler, ardından dosyayı güvenle kopyalar.
            string psScript = 
                $"$pidToWait = {currentPid}; " +
                "while (Get-Process -Id $pidToWait -ErrorAction SilentlyContinue) { Start-Sleep -Milliseconds 200 }; " +
                "Start-Sleep -Milliseconds 500; " +
                $"Copy-Item -Path '{tempNewExe}' -Destination '{currentExePath}' -Force; " +
                $"Remove-Item -Path '{tempNewExe}' -Force -ErrorAction SilentlyContinue; " +
                $"Start-Process -FilePath '{currentExePath}'";

            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{psScript}\"",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Minimized
            });

            // Uygulamayı ve tüm thread'leri anında sonlandır
            Environment.Exit(0);
        }
    }
}
