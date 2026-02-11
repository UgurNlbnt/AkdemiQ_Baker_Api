using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
