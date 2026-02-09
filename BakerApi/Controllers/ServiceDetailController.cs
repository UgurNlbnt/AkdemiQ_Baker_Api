using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailController : ControllerBase
    {
        private readonly BakerContext _context;

        public ServiceDetailController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetServiceDetailsWithService()
        {
            var serviceDetails = _context.ServiceDetails.Include(x => x.Service).ToList();
            return Ok(serviceDetails);
        }

        [HttpPost]
        public IActionResult Create(ServiceDetail serviceDetail)
        {
            _context.ServiceDetails.Add(serviceDetail);
            _context.SaveChanges();
            return Ok("Servis Detayı güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public IActionResult Update(ServiceDetail serviceDetail)
        {
            _context.ServiceDetails.Update(serviceDetail);
            _context.SaveChanges();
            return Ok("Servis Detayı güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.ServiceDetails.Find(id);
            _context.ServiceDetails.Remove(value);
            _context.SaveChanges();
            return Ok("Servis Detayı silme işlemi başarılı bir şekilde gerçekleşti");
        }
    }
}
