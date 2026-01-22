using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Controllers
{
    [Area("Admin")]
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
