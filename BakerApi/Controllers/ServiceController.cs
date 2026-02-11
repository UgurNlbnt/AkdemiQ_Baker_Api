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
    public class ServiceController : ControllerBase
    {
        private readonly BakerContext _context;
        public ServiceController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet("with_Details")]
        public IActionResult GetAboutWithServiceDetailsList()
        {
            var abouts = _context.Services.Include(x => x.ServiceDetails).Select(z=> new ServiceWithServiceDetailsDto
            {
                ServiceId = z.ServiceId,
                Title = z.Title,
                Description = z.Description,
                ImageUrl = z.ImageUrl,
                ServiceDetails = z.ServiceDetails.Select(y => new ServiceDetailDto
                {
                    Title = y.Title,
                    Description = y.Description
                }).ToList()
            }).ToList();
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
