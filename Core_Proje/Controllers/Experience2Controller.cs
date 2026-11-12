using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace My_Core_Proje_.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager _experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(_experienceManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            p.ImageUrl ??= "";
            _experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);    
        }
        [HttpGet]
        public IActionResult GetById(int ExperienceId)
        {
            var value = _experienceManager.TGetById(ExperienceId);
            var value2 = JsonConvert.SerializeObject(value);
            return Json(value2);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience p)
        {
            var value = _experienceManager.TGetById(p.ExperienceId);
            if (value == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(p.Name)) value.Name = p.Name;
            if (!string.IsNullOrEmpty(p.Date)) value.Date = p.Date;
            _experienceManager.TUpdate(value);
            var values2 = JsonConvert.SerializeObject(p);
            return Json(values2);
        }
        
        [HttpPost]
        public IActionResult DeleteExperience(int id)
        {
            var value = _experienceManager.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            _experienceManager.TDelete(value);
            return NoContent();
        }
    }
}
