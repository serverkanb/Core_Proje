using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {
        AnnoucementManager _annoucementManager = new AnnoucementManager(new EfAnnoucementDal());
        [Area("Writer")]
        [Authorize]
        public IActionResult Index()
        {
            var values = _annoucementManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AnnoucementDetails(int id)
        {
            var values = _annoucementManager.TGetById(id);
            return View();
        }
    }
}
