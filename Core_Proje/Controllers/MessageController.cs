using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());

        public IActionResult Index()
        {
            //ViewBag.v1 = "Mesajlar";
            //ViewBag.v2 = "Mesaj Bilgileri";
            //ViewBag.v3 = "Mesaj Listeleme Sayfası";
            var values = _messageManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMessage(Message message)
        {
            //ViewBag.v1 = "Mesaj Ekleme";
            //ViewBag.v2 = "Mesajlar";
            //ViewBag.v3 = "Yeni Mesaj Ekle";
            _messageManager.TAdd(message);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditMessage(int id)
        {
            var value = _messageManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditMessage(Message message)
        {
            //ViewBag.v1 = "Mesaj Güncelleme";
            //ViewBag.v2 = "Mesajlar";
            //ViewBag.v3 = "Mesaj Düzenle";

            _messageManager.TUpdate(message);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _messageManager.TGetById(id);
            _messageManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
