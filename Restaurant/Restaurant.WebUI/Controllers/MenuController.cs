using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.CategoryService;

namespace Restaurant.WebUI.Controllers
{
    public class MenuController : Controller
    {

        private readonly ICategoryService _categoryService;

        public MenuController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult>  Index()
        {
            var menu = await _categoryService.GetMenuAsync();
            return View(menu);
        }
    }
}
