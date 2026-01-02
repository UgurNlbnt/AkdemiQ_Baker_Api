using BakerApi.Context;
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
    }
}
