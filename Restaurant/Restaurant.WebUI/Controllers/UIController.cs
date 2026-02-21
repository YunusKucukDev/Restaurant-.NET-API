using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class UIController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
