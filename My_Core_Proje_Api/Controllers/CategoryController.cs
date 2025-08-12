using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Core_Proje_Api.DAL.ApiContext;
using My_Core_Proje_Api.DAL.Entity;

namespace My_Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
           
            return Ok(_context.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
           
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(CategoryController p)
        { 
            _context.Add(p);
            _context.SaveChanges();
            return Created("",p);
        }
        [HttpPut]
        public IActionResult CategoryDelete(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(value);
                _context.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            var value = _context.Find<Category>(p.CategoryId);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName = p.CategoryName;
                _context.Update(value);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}