using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnoucementManager _annoucementManager = new AnnoucementManager(new EfAnnoucementDal());
        public IViewComponentResult Invoke()
        {
            var values = _annoucementManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
