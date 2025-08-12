using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context _contex = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _contex.Skills.Count();
            ViewBag.v2 = _contex.Messages.Where(x=>x.Status == false).Count();
            ViewBag.v3 = _contex.Messages.Where(x=>x.Status == true).Count();
            ViewBag.v4 = _contex.Experiences.Count();
            return View();
        }
    }
}
