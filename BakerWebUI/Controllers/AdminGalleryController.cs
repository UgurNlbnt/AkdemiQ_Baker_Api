using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminGalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
