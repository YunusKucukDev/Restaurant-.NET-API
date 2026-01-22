using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.ViewComponents.UILayoutComponentPartial
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
