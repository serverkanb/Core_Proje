using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.Controllers
{
    public class AdminMessageController : Controller
    {
       
        private readonly WriterMessageManager _writerMessageManager;

        public AdminMessageController(WriterMessageManager messageManager)
        {
            _writerMessageManager = messageManager;
        }

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "test@gmail.com";
            var values = _writerMessageManager.TGetListSenderMessage(p);
            return View();
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "test@gmail.com";
            var values = _writerMessageManager.TGetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = _writerMessageManager.TGetById(id);
            return View(values);    
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var values = _writerMessageManager.TGetById(id);
            _writerMessageManager.TDelete(values);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "test@gmail.com";
            p.SenderName = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }

    }
}
