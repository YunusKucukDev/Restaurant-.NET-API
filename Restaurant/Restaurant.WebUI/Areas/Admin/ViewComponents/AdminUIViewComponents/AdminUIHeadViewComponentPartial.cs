using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Areas.Admin.ViewComponents.AdminUIViewComponents
{
    public class AdminUIHeadViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
