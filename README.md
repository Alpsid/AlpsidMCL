<p align="center">
  <img src="logo.png" alt="AlpsidMCL Logo" width="120"/>
</p>

<h1 align="center">Alpsid MC Launcher</h1>

<p align="center">
  <b>Hafif, hızlı ve özelleştirilebilir Minecraft başlatıcı</b><br>
  <i>Windows • .NET 8 • Açık Kaynak</i>
</p>

<p align="center">
  <a href="https://github.com/Alpsid/AlpsidMCL/releases/latest"><img alt="Latest Release" src="https://img.shields.io/github/v/release/Alpsid/AlpsidMCL?style=for-the-badge&color=a6e3a1&label=Son%20Sürüm"/></a>
  <a href="https://github.com/Alpsid/AlpsidMCL/releases"><img alt="Downloads" src="https://img.shields.io/github/downloads/Alpsid/AlpsidMCL/total?style=for-the-badge&color=89b4fa&label=İndirme"/></a>
  <a href="https://github.com/Alpsid/AlpsidMCL/blob/main/LICENSE"><img alt="License" src="https://img.shields.io/github/license/Alpsid/AlpsidMCL?style=for-the-badge&color=f9e2af"/></a>
</p>

---

## 📖 Nedir?

**AlpsidMCL**, Minecraft Java Edition için geliştirilmiş bağımsız bir başlatıcıdır. Resmi Mojang API üzerinden tüm Minecraft sürümlerini indirip oynayabilir, Forge ve NeoForge mod yükleyicilerini otomatik kurabilir ve mod paketlerinizi profil olarak yönetebilirsiniz.

### ✨ Temel Özellikler

| Özellik | Açıklama |
|---------|----------|
| 🎮 **Tüm Sürümler** | Release, Snapshot, Beta ve Alpha sürümlerini tek tıkla oynayın |
| 🌐 **Çevrimdışı Mod** | İnternet olmadan daha önce indirdiğiniz sürümleri oynayın |
| 🔧 **Forge & NeoForge** | Mod yükleyicileri otomatik olarak indirilip kurulur |
| 📦 **Alpsid Mods Menüsü** | Mod paketleri oluşturun, yönetin ve tek tıkla oynayın |
| ⚙️ **Gelişmiş Ayarlar** | Sürüm filtreleri, pencere boyutlandırma ve yedekleme sistemi |
| 💾 **Otomatik Yedekleme** | Dünya kayıtlarınız (saves) güvenle yedeklenir |
| 🔄 **Otomatik Güncelleme** | Yeni sürümler GitHub üzerinden otomatik indirilir ve kurulur |
| 🏠 **İzole Dizin** | Tüm veriler `%appdata%\AlpsidMCL` altında saklanır, `.minecraft` klasörüne dokunulmaz |

---

## 📥 Kurulum

### Hızlı Kurulum (Önerilen)

