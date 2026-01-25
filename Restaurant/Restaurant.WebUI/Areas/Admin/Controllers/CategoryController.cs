using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.MenuDtos.CategoryDtos;
using Restaurant.DtoLayer.CatalogDtos.MenuDtos.ProductDtos;
using Restaurant.WebUI.Services.Catalog.CategoryService;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllCategories();
            return View(values);
        }

        [HttpGet]
        [Route("GetByIdCategory/{id}")]
        public async Task<IActionResult> GetByIdCategory(string id)
        {
            var values = await _categoryService.GetByIdCategory(id);
            return View();
        }

        

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            return View(new CreateCategoryDto
            {
                IsActive= true
            });
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategory(createCategoryDto);
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var values = await _categoryService.GetByIdCategory(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategory(updateCategoryDto);
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}
