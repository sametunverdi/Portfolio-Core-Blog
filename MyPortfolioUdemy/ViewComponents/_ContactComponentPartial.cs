using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioUdemy.DAL.Context;


namespace MyPortfolioUdemy.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
