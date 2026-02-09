using BakerApi.Context;
using BakerApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly BakerContext _context;

        public ContactController(BakerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Mesajınız başarıyla gönderildi");
        }

        [HttpPut]
        public IActionResult Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Mesajınız başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Mesajınız başarıyla silindi");
        }
    }
}
