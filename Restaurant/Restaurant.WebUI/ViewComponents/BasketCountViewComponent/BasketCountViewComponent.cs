using Microsoft.AspNetCore.Mvc;
using Restaurant.WebUI.Services.Basket;
using Restaurant.WebUI.Services.Interfaces;

namespace Restaurant.WebUI.ViewComponents.BasketCountViewComponent
{
    [ViewComponent(Name = "BasketCountViewComponent")]
    public class BasketCountViewComponent : ViewComponent
    {

        private readonly IBasketService _basketService;
        private readonly IUserService _userService;

        public BasketCountViewComponent(IBasketService basketService, IUserService userService)
        {
            _basketService = basketService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketService.GetBasket();

            // basket veya basket.BasketItems null ise hata almamak için kontrol ekliyoruz
            if (basket == null || basket.BasketItems == null)
            {
                return View(0);
            }

            // Satır sonuna ";" ekledik ve Sum ile toplam adedi aldık
            int basketCount = basket.BasketItems.Sum(x => x.Quantity);

            return View(basketCount);
        }
    }
}
