using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Areas.Admin.ViewComponents.AdminUIViewComponents
{
    public class AdminUIScriptsViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
