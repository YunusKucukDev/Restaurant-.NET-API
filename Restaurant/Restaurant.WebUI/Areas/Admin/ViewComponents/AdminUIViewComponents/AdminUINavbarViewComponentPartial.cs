using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Areas.Admin.ViewComponents.AdminUIViewComponents
{
    public class AdminUINavbarViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
