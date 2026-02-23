using Restaurant.DtoLayer.CatalogDtos.NotificationDtos;

namespace Restaurant.WebUI.Services.Catalog.NotificationService
{
    public class NotificationService : INotificationService
    {

        private readonly HttpClient _httpClient;

        public NotificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreatNotification(CreateNotificationDto createNotificationDto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/Notifications", createNotificationDto);
        }

        public async Task<List<ResultNotificationDto>> GetAllNotifications()
        {
            
            return await _httpClient.GetFromJsonAsync<List<ResultNotificationDto>>("http://localhost:7000/api/Notifications");
        }

        public async Task<int> NotificationCountByStatusFalse()
        {
            return await _httpClient.GetFromJsonAsync<int>("http://localhost:7000/api/Notifications/GetNotificationCountByStatusFalse");
        }
    }
}
