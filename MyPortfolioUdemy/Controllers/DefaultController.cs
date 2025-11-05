using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities; // <-- Message sınıfın için
using System;

namespace MyPortfolioUdemy.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            // Formdaki name'ler (NameSurname vb.) eşleştiği sürece
            // 'message' nesnesi dolu gelecek.

            message.SendDate = DateTime.Now;
            message.IsRead = false;

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction("Index"); // Ana sayfaya geri dön
        }
    }
}
