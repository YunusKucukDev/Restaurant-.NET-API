using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Basket;
using Restaurant.WebUI.Services.DiscountCoupon;

namespace Restaurant.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountcouponService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountcouponService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCouponCountRate(code);

            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;

            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);
            // ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            return RedirectToAction("Index", "Basket", new { code = code, discountRate = values, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
