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
        private readonly IConfiguration _configuration;

        public DashboardController(UserManager<WriterUser> userManeger, IConfiguration configuration)
        {
            _userManeger = userManeger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            
            var value = await _userManeger.FindByNameAsync(User.Identity.Name);
            ViewBag.v = value.Name;

            //Weatherapi
            // Anahtar koda yazılmaz: user-secrets / ortam değişkeni ile "OpenWeather:ApiKey" verilir
            string api = _configuration["OpenWeather:ApiKey"];
            string city = _configuration["OpenWeather:City"] ?? "Ankara";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=tr&units=metric&appid=" + api;
            try
            {
                if (string.IsNullOrEmpty(api))
                {
                    throw new InvalidOperationException("OpenWeather:ApiKey ayarlanmamış");
                }
                XDocument document = XDocument.Load(connection);
                ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            }
            catch
            {
                ViewBag.v5 = "-";
            }

            //Statistics
            Context context = new Context();
            ViewBag.v1 = context.WriterMessages.Where(x => x.Receiver == value.Email).Count();
            ViewBag.v2 = context.Annoucements.Count();
            ViewBag.v3 = context.Users.Count();
            ViewBag.v4 =context.Skills.Count();
            return View();
        }


    }
}
