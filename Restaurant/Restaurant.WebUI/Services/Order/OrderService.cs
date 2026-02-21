using Restaurant.DtoLayer.OrderDtos;
using System.Net.Http.Json;

namespace Restaurant.WebUI.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        

        // API'de: [HttpPost]
        public async Task CreateAsync(CreateOrderDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7300/api/orders", dto);
            
            if (!response.IsSuccessStatusCode)
            {
                // Hata durumunda loglama yapılabilir veya exception fırlatılabilir
                throw new Exception("Sipariş oluşturulurken bir hata oluştu.");
            }
        }

        // API'de: [HttpGet("{id}")]
        public async Task<List<ResultOrderDto>> GetByIdAsync(int orderId)
        {
            // API'deki GetOrderById metoduna istek atar
            var response = await _httpClient.GetFromJsonAsync<List<ResultOrderDto>>($"https://localhost:7300/api/orders/{orderId}");
            return response ?? new List<ResultOrderDto>();
        }

        // API'de: [HttpGet("GetByUserId/{userId}")]
        public async Task<List<ResultOrderDto>> GetByUserIdAsync(string userId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultOrderDto>>($"https://localhost:7300/api/orders/GetByUserId/{userId}");
            return response ?? new List<ResultOrderDto>();
        }
    }
}