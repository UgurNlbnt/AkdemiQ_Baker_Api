using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
