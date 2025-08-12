using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DashboardController : Controller
    {
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            //ViewBag.v1 = "DashBoard";
            //ViewBag.v2 = "İstatistikler";
            //ViewBag.v3 = "İstatistikler Sayfası";
            return View();
        }
    }
}
