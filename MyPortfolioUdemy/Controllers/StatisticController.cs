using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = _context.Skills.Count();
            ViewBag.v2 = _context.Messages.Count();
            ViewBag.v3 = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = _context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.v5 = _context.Experiences.Count();
            ViewBag.v6 =_context.Portfolios.Count();
            ViewBag.v7 = _context.Portfolios.Count(x => !string.IsNullOrEmpty(x.ImageUrl));
            ViewBag.v8 = _context.Testimonials.Count();
            return View();
        }
    }
}
