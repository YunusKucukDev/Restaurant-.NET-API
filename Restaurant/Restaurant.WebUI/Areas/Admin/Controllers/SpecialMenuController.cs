using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.MenuDtos.SpecialMenuDtos;
using Restaurant.WebUI.Services.Catalog.SpecialMenuService;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialMenu")]
    public class SpecialMenuController : Controller
    {
        private readonly ISpecialMenuService _specialMenuService;

        public SpecialMenuController(ISpecialMenuService specialMenuService)
        {
            _specialMenuService = specialMenuService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _specialMenuService.GetAllspecialMenus();
            return View(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSpecialmenu(string id)
        {
            var values = await _specialMenuService.GetByIdSpecialMenu(id);
            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialMenu")]
        public IActionResult CreateSpecialMenu()
        {
            return View(new CreateSpecialMenuDtos
            {
                IsAvailable = true
            });
        }

        [HttpPost]
        [Route("CreateSpecialMenu")]
        public async Task<IActionResult> CreateSpecialMenu(CreateSpecialMenuDtos createSpecialMenuDtos)
        {
            await _specialMenuService.CreateSpecialMenu(createSpecialMenuDtos);
            return RedirectToAction("Index", "SpecialMenu");
        }

        [HttpGet]
        [Route("UpdateSpecialMenu/{id}")]
        public async Task<IActionResult> UpdateSpecialMenu(string id)
        {
            var values = await _specialMenuService.GetByIdSpecialMenu(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateSpecialMenu/{id}")]
        public async Task<IActionResult> UpdateSpecialMenu(UpdateSpecialMenuDtos updateSpecialMenuDtos)
        {
            await _specialMenuService.UpdateSpecialMenu(updateSpecialMenuDtos);
            return RedirectToAction("Index", "SpecialMenu");
        }

        [HttpDelete("{id}")]
        [Route("DeleteSpecialMenu/{id}")]
        public async Task<IActionResult> DeleteSpecialMenu(string id)
        {
            await _specialMenuService.DeleteSpecialMenu(id);
            return RedirectToAction("Index", "SpecialMenu");
        }
    }
    }
