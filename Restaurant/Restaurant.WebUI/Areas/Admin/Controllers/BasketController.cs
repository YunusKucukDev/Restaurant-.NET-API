using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.BasketDtos;
using Restaurant.WebUI.Services.Basket;
using Restaurant.WebUI.Services.Catalog.ProductService;

namespace Restaurant.WebUI.Areas.Admin.Controllers
{
    public class BasketController : Controller
    {

        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public BasketController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;

            var values = await _basketService.GetBasket();
            ViewBag.total = values.TotalPrice;
            var tax = (values.TotalPrice * 10) / 100;
            var totalPriceWithTax = values.TotalPrice + (tax);
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            ViewBag.tax = tax;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProduct(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.Name,
                Price = values.Price,
                ProductImageUrl = values.ImageUrl,
                Quantity = 1
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}

