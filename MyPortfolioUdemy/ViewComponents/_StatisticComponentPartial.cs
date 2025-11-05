using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _StatisticComponentPartial :ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.s1 = _context.Skills.Count();
            ViewBag.s2 = _context.Messages.Count();        
            ViewBag.s3 = _context.Experiences.Count();
            ViewBag.s4 = _context.Portfolios.Count();           
            return View();
        }
    }
}
