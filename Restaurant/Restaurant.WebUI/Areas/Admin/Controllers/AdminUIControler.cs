using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUIControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
