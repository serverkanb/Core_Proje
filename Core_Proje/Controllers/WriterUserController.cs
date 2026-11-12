using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace My_Core_Proje_.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager userManager = new WriterUserManager(new EfWriterUserDal());
        private readonly UserManager<WriterUser> _identityUserManager;

        public WriterUserController(UserManager<WriterUser> identityUserManager)
        {
            _identityUserManager = identityUserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUser()
        {
            // Sadece gerekli alanlar: PasswordHash vb. tarayıcıya gönderilmez
            var values = JsonConvert.SerializeObject(userManager.TGetList().Select(x => new
            {
                x.Id,
                x.Name,
                x.Surname,
                x.UserName,
                x.Email,
                x.ImageUrl
            }));
            return Json(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(WriterUser p, string password)
        {
            p.ImageUrl ??= "";
            // Identity üzerinden oluşturulur ki şifre hash'lensin ve kullanıcı giriş yapabilsin
            var result = await _identityUserManager.CreateAsync(p, password ?? "");
            if (!result.Succeeded)
            {
                return BadRequest(string.Join(" ", result.Errors.Select(x => x.Description)));
            }
            var values = JsonConvert.SerializeObject(new { p.Id, p.Name, p.Surname, p.UserName, p.Email });
            return Json(values);
        }
    }
}
