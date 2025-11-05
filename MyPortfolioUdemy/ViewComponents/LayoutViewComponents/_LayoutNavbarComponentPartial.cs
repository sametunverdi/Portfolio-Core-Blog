using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.todoListCount = _context.ToDoLists.Where(x => x.Status == false).Count();
            var values = _context.ToDoLists.Where(x => x.Status == false).ToList();
            return View(values);
        }
    }
}
