using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Catalog.Dtos.SpecialMenuDtos;
using Restaurant.Catalog.Services.SpecialMenuService;

namespace Restaurant.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialMenusController : ControllerBase
    {

        private readonly ISpecialMenuService _specialMenuService;
        public SpecialMenusController(ISpecialMenuService specialMenuService)
        {
            _specialMenuService = specialMenuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialMenus()
        {
            var result = await _specialMenuService.GetSpecialMenusAsync();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialMenuById(string id)
        {
            var result = await _specialMenuService.GetByIdSpecialMenuAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialMenu(CreateSpecialMenuDto createSpecialMenuDto)
        {
            await _specialMenuService.CreateSpecialMenuAsync(createSpecialMenuDto);
            return Ok("succesfull");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialMenu(UpdateSpecialMenuDto updateSpecialMenuDto)
        {
            await _specialMenuService.UpdateSpecialMenuAsync(updateSpecialMenuDto);
            return Ok("succesfull");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialMenu(string id)
        {
            await _specialMenuService.DeleteSpecialMenuAsync(id);
            return Ok("succesfull");
        }


    }

}
