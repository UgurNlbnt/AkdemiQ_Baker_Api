using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
