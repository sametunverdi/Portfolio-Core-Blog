// Adım 3'te eklenen 'using' satırları
using Microsoft.AspNetCore.Hosting; // wwwroot yolunu bulmak için
using System.IO;                  // Dosya işlemleri (Path, FileStream) için
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class PortfolioController : Controller
    {
        // --- DEĞİŞİKLİK 1: 'new' ile oluşturmak yerine servisleri alıyoruz ---
        private readonly MyPortfolioContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // "Constructor" (Yapıcı Metot) - Bu metot, servisleri otomatik olarak alır.
        public PortfolioController(MyPortfolioContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // --- 'Index' metodun aynı kalıyor ---
        public IActionResult Index()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }

        // --- 'HttpGet CreatePortfolio' metodun aynı kalıyor ---
        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            return View();
        }

        // --- DEĞİŞİKLİK 2: 'HttpPost CreatePortfolio' metodu güncellendi ---
        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            // 1. Kullanıcı bir resim seçti mi? (ImageFile null değil mi?)
            if (portfolio.ImageFile != null)
            {
                // 2. wwwroot klasörünün fiziksel yolunu al (Örn: C:\Projem\wwwroot)
                var wwwRootPath = _webHostEnvironment.WebRootPath;

                // 3. Benzersiz bir dosya adı oluştur (Çakışmaları önlemek için)
                // Örn: 8a5f1b2c-4d3e-4f5a-b6c7-d8e9f0a1b2c3.jpg
                var extension = Path.GetExtension(portfolio.ImageFile.FileName); // .jpg veya .png
                var newImageName = Guid.NewGuid() + extension;

                // 4. Dosyanın kaydedileceği tam konumu belirle
                // (wwwroot/images/portfolio/ klasörünün var olduğundan emin ol)
                // Eğer "portfolio" klasörün yoksa, lütfen wwwroot/images içine "portfolio" adında bir klasör oluştur.
                var location = Path.Combine(wwwRootPath, "images/portfolio/", newImageName);

                // 5. Dosyayı o konuma kaydet (kopyala)
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    portfolio.ImageFile.CopyTo(stream);
                }

                // 6. Veritabanına kaydedilecek URL yolunu ayarla (ÇOK ÖNEMLİ)
                // Bu, senin Index sayfanın kullandığı yoldur.
                portfolio.ImageUrl = "/images/portfolio/" + newImageName;
            }

            // 7. Her şey hazır, veritabanına ekle
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            _context.Portfolios.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            return View(value);
        }
       
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            // 1. Güncellenecek olan asıl kaydı veritabanından buluyoruz
            //    (Bu, EF'nin değişikliği izlemesi için en güvenli yoldur)
            var portfolioToUpdate = _context.Portfolios.Find(portfolio.PortfolioId);
            if (portfolioToUpdate == null)
            {
                return NotFound(); // Eğer kayıt bulunamazsa (hata durumu)
            }

            // 2. Kullanıcı YENİ bir resim yükledi mi? (ImageFile null değil mi?)
            if (portfolio.ImageFile != null)
            {
                // YENİ RESİM VARSA:

                // a. ESKİ resmin yolunu (silmek için) bir kenara alıyoruz
                var oldImagePath = portfolioToUpdate.ImageUrl;
                var wwwRootPath = _webHostEnvironment.WebRootPath;

                // b. YENİ resmi 'Create' işlemindeki gibi sunucuya kaydediyoruz
                var extension = Path.GetExtension(portfolio.ImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(wwwRootPath, "images/portfolio/", newImageName);

                using (var stream = new FileStream(location, FileMode.Create))
                {
                    portfolio.ImageFile.CopyTo(stream);
                }

                // c. Veritabanındaki kaydın 'ImageUrl'ini YENİ resmin yoluyla güncelliyoruz
                portfolioToUpdate.ImageUrl = "/images/portfolio/" + newImageName;

                // d. ESKİ resmi sunucudan siliyoruz (boşuna yer kaplamasın)
                if (!string.IsNullOrEmpty(oldImagePath))
                {
                    var oldFileLocation = Path.Combine(wwwRootPath, oldImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFileLocation))
                    {
                        System.IO.File.Delete(oldFileLocation);
                    }
                }
            }

            // 3. YENİ BİR RESİM YÜKLENMEDİYSE?
            //    Hiçbir şey yapmıyoruz. 'portfolioToUpdate.ImageUrl' 
            //    zaten veritabanındaki eski yolu koruyor.

            // 4. Formdan gelen diğer metin bilgilerini güncelliyoruz
            portfolioToUpdate.Title = portfolio.Title;
            portfolioToUpdate.SubTitle = portfolio.SubTitle;
            portfolioToUpdate.Url = portfolio.Url;
            portfolioToUpdate.Description = portfolio.Description;

            // 5. Değişiklikleri veritabanına kaydediyoruz
            _context.SaveChanges();

            // 6. Listeleme sayfasına geri yönlendiriyoruz
            return RedirectToAction("Index");
        }
    }
}