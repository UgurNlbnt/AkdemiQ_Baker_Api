using BakerApi.Context;
using BakerApi.Dto;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly BakerContext _context;
        public AboutController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet("With_Details")]
        public IActionResult GetAboutWithAboutDetailsList()
        {
            var abouts = _context.Abouts.Include(x => x.AboutDetails).Select(x => new AboutWithAboutDetailsDto
            {
                AboutId = x.AboutId,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                DetailDescription = x.AboutDetails.Select(y => y.Description).ToList()
            }).ToList();
            return Ok(abouts);
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return Ok("Hakkımızda ekleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public IActionResult Update(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return Ok("Hakkımızda güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Hakkımızda silme işlemi başarılı bir şekilde gerçekleşti");
        }

    }
}
