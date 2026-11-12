using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
       
        private readonly IWriterMessageService _writerMessageManager;
        private readonly UserManager<WriterUser> _userManager;

        public AdminMessageController(IWriterMessageService messageManager, UserManager<WriterUser> userManager)
        {
            _writerMessageManager = messageManager;
            _userManager = userManager;
        }

        // Giriş yapan adminin mail adresi (önceden "test@gmail.com" olarak sabitti)
        private async Task<WriterUser> GetAdminAsync()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name);
        }

        public async Task<IActionResult> ReceiverMessageList()
        {
            string p = (await GetAdminAsync()).Email;
            var values = _writerMessageManager.TGetListReceiverMessage(p);
            return View(values);
        }
        public async Task<IActionResult> SenderMessageList()
        {
            string p = (await GetAdminAsync()).Email;
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
        public async Task<IActionResult> AdminMessageSend(WriterMessage p)
        {
            var admin = await GetAdminAsync();
            p.Sender = admin.Email;
            p.SenderName = (admin.Name + " " + admin.Surname).Trim();
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }

    }
}
