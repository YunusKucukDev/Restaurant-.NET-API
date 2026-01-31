using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Basket.Dtos;
using Restaurant.Basket.LoginServices;
using Restaurant.Basket.Services;

namespace Restaurant.Basket.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;
            var claims = User.Claims.Select(x => new { x.Type, x.Value }).ToList();
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto dto)
        {
            dto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(dto);
            return Ok("Sepetteki Değişiklikler kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet başarıyla silindi");
        }
    }
}
