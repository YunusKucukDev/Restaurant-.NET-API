using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.MenuDtos.ProductDtos;
using Restaurant.WebUI.Services.Catalog.ProductService;
using Restaurant.WebUI.Services.Catalog.CategoryService;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // ------------------ LIST ------------------
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllProducts();
            return View(values);
        }

        // ------------------ CREATE GET ------------------
        [HttpGet("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategories();

            ViewBag.CategoryList = categories
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId
                })
                .ToList();

            return View(new CreateProductDto
            {
                IsAvailable = true
            });
        }

        // ------------------ CREATE POST ------------------
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProduct(createProductDto);
            return RedirectToAction("Index");
        }

        // ------------------ UPDATE GET ------------------
        [HttpGet("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var product = await _productService.GetByIdProduct(id);
            var categories = await _categoryService.GetAllCategories();

            ViewBag.CategoryList = categories
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryId
                })
                .ToList();

            return View(product);
        }

        // ------------------ UPDATE POST ------------------
        [HttpPost("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProduct(updateProductDto);
            return RedirectToAction("Index");
        }

        // ------------------ DELETE ------------------
        [HttpGet("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
