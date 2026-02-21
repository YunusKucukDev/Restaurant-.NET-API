
using Restaurant.DtoLayer.PaymentDtos;
using System.Net.Http.Json;

namespace Restaurant.WebUI.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Tüm ödemeleri getirir
        public async Task<List<ResultPaymentDto>> GetAllPaymentsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ResultPaymentDto>>("https://localhost:7400/api/payments");
            }
            catch (Exception)
            {
                return new List<ResultPaymentDto>();
            }
        }

        // Sipariş ID'sine göre ödeme detayını getirir
        public async Task<ResultPaymentDto> GetByOrderIdPaymentsAsync(string orderId)
        {
            return await _httpClient.GetFromJsonAsync<ResultPaymentDto>($"https://localhost:7400/api/payments/GetByOrderId/{orderId}");
        }

        // Kullanıcı ID'sine göre ödeme detayını getirir
        public async Task<ResultPaymentDto> GetByUserIdPaymentsAsync(string userId)
        {
            return await _httpClient.GetFromJsonAsync<ResultPaymentDto>($"https://localhost:7400/api/payments/GetByUserId/{userId}");
        }

        // Yeni bir ödeme kaydı oluşturur
        public async Task CreatePaymnetAsync(CreatePaymentDto payment)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7400/api/payments", payment);
        }

        // Ödeme seçimini (Kart mı Nakit mi) API'ye ileten metot
        public async Task<ResultPaymentDto> DefinePaymentChoiceAsync(string orderId, bool choice)
        {
            // API Controller'da bu isimlendirmede bir endpoint olmalı: [HttpPost("DefineChoice")]
            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7400/api/payments/DefineChoice?orderId={orderId}&choice={choice}", new { });

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResultPaymentDto>();
            }

            return null;
        }
    }
}