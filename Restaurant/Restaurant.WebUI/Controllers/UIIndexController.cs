using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class UIIndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
