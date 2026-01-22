using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.ViewComponents.UILayoutComponentPartial
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
