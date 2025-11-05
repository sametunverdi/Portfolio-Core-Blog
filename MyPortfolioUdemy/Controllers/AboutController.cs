using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities; // Bu 'using' satırını ekle
using System.Linq;                 // Bu 'using' satırını ekle

namespace MyPortfolioUdemy.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();

        
        [HttpGet]
        public IActionResult Index()
        {
            
            var value = _context.Abouts.Find(1);          
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About about) 
        {
         
            _context.Abouts.Update(about);
            _context.SaveChanges();    
            return RedirectToAction("Index");
        }
    }
}