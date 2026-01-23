using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.ViewComponents
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
