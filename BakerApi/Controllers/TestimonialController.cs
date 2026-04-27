using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly BakerContext _context;
        public TestimonialController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTestimonialList()
        {
            var testimonials = _context.Testimonials.ToList();
            return Ok(testimonials);
        }

        [HttpGet("CountTestimonial")]
        public IActionResult GetCountTestimonial()
        {
            var totalTestimonial = _context.Testimonials.Count();
            return Ok(totalTestimonial);
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Yorum ekleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public IActionResult Update(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Yorum güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum silme işlemi başarılı bir şekilde gerçekleşti");
        }
    }
}
