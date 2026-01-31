using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Aboutservice;
using Restaurant.WebUI.Services.Catalog.AboutService;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {

        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutService.GetAllAbouts();
            return View(abouts);
        }

        [HttpGet("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var about = await _aboutService.GetByIdAbotDto(id);
            return View(about);
        }

        [HttpPost("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutDto(updateAboutDto);
            return RedirectToAction("Index");
        }

    }
}

