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
            var rate = await _discountService.GetDiscountCouponCountRate(code);

            if (rate > 0)
            {
                // 10 dakika sonra silinecek şekilde ayarla
                var expireTime = DateTime.Now.AddMinutes(10);

                CookieOptions options = new CookieOptions
                {
                    Expires = expireTime,
                    Path = "/",
                    HttpOnly = true // Güvenlik için sadece sunucu okusun
                };

                // Bitiş vaktini çereze yazıyoruz
                Response.Cookies.Append("CouponExpireTime", expireTime.ToString("yyyy-MM-dd HH:mm:ss"), options);

                // Sepete indirimi yansıt
                var basket = await _basketService.GetBasket();
                basket.DiscountCode = code;
                basket.DiscountRate = rate;
                await _basketService.SaveBasket(basket);
            }

            return RedirectToAction("Index");
        }
    }
}
