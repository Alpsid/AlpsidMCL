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
        /// Yeni EXE'yi geçici konuma indirir, .ps1 dosyası oluşturarak güncellemeyi uygular.
        /// Inline PowerShell komutları yerine dosya tabanlı script kullanılır —
        /// böylece tırnak/escape sorunları tamamen ortadan kalkar.
        /// </summary>
        public static async Task DownloadAndApplyUpdateAsync(
            string downloadUrl,
            string currentExePath,
            IProgress<int> progress,
            CancellationToken ct = default)
        {
            string tempDir    = Path.GetTempPath();
            string tempNewExe = Path.Combine(tempDir, "MinecraftLauncher_new.exe");
            string ps1Path    = Path.Combine(tempDir, "alpsidmcl_updater.ps1");
            string logPath    = Path.Combine(tempDir, "alpsidmcl_updater.log");

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

            // 2. Harici .ps1 güncelleme script'i oluştur
            //    Tırnak sorunlarını tamamen ortadan kaldırmak için ayrı dosya kullanılır.
            //    Hata loglaması da eklendi — sorun olursa %TEMP%\alpsidmcl_updater.log dosyasına yazar.
            string psContent =
$@"try {{
    $logFile = '{logPath.Replace("'", "''")}'
    $srcFile = '{tempNewExe.Replace("'", "''")}'
    $dstFile = '{currentExePath.Replace("'", "''")}'
    $pidWait = {currentPid}

    Add-Content -Path $logFile -Value ""[$(Get-Date)] Updater started. Waiting for PID $pidWait...""

    # Mevcut launcher kapanana kadar bekle (max 30 saniye)
    $waited = 0
    while ($waited -lt 150) {{
        $proc = Get-Process -Id $pidWait -ErrorAction SilentlyContinue
        if (-not $proc) {{ break }}
        Start-Sleep -Milliseconds 200
        $waited++
    }}

    # Ekstra bekleme — dosya kilidi serbest kalsın
    Start-Sleep -Milliseconds 500

    Add-Content -Path $logFile -Value ""[$(Get-Date)] Process exited. Copying file...""
    Add-Content -Path $logFile -Value ""  Source: $srcFile (exists: $(Test-Path $srcFile))""
    Add-Content -Path $logFile -Value ""  Dest:   $dstFile""

    if (-not (Test-Path $srcFile)) {{
        Add-Content -Path $logFile -Value ""[$(Get-Date)] ERROR: Source file not found!""
        exit 1
    }}

    # Hedef dizinin var olduğundan emin ol
    $destDir = Split-Path -Parent $dstFile
    if (-not (Test-Path $destDir)) {{
        New-Item -ItemType Directory -Path $destDir -Force | Out-Null
    }}

    # AppData varsayılan konumunu da güncelle (Eğer farklı bir yerden çalıştırıldıysa ikisi de güncellensin)
    $appDataExe = Join-Path $env:APPDATA 'AlpsidMCL\MinecraftLauncher.exe'

    # Kopyalama denemesi (dosya kilidi bazen birkaç saniye sürebilir, 15 kez dene)
    $copied = $false
    for ($i = 1; $i -le 15; $i++) {{
        try {{
            Copy-Item -Path $srcFile -Destination $dstFile -Force -ErrorAction Stop
            $copied = $true
            Add-Content -Path $logFile -Value ""[$(Get-Date)] Copy succeeded on attempt $i to $dstFile.""

            if ($dstFile -ne $appDataExe -and (Test-Path (Split-Path -Parent $appDataExe))) {{
                try {{
                    Copy-Item -Path $srcFile -Destination $appDataExe -Force -ErrorAction SilentlyContinue
                    Add-Content -Path $logFile -Value ""[$(Get-Date)] Also synced copy to $appDataExe.""
                }} catch {{ }}
            }}
            break
        }} catch {{
            Add-Content -Path $logFile -Value ""[$(Get-Date)] Copy attempt $i failed: $($_.Exception.Message). Retrying in 500ms...""
            Start-Sleep -Milliseconds 500
        }}
    }}

    if (-not $copied) {{
        Add-Content -Path $logFile -Value ""[$(Get-Date)] ERROR: Could not overwrite destination file after 15 attempts!""
        exit 1
    }}

    # Doğrulama: hedef dosya var mı?
    if (Test-Path $dstFile) {{
        Add-Content -Path $logFile -Value ""[$(Get-Date)] SUCCESS: File updated.""
    }} else {{
        Add-Content -Path $logFile -Value ""[$(Get-Date)] ERROR: Destination file not found after copy!""
    }}

    # Temp dosyayı sil
    Remove-Item -Path $srcFile -Force -ErrorAction SilentlyContinue

    # Yeni launcher'ı başlat
    Add-Content -Path $logFile -Value ""[$(Get-Date)] Starting launcher: $dstFile""
    Start-Process -FilePath $dstFile

}} catch {{
    Add-Content -Path $logFile -Value ""[$(Get-Date)] EXCEPTION: $($_.Exception.Message)""
}}";

            File.WriteAllText(ps1Path, psContent, System.Text.Encoding.UTF8);

            // 3. Script'i başlat
            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{ps1Path}\"",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });

            // 4. Uygulamayı ve tüm thread'leri anında sonlandır
            Environment.Exit(0);
        }
    }
}
