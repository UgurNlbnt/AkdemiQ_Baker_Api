using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
