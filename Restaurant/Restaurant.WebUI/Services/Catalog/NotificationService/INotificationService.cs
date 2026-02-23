using Restaurant.DtoLayer.CatalogDtos.NotificationDtos;

namespace Restaurant.WebUI.Services.Catalog.NotificationService
{
    public interface INotificationService
    {
        Task<List<ResultNotificationDto>> GetAllNotifications();
        Task CreatNotification(CreateNotificationDto createNotificationDto);
        Task<int> NotificationCountByStatusFalse();
    }
}
