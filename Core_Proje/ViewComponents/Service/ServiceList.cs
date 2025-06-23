using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        ServiceManager servisManager = new ServiceManager(new EfServiceDal());
        public IViewComponentResult Invoke()
        {
            var values = servisManager.TGetList();
            return View(values);
        }
    }
}
