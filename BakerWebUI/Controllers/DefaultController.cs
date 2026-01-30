using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
