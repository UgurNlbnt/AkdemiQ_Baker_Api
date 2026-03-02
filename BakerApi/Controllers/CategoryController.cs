using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BakerContext _context;

        public CategoryController(BakerContext context)
        {
            _context = context;
        }

        // TÜM LİSTE
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        // ID'YE GÖRE GETİR (EKLENDİ)
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
                return NotFound();

            return Ok(value);
        }

        // EKLE
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok();
        }

        // GÜNCELLE
        [HttpPut]
        public IActionResult Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok();
        }

        // SİL (ROUTE DÜZELTİLDİ)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
                return NotFound();

            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok();
        }
    }
}