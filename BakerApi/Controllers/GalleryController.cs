using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly BakerContext _context;

        public GalleryController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var galleries = _context.Galleries.ToList();
            return Ok(galleries);
        }

        [HttpGet("{id}")]
        public IActionResult GetGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(Gallery gallery)
        {
            _context.Galleries.Add(gallery);
            _context.SaveChanges();
            return Ok("Resim ekleme işlemi başarılı bir şekilde gerçekleşti");
        }


        [HttpPut]
        public IActionResult Update(Gallery gallery)
        {
            _context.Galleries.Update(gallery);
            _context.SaveChanges();
            return Ok("Resim güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Galleries.Find(id);
            _context.Galleries.Remove(value);
            _context.SaveChanges();
            return Ok("Resim silme işlemi başarılı bir şekilde gerçekleşti");
        }
    }
}
