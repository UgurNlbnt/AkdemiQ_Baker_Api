using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly BakerContext _context;
        public ChefController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetChefsList()
        {
            var chefs = _context.Chefs.ToList();
            return Ok(chefs);
        }

        [HttpPost]
        public IActionResult Create(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Şef ekleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public IActionResult Update(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Şef güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Şef silme işlemi başarılı bir şekilde gerçekleşti");
        }
    }
}
