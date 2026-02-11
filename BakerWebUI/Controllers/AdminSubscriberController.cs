using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminSubscriberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
