using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult NewSideBar()
        {
            return PartialView();
        }
    }
}
