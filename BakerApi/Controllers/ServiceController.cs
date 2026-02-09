using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly BakerContext _context;
        public ServiceController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAboutWithServiceDetailsList()
        {
            var abouts = _context.Services.Include(x => x.ServiceDetails).ToList();
            return Ok(abouts);
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Servis ekleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public IActionResult Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Servis güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Servis silme işlemi başarılı bir şekilde gerçekleşti");
        }
    }
}
