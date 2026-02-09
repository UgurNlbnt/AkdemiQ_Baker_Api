using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly BakerContext _context;

        public SubscribeController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var subscribe = _context.Subscribes.ToList();
            return Ok(subscribe);
        }

        [HttpPost]
        public IActionResult Post(Subscribe subscribe)
        {
            _context.Subscribes.Add(subscribe);
            _context.SaveChanges();
            return Ok(subscribe);
        }

        [HttpPut]
        public IActionResult Update(Subscribe subscribe)
        {
            _context.Subscribes.Update(subscribe);
            _context.SaveChanges();
            return Ok(subscribe);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var subscribe = _context.Subscribes.Find(id);
            _context.Subscribes.Remove(subscribe);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
