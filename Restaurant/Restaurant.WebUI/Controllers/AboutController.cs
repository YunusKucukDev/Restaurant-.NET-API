using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.AboutService;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAbouts();
            return View(values);
        }
    }
}
