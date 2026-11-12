using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AnnoucementController : Controller
    {
        AnnoucementManager _annoucementManager = new AnnoucementManager(new EfAnnoucementDal());

        public IActionResult Index()
        {
            var values = _annoucementManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnoucement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnoucement(Annoucement annoucement)
        {
            if (string.IsNullOrEmpty(annoucement.Date))
            {
                annoucement.Date = DateTime.Now.ToShortDateString();
            }
            _annoucementManager.TAdd(annoucement);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAnnoucement(int id)
        {
            var value = _annoucementManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAnnoucement(Annoucement annoucement)
        {
            _annoucementManager.TUpdate(annoucement);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnoucement(int id)
        {
            var value = _annoucementManager.TGetById(id);
            _annoucementManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
