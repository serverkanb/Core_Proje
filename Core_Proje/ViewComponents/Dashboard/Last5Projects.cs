using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class Last5Projects : ViewComponent
    {
        PortfolioManager _portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = _portfolioManager.TGetList().OrderBy(x =>x.PortfolioId).Take(3).ToList();
            return View();
        }
    }
}
