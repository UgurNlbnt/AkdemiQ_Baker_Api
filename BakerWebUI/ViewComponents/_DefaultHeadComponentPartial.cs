using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
