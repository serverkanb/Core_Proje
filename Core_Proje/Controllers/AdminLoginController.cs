using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly UserManager<WriterUser> _userManager;

        public AdminLoginController(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p, string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            var user = await _userManager.FindByNameAsync(p.Username);
            if (user == null || !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                ModelState.AddModelError("", "Hatalı kullanıcı adı/şifre ya da bu kullanıcının admin yetkisi yok");
                return View(p);
            }

            var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.IsLockedOut ? "Çok fazla hatalı deneme, hesap geçici olarak kilitlendi" : "Hatalı kullanıcı adı ya da şifre");
                return View(p);
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
