using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.ViewComponents.UILayoutComponentPartial
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
