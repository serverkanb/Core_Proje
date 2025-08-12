using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.Areas.Writer.Controllers
{
    [Area("Writer")]
 
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal(new Context()));
        private readonly UserManager<WriterUser> _usermanager;

        public MessageController(UserManager<WriterUser> usermanager)
        {
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("")]
        [Route("ReceiveMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.TGetListReceiverMessage(p);
            return View(messageList);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.TGetListSenderMessage(p);
            return View(messageList);
        }
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }
        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetById(id);
            return View(writerMessage);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            writerMessageManager.TAdd(p);

            return RedirectToAction("SenderMessage");

        }
    }
}

