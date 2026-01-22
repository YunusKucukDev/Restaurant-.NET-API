using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Models;

namespace Restaurant.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
