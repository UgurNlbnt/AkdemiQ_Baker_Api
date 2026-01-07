using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly BakerContext _context;
        public FeatureController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var features = _context.Features.ToList();
            return Ok(features);
        }

        [HttpPost]
        public IActionResult Create(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Özellik ekleme işlemi başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public IActionResult Update(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Özellik güncelleme işlemi başarılı bir şekilde gerçekleşti");
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Özellik silme işlemi başarılı bir şekilde gerçekleşti");
        }
    }
}
