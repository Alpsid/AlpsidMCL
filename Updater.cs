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

                // Tag adı: "v1.2.3" → "1.2.3"
                string tagName       = root.GetProperty("tag_name").GetString() ?? "";
                string remoteVersion = tagName.TrimStart('v');

                if (string.IsNullOrWhiteSpace(remoteVersion))
                    return (false, "", "");

                // Release asset'leri içinden .exe dosyasını bul
                string downloadUrl = "";
                if (root.TryGetProperty("assets", out var assets))
                {
                    foreach (var asset in assets.EnumerateArray())
                    {
                        string? assetName = asset.GetProperty("name").GetString();
                        if (assetName != null &&
                            assetName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                        {
                            downloadUrl = asset.GetProperty("browser_download_url")
                                              .GetString() ?? "";
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(downloadUrl))
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

        // ─── Sürüm Karşılaştırma ────────────────────────────────────────────

        private static bool IsNewerVersion(string remote, string current)
        {
            try
            {
                return new Version(remote) > new Version(current);
            }
            catch
            {
                // Version parse edilemezse string karşılaştırması kullan
                return string.Compare(remote, current, StringComparison.OrdinalIgnoreCase) > 0;
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

            // 2. Updater bat script oluştur
            //    - 3 saniye bekle (mevcut process kapansın)
            //    - Yeni EXE'yi üzerine kopyala
            //    - Yeni launcher'ı başlat
            //    - Geçici dosyaları temizle
            string batContent =
                "@echo off\r\n" +
                "timeout /t 3 /nobreak > nul\r\n" +
                $"copy /Y \"{tempNewExe}\" \"{currentExePath}\"\r\n" +
                $"start \"\" \"{currentExePath}\"\r\n" +
                $"del \"{tempNewExe}\" 2>nul\r\n" +
                "del \"%~f0\"\r\n";

            await File.WriteAllTextAsync(batPath, batContent, ct);

            // 3. Bat'ı gizli pencerede başlat ve mevcut uygulamayı kapat
            Process.Start(new ProcessStartInfo
            {
                FileName        = "cmd.exe",
                Arguments       = $"/c \"{batPath}\"",
                UseShellExecute = true,
                WindowStyle     = ProcessWindowStyle.Hidden
            });

            System.Windows.Forms.Application.Exit();
        }
    }
}
