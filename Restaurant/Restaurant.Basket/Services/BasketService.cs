using Restaurant.Basket.Dtos;
using Restaurant.Basket.Settings;
using System.Text.Json;

namespace Restaurant.Basket.Services
{
    public class BasketService : IBasketService
    {

        private readonly RedisService _redisService;
        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }


        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }


        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var json = await _redisService.GetDb().StringGetAsync(userId);

            if (string.IsNullOrEmpty(json))
            {
                return new BasketTotalDto
                {
                    UserId = userId,
                    BasketItems = new List<BasketItemDto>()
                };
            }
            return JsonSerializer.Deserialize<BasketTotalDto>(json);
        }


        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
