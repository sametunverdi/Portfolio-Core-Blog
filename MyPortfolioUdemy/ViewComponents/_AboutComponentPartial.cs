using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.abouttitle = _context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutsubdescription = _context.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutdetail = _context.Abouts.Select(x => x.Details).FirstOrDefault();
            return View();
        }
    }
}
