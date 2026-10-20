# PowerShell Script to build Launcher and Setup Installer

$ErrorActionPreference = "Stop"
$DotNetExe = "C:\Program Files\Unity\Hub\Editor\6000.5.6f1\Editor\Data\DotNetSdk\dotnet.exe"

Write-Host "1. Building Launcher as Single File..." -ForegroundColor Green
& $DotNetExe publish MinecraftLauncher.csproj -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -o "./publish_launcher"

Write-Host "2. Preparing Installer Resources..." -ForegroundColor Green
if (-not (Test-Path "./Kurulum/Resources")) {
    New-Item -ItemType Directory -Path "./Kurulum/Resources" -Force
}

Copy-Item "./publish_launcher/MinecraftLauncher.exe" "./Kurulum/Resources/MinecraftLauncher.exe" -Force

Write-Host "3. Building Setup Installer (Kurulum.exe)..." -ForegroundColor Green
& $DotNetExe publish Kurulum/Kurulum.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true -o "./publish_installer"

Write-Host "4. Copying final Kurulum.exe to workspace root..." -ForegroundColor Green
Copy-Item "./publish_installer/Kurulum.exe" "./Kurulum.exe" -Force

Write-Host "5. Creating Kurulum.zip for release..." -ForegroundColor Green
Compress-Archive -Path "./Kurulum.exe" -DestinationPath "./Kurulum.zip" -Force

Write-Host "Success! Kurulum.exe and Kurulum.zip are ready at root directory." -ForegroundColor Cyan