1. [**Releases**](https://github.com/Alpsid/AlpsidMCL/releases/latest) sayfasından `Kurulum.exe` veya `Kurulum.zip` dosyasını indirin.
2. `Kurulum.exe`'yi çalıştırın — gerekli dosyalar otomatik olarak `%appdata%\AlpsidMCL` dizinine kurulur ve masaüstü kısayolu oluşturulur.
3. Masaüstündeki **Minecraft Launcher** kısayoluna tıklayarak başlatın.

### Manuel Kurulum

1. [**Releases**](https://github.com/Alpsid/AlpsidMCL/releases/latest) sayfasından `MinecraftLauncher.exe` dosyasını indirin.
2. İstediğiniz bir klasöre yerleştirin.
3. Çalıştırın — ilk açılışta gerekli dosyalar otomatik oluşturulur.

> **Not:** .NET 8 Desktop Runtime gereklidir. Kurulum.exe bunu otomatik olarak kontrol eder ve gerekirse yükler.

---

## 🖥️ Ekran Görüntüleri

### Ana Ekran
Minecraft sürüm haberleri, launcher duyuruları ve hızlı oyun başlatma paneli.

### Alpsid Mods Menüsü
Mod paketleri oluşturma, yönetme ve sıralama. Home, Mods, Resource Packs ve Shaders sekmeleri.

### Ayarlar
Sürüm filtreleri (Snapshot/Beta/Alpha), pencere boyutlandırma ve yedekleme sistemi ayarları.

---

## ⚙️ Ayarlar ve Yapılandırma

### Sürüm Filtreleri
Ayarlar menüsünden aşağıdaki sürüm tiplerini açıp kapatabilirsiniz:
- 🧪 **Snapshot** sürümleri
- 🔨 **Beta** sürümleri
- 📜 **Alpha** sürümleri

### Pencere Boyutlandırma
Launcher penceresini serbest boyutlandırılabilir moduna geçirebilir ve tam ekran yapabilirsiniz.

### Yedekleme Sistemi
- **Açma/Kapatma:** Yedeklemeyi tamamen devre dışı bırakabilirsiniz
- **Maksimum Boyut:** 500 MB — 10 GB arası
- **Saklama Süresi:** 3 Gün, 7 Gün, 14 Gün, 30 Gün veya Süresiz
- **Sıklık:** Her oyundan çıkışta, günde 1 kez, haftada 1 kez veya yalnızca manuel
- **Manuel Yedekleme:** "Şimdi Yedek Al" butonu ile anında yedek alabilirsiniz

Yedekler `%appdata%\AlpsidMCL\backups` dizinine sıkıştırılmış (.zip) olarak kaydedilir.

### Yapılandırma Dosyası
Tüm ayarlar `%appdata%\AlpsidMCL\launcher_config.json` dosyasında saklanır ve launcher yeniden açıldığında otomatik yüklenir.

---

## 📁 Dizin Yapısı

```
%appdata%\AlpsidMCL\
├── versions/           # İndirilen Minecraft sürümleri
├── libraries/          # Oyun kütüphaneleri
├── assets/             # Oyun kaynakları (sesler, diller vb.)
├── saves/              # Dünya kayıtları
├── modpacks/           # Oluşturulan mod paketleri
├── backups/            # Otomatik ve manuel yedekler
├── launcher_config.json # Launcher ayarları
└── MinecraftLauncher.exe
```

---

## 🔄 Güncelleme Sistemi

AlpsidMCL, başlatıldığında GitHub Releases API üzerinden otomatik güncelleme kontrolü yapar:

1. Son sürüm kontrol edilir
2. Yeni sürüm varsa kullanıcıya sorulur
3. Kabul edilirse yeni EXE indirilir
4. Launcher kapanır ve güncelleme uygulanır
5. Güncellenmiş launcher otomatik yeniden başlatılır

---

## 🛠️ Geliştirme

### Gereksinimler
- .NET 8 SDK
- Windows 10/11

### Derleme

```powershell
# Tam derleme (Launcher + Kurulum + Zip)
powershell -ExecutionPolicy Bypass -File .\build.ps1
```

Çıktılar:
- `publish_launcher\MinecraftLauncher.exe` — Framework-dependent launcher
- `Kurulum.exe` — Self-contained yükleyici
- `Kurulum.zip` — Kurulum arşivi

### Kullanılan Teknolojiler

- **C# / .NET 8** — Windows Forms
- **CmlLib.Core** — Minecraft indirme ve başlatma motoru
- **CmlLib.Core.Installer.Forge** — Forge otomatik kurulumu
- **CmlLib.Core.Installer.NeoForge** — NeoForge otomatik kurulumu
- **GitHub Releases API** — Otomatik güncelleme ve duyuru sistemi

---

## 📋 Sürüm Geçmişi

| Sürüm | Tarih | Öne Çıkanlar |
|-------|-------|-------------|
| v1.0.8 | Kasım 2026 | Update döngüsü düzeltmesi, vanilla mod paketi hatası düzeltmesi, ayarlar menüsü, yedekleme sistemi |
| v1.0.6 | Kasım 2026 | Alpsid Mods menüsü, arama çubuğu, sıralama, arayüz iyileştirmeleri |
| v1.0.5 | Ekim 2026 | Çevrimdışı mod desteği, özel logo |
| v1.0.4 | Ekim 2026 | Launcher haberleri, Minecraft yenilikleri paneli |
| v1.0.2 | Ekim 2026 | İzole AlpsidMCL dizini, otomatik güncelleme sistemi |
| v1.0.0 | Ağustos 2026 | İlk sürüm |

---

## ⚠️ Bilinen Sorunlar ve Notlar

- **Windows Defender Uyarısı:** İmzalanmamış EXE olduğu için Windows SmartScreen uyarısı gösterebilir. Bu bir güvenlik tehdidi değildir — "Yine de çalıştır" seçeneğiyle devam edebilirsiniz.
- **Antivirüs Yazılımları:** Bazı antivirüs programları tek dosyalık (single-file) .NET uygulamalarını şüpheli olarak işaretleyebilir. İstisna ekleyerek sorunu çözebilirsiniz.

---

## 📄 Lisans

Bu proje açık kaynaklıdır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

---

<p align="center">
  <b>Alpsid</b> tarafından ❤️ ile geliştirildi
</p>
