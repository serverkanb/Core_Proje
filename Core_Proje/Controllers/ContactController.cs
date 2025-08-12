using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContactDal());

        public IActionResult Index()
        {
            //ViewBag.v1 = "İletişim";
            //ViewBag.v2 = "İletişim Bilgileri";
            //ViewBag.v3 = "İletişim Listeleme Sayfası";
            var values = _contactManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            //ViewBag.v1 = "İletişim Ekleme";
            //ViewBag.v2 = "İletişimler";
            //ViewBag.v3 = "Yeni İletişim Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactManager.TAdd(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditContact(int id)
        {
            //ViewBag.v1 = "İletişim Güncelleme";
            //ViewBag.v2 = "İletişimler";
            //ViewBag.v3 = "İletişim Düzenle";
            var value = _contactManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            _contactManager.TUpdate(contact);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContact(int id)
        {
            var value = _contactManager.TGetById(id);
            _contactManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
