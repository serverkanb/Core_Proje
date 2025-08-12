using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.Controllers
{
    public class ContactSubplace : Controller
    {
        ContactManager _contacManager = new ContactManager(new EfContactDal());

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contacManager.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contacManager.TUpdate(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
