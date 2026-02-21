using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Catalog.ProductService;
using System.Threading.Tasks;

namespace Restaurant.WebUI.ViewComponents.FavoriteProductsComponentPartial
{
    public class FavoriteProductsComponentPartial : ViewComponent
    {

        private readonly IProductService _productService;

        public FavoriteProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllProducts();
            var favoriteProduct = products.Where(x => x.IsFavorite == true).ToList();
            return View(favoriteProduct);
        }



    }
}
