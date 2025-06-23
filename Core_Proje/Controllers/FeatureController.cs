using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager _featureManager = new FeatureManager(new EfFeatureDal());

        public IActionResult Index()
        {
            var values = _featureManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            ViewBag.v1 = "Özellik Ekleme";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Yeni Özellik Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(Feature feature)
        {
            _featureManager.TAdd(feature);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            ViewBag.v1 = "Özellik Güncelleme";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Özellik Düzenle";
            var value = _featureManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
            _featureManager.TUpdate(feature);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFeature(int id)
        {
            var value = _featureManager.TGetById(id);
            _featureManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
