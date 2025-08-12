using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SocialMediaController : Controller
    {

        SocialMediaManager _socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());

        public IActionResult Index()
        {
            //ViewBag.v1 = "Sosyal Medyalar";
            //ViewBag.v2 = "Sosyal Medya Bilgileri";
            //ViewBag.v3 = "Sosyal Medya Listeleme Sayfası";
            var values = _socialMediaManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            //ViewBag.v1 = "Sosyal Medya Ekleme";
            //ViewBag.v2 = "Sosyal Medyalar";
            //ViewBag.v3 = "Yeni Sosyal Medya Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            //ViewBag.v1 = "Sosyal Medya Güncelleme";
            //ViewBag.v2 = "Sosyal Medyalar";
            //ViewBag.v3 = "Sosyal Medya Düzenle";
            var value = _socialMediaManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaManager.TGetById(id);
            _socialMediaManager.TDelete(value);
            return RedirectToAction("Index");
        }




    }
}
