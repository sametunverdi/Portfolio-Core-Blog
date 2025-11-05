# ASP.NET Core ile Dinamik Portfolyo Projesi

Selam! Bu proje, statik HTML portfolyo sitelerinin güncelleme zorluklarını aşmak için geliştirilmiş tam kapsamlı bir **Full-Stack Portfolyo ve İçerik Yönetim Sistemi (CMS)** projesidir.

Bu sistem, iki ana bileşenden oluşur:
1.  **Frontend (Ziyaretçi Vitrini):** "Hola" teması üzerine kurulu, ziyaretçilerin gördüğü modern ve dinamik portfolyo sitesi.
2.  **Backend (Yönetim Paneli):** "Ready Dashboard" teması ile hazırlanan, vitrindeki **her bir metni, resmi ve veriyi** yönetmenizi sağlayan özel admin paneli.

Bu proje, bir "Full Stack Developer"ın ihtiyaç duyduğu tüm temel yetkinlikleri (Veritabanı, Backend, Frontend, Sunucu Yönetimi) tek bir potada eritmektedir.

---

## 🛠️ Kullanılan Teknolojiler ve Araçlar

<p align="left">
  <a href="https://dotnet.microsoft.com/en-us/apps/aspnet"><img src="https://img.shields.io/badge/.NET_Core-6.0-512BD4?style=for-the-badge&logo=dotnet" alt=".NET 6"></a>
  <a href="#"><img src="https://img.shields.io/badge/C%23-11.0-9A4993?style=for-the-badge&logo=csharp" alt="C# 11"></a>
  <a href="#"><img src="https://img.shields.io/badge/Entity_Framework-Core-512BD4?style=for-the-badge" alt="EF Core"></a>
  <a href="#"><img src="https://img.shields.io/badge/MS_SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver" alt="SQL Server"></a>
  <a href="#"><img src="https://img.shields.io/badge/MVC-Mimari-blue?style=for-the-badge" alt="MVC"></a>
  <a href="#"><img src="https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap" alt="Bootstrap 5"></a>
  <a href="#"><img src="https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript" alt="JavaScript"></a>
</p>

---

## ✨ Proje Özellikleri

Bu proje, statik bir temayı alıp, onu %100 dinamik, veritabanı kontrollü bir sisteme dönüştürme sürecini kapsar.

### 1. Backend (Yönetim Paneli)

Yönetim paneli, sitenin beynidir. Tüm içerik buradan kontrol edilir.

* **📈 İstatistiksel Dashboard:** Admini karşılayan bu ekran, `Messages`, `Skills`, `Portfolios` gibi tablolardaki verileri anlık olarak sayar ve gösterir.
* **📝 İçerik Yönetimi (CRUD):** "Hakkımda", "Deneyimler", "Yetenekler" gibi tüm bölümler için `Ekle`, `Sil` ve `Güncelle` işlemleri mevcuttur.
* **🚀 Gelişmiş Portfolyo Yönetimi:**
    * Projeleri listeleme, ekleme, silme ve güncelleme.
    * **Gelişmiş Dosya Yükleme:** Proje görselleri için metin-tabanlı yol (path) girme yerine, `IFormFile` arayüzü ile **doğrudan bilgisayardan dosya seçme** özelliği.
    * **Dosya Yönetimi:** Yüklenen görsellere `Guid.NewGuid()` ile benzersiz isimler atanır ve `wwwroot/images/portfolio/` klasörüne kaydedilir.
    * **Otomatik Temizlik:** Bir portfolyo güncellendiğinde, eski görsel sunucudan otomatik olarak silinir.
* **📬 Entegre Gelen Kutusu:** Ziyaretçi sitesindeki "Bana Ulaşın" formundan gönderilen tüm mesajlar (`Messages` tablosu) doğrudan bu panele düşer. "Okundu/Okunmadı" olarak işaretlenebilir.
* **✅ Kişisel Yapılacaklar Listesi:** Adminin kişisel görevlerini yönetebilmesi için özel bir "To-Do List" modülü.

### 2. Frontend (Ziyaretçi Vitrini)

Vitrindeki *hiçbir* veri statik (hard-coded) değildir. Tüm içerik, View Component'ler aracılığıyla canlı olarak veritabanından çekilir.

* **🌐 Tamamen Dinamik Arayüz:** Ana sayfa başlıkları (`Feature`), sosyal medya linkleri (`SocialMedia`), hakkımda metinleri (`About`), yetenek çubukları (`Skill`) ve proje listesi (`Portfolio`)... **Tamamı** admin panelinden yönetilir.
* **🧩 Modüler Tasarım (View Components):** Sayfa, `_FeatureComponentPartial`, `_StatisticComponentPartial`, `_ContactComponentPartial` gibi modüler bileşenlere ayrılmıştır.
* **🔗 Veri Aktarım Stratejileri:**
    * **ViewModel:** "Hero" alanı gibi birden fazla (`Feature` + `SocialMedia`) tabloya ihtiyaç duyan bileşenler için `FeatureViewModel` gibi "taşıyıcı" sınıflar kullanılmıştır.
    * **ViewBag:** İstatistikler gibi ana modelin yanına basit veriler göndermek için `ViewBag`'den yararlanılmıştır.
* **⚡️ Canlı İletişim Formu:** JavaScript (AJAX) çakışmaları çözülerek, ziyaretçinin gönderdiği mesajın doğrudan `DefaultController`'a post edilmesi ve `Messages` tablosuna kaydedilmesi sağlanmıştır.

---

## 📸 Ekran Görüntüleri



### Ziyaretçi Vitrini (Frontend)
<p align="center">
  <img src="/MyPortfolioUdemy/readme-img/SiteAnaSayfa.png" width="400" alt="Ana Sayfa">
</p>

### Yönetim Paneli (Backend)

| İstatistikler & Dashboard | Gelen Mesaj Kutusu |
| :---: | :---: |
| <img src="/MyPortfolioUdemy/readme-img/istatislikAdmin.png" width="400" alt="İstatistikler"> | <img src="/MyPortfolioUdemy/readme-img/MesajlarAdmin.png" width="400" alt="Mesajlar"> |

| Hakkımda Yönetimi | Yapılacaklar Listesi |
| :---: | :---: |
| <img src="/MyPortfolioUdemy/readme-img/hakkımdaAdmin.png" width="400" alt="Hakkımda"> | <img src="/MyPortfolioUdemy/readme-img/YapılacaklarAdmin.png" width="400" alt="Yapılacaklar"> |

| Deneyim Yönetimi | Yetenekler Listesi |
| :---: | :---: |
| <img src="/MyPortfolioUdemy/readme-img/DeneyimlerimAdmin.png" width="400" alt="Deneyim"> | <img src="/MyPortfolioUdemy/readme-img/YeteneklerimAdmin.png" width="400" alt="Yetenekler"> |

---



## 📬 İletişim

Samet Ünverdi – [LinkedIn Profilim](https://www.linkedin.com/in/samet-%C3%BCnverdi-a012ab334/) – sametunv@gmail.com
