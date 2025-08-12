using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.Controllers
{
    public class TestimonialController : Controller
    {
        TestimOnialManager _testimOnialManager = new TestimOnialManager(new EfTestimOnialDal());
        public IActionResult Index()
        {
            var values = _testimOnialManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(TestimOnial p)
        {
            _testimOnialManager.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
           var value = _testimOnialManager.TGetById(id);
            _testimOnialManager.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTestimonial(int Id)
        {
            var values = _testimOnialManager.TGetById(Id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTestimonial(TestimOnial testimonial)
        {
            _testimOnialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
    }
}
