using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {

        ServiceManager _serviceManager = new ServiceManager(new EfServiceDal());

        public IActionResult Index()
        {
            //ViewBag.v1 = "Hizmetler";
            //ViewBag.v2 = "Hizmet Bilgileri";
            //ViewBag.v3 = "Hizmet Listeleme Sayfası";
            var values = _serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            //ViewBag.v1 = "Hizmet Ekleme";
            //ViewBag.v2 = "Hizmetler";
            //ViewBag.v3 = "Yeni Hizmet Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            //ViewBag.v1 = "Hizmet Güncelleme";
            //ViewBag.v2 = "Hizmetler";
            //ViewBag.v3 = "Hizmet Düzenle";
            _serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var value = _serviceManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var value = _serviceManager.TGetById(id);
            _serviceManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }

}
