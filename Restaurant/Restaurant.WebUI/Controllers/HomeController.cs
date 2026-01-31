using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Models;

namespace Restaurant.WebUI.Controllers
{
    [Route("/Home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
