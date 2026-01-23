using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.ViewComponents
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
