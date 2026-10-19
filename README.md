<div align="center">

# 🚀 AlpsidMCL - Minecraft Launcher

**Hafif, modern, bağımsız ve otomatik güncellenebilen açık kaynaklı özel Minecraft Launcher.**

[![GitHub Release](https://img.shields.io/github/v/release/Alpsid/AlpsidMCL?color=blue&label=Son%20S%C3%BCr%C3%BCm)](https://github.com/Alpsid/AlpsidMCL/releases/latest)
[![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey.svg)](https://dotnet.microsoft.com/)
[![.NET Version](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

[İndir (Releases)](https://github.com/Alpsid/AlpsidMCL/releases) • [Özellikler](#-özellikler) • [Nasıl Kurulur?](#-nasıl-kurulur) • [Geliştirici Rehberi](#-geliştirici-rehberi)

</div>

---

## ✨ Neden AlpsidMCL?

Çoğu üçüncü taraf launcher orijinal Minecraft dosyalarınızın üzerine yazar veya sisteminize karmaşık bağımlılıklar yükler. **AlpsidMCL**, oyun deneyiminizi izole ve temiz tutmak için tasarlanmıştır.

### 🌟 Temel Özellikler

- **🔒 %100 İzole Dizin (Sıfır Çakışma):**
  - Orijinal `.minecraft` klasörünüze asla dokunmaz.
  - Oyun sürümleri, ayarlar ve kütüphaneler tamamen `%appdata%\AlpsidMCL\` dizininde saklanır.
- **🔄 Otomatik Güncelleme (GitHub Entegrasyonu):**
  - Launcher her açılışta GitHub Releases API üzerinden yeni bir sürüm olup olmadığını kontrol eder.
  - Güncelleme varsa kullanıcıyı uyarır ve onay verildiğinde kendini arka planda tek tıkla günceller.
- **📦 Akıllı Kurulum Sihirbazı (`Kurulum.exe`):**
  - Bilgisayarınızda .NET 8 Masaüstü Çalışma Zamanı (Desktop Runtime) yoksa **otomatik olarak indirir ve kurar**.
  - Masaüstünüze doğrudan **AlpsidMCL** kısayolu oluşturur.
  - İlk açılışın hızlı olması için temel Minecraft kütüphanelerini önceden indirir.
- **🗑️ Kolay Kaldırma Desteği:**
  - Launcher zaten kuruluysa, `Kurulum.exe` otomatik olarak kaldırma moduna geçer.
  - Tek tıkla launcher dosyalarını ve kısayolları sistemden temizler.
- **🛠️ Mod Yükleyici Desteği:**
  - Vanilla sürümlerin yanı sıra tek tıkla **Forge** ve **NeoForge** kurabilme imkanı.

---

## 📥 Nasıl Kurulur?

Oyunu oynamak için kodlarla uğraşmanıza gerek yoktur:

1. Sağ taraftaki **[Releases](https://github.com/Alpsid/AlpsidMCL/releases/latest)** bölümüne gidin.
2. `Kurulum.exe` dosyasını indirin.
3. Programı açıp **"Kur ve Hazırla"** butonuna basın.
4. Masaüstünüze gelen **AlpsidMCL** kısayoluna çift tıklayarak oyuna başlayın!

---

## 💻 Geliştirici Rehberi (Kaynak Koddan Derleme)

Projeyi kendi ortamınızda derlemek, katkıda bulunmak veya incelemek isterseniz:

### Gereksinimler
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (.NET Masaüstü Geliştirme iş yükü ile)

### Projeyi Çalıştırma
```bash
# Repoyu bilgisayarınıza klonlayın
git clone https://github.com/Alpsid/AlpsidMCL.git

# Proje dizinine gidin
cd AlpsidMCL
