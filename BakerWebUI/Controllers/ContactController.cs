using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
