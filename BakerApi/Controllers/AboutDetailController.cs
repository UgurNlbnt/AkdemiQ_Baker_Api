using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutDetailController : ControllerBase
    {
        private readonly BakerContext _context;

        public AboutDetailController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAboutDetails()
        {
            var aboutDetails = _context.AboutDetails.Include(x=>x.About).ToList();
            return Ok(aboutDetails);
        }

        [HttpPost]
        public IActionResult AddAboutDetail(AboutDetail aboutDetail)
        {
            _context.AboutDetails.Add(aboutDetail);
            _context.SaveChanges();
            return Ok(aboutDetail);
        }

        [HttpPut]
        public IActionResult Update(AboutDetail aboutDetail)
        {
            _context.AboutDetails.Update(aboutDetail);
            _context.SaveChanges();
            return Ok("Hakkımızda Detayı güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.AboutDetails.Find(id);
            _context.AboutDetails.Remove(value);
            _context.SaveChanges();
            return Ok("Hakkımızda Detayı silme işlemi başarılı bir şekilde gerçekleşti");
        }
    }
}
