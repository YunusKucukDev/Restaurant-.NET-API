using Restaurant.DtoLayer.CatalogDtos.BookingDtos;
using System.Text.Json;

namespace Restaurant.WebUI.Services.Catalog.BookingService
{
    public class BookingService : IBookingService
    {

        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBooking(CreateBookingDto dto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/bookings", dto);
        }

        public async Task DeleteBooking(string id)
        {
           await _httpClient.DeleteAsync($"http://localhost:7000/api/bookings/{id}");
        }

        public async Task<List<ResultBookingDto>> GetAllBooking()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ResultBookingDto>>("http://localhost:7000/api/bookings");
            return result;
        }

        public async Task<int> GetBookingCount()
        {
           var result = await _httpClient.GetFromJsonAsync<int>("http://localhost:7000/api/bookings/GetBookingCount");
            return result;
        }

        public async Task<ResultBookingDto> GetByIdBooking(string id)
        {
           var result = await _httpClient.GetFromJsonAsync<ResultBookingDto>($"http://localhost:7000/api/bookings/{id}");
            return result;
        }

        public async Task<ResultBookingDto> GetByUserIdBooking(string userid)
        {
            // 1. İsteği gönder
            var response = await _httpClient.GetAsync($"http://localhost:7000/api/bookings/GetByUserIdBooking/{userid}");

            // 2. Eğer başarılıysa (200 OK) ve içerik varsa oku
            if (response.IsSuccessStatusCode)
            {
                // Eğer içerik boşsa (No Content - 204 gibi) null dön
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return null;

                // JSON içeriğini güvenli bir şekilde oku
                try
                {
                    return await response.Content.ReadFromJsonAsync<ResultBookingDto>();
                }
                catch (JsonException)
                {
                    return null; // JSON geçersizse null dön
                }
            }

            // 3. Veri bulunamadıysa (404) veya hata varsa null dön
            return null;
        }
    }
}
