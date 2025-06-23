using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutDal());

        public IActionResult Index()
        {
            var values = _aboutManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            ViewBag.v1 = "Hakkımda Ekleme";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Yeni Hakkımda Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutManager.TAdd(about);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            ViewBag.v1 = "Hakkımda Güncelleme";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Düzenle";
            var value = _aboutManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            _aboutManager.TUpdate(about);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutManager.TGetById(id);
            _aboutManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
