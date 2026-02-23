using Restaurant.Catalog.Dtos.NotificationDtos;

namespace Restaurant.Catalog.Services.NotificationServices
{
    public interface INotificationService
    {
        Task<List<ResultNotificationDto>> GetAllNotifications();
        Task CreatNotification(CreateNotificationDto createNotificationDto);
        Task<int> NotificationCountByStatusFalse();
    }
}
