using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {   
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
