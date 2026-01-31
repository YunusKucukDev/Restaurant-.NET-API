using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Catalog.Dtos.About;
using Restaurant.Catalog.Services.AboutService;

namespace Restaurant.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {

        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbouts()
        {
            var values = await _aboutService.GetAllAbouts();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(string id)
        {
            var values = await _aboutService.GetByIdAbotDto(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutDto(createAboutDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutDto(updateAboutDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutDto(id);
            return Ok();
        }
    }
}