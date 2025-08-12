using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.Controllers
{
    public class AdminContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values = _messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var value = _messageManager.TGetById(id);
            _messageManager.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult ContactDetails(int id)
        {
            var values = _messageManager.TGetById(id);
            return View(values);
        }
    }
}
