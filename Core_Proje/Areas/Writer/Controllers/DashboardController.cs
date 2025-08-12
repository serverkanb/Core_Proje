using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManeger;

        public DashboardController(UserManager<WriterUser> userManeger)
        {
            _userManeger = userManeger;
        }

        public async Task<IActionResult> Index()
        {
            
            var value = await _userManeger.FindByNameAsync(User.Identity.Name);
            ViewBag.v = value.Name;

            //Weatherapi
            string api = "682cce73042cf7c8adc013d65c5f9b08";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Ankara&mode=xml&lang=tr&units=metric&appid=" + api; ;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //Statistics
            Context context = new Context();
            ViewBag.v1 = context.WriterMessages.Where(x => x.Receiver == value.Email).Count();
            ViewBag.v2 = context.Annoucements.Count();
            ViewBag.v3 = context.Users.Count();
            ViewBag.v4 =context.Skills.Count();
            return View();
        }
        ////https://api.openweathermap.org/data/2.5/weather?q=Ankara&mode=xml&lang=tr&units=metric&appid=682cce73042cf7c8adc013d65c5f9b08


    }
}
