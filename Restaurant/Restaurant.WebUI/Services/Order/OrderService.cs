using System.Net.Http;
using Restaurant.DtoLayer.OrderDtos.Update;
using Restaurant.DtoLayer.OrderDtos.Create;
using Restaurant.DtoLayer.OrderDtos.Result;

namespace Restaurant.WebUI.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderDto>> GetOrdersByUserIdAsync(string userId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultOrderDto>>($"https://localhost:7300/api/orders/user/{userId}");
            return response ?? new List<ResultOrderDto>();
        }

        public async Task<OrderDetailDto> GetOrderByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDetailDto>($"https://localhost:7300/api/orders/{id}");
        }

        public async Task<bool> CreateOrderAsync(CreateOrderDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7300/api/orders", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task UpdateStatusAsync(UpdateOrderStatusDto dto)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7300/api/orders/{dto.OrderId}/status", dto);
        }

        public async Task DeleteStatusAsync(UpdateOrderStatusDto dto)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7300/api/orders/{dto.OrderId}/cancel", dto);
        }
    }
}

