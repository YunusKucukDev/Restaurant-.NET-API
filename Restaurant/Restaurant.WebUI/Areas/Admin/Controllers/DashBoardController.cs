using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
