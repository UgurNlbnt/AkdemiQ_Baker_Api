using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressInfoController : ControllerBase
    {
        private readonly BakerContext _context;

        public AddressInfoController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAddressInfo()
        {
            var addressInfo = _context.AdressInfos.FirstOrDefault();
            return Ok(addressInfo);
        }

        [HttpPost]
        public IActionResult Create(AdressInfo addressInfo)
        {
            _context.AdressInfos.Add(addressInfo);
            _context.SaveChanges();
            return Ok("Adres Bilgisi Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult Update(AdressInfo adressInfo)
        {
            _context.AdressInfos.Update(adressInfo);
            _context.SaveChanges();
            return Ok("Adres Bilgisi Başarıyla Güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var addressInfo = _context.AdressInfos.Find(id);
            _context.AdressInfos.Remove(addressInfo);
            _context.SaveChanges();
            return Ok("Adres Bilgisi Başarıyla Silindi");
        }


    }
}
