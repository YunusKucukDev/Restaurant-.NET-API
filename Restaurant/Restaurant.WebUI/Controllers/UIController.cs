using Microsoft.AspNetCore.Mvc;

namespace Restaurant.WebUI.Controllers
{
   
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
