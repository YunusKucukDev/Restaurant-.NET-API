using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.NotificationDtos;
using Restaurant.Catalog.Entities;
using Restaurant.Catalog.Settings;

namespace Restaurant.Catalog.Services.NotificationServices
{
    public class NotificationService : INotificationService
    {
        private readonly IMongoCollection<Notification> _collection;
        private readonly IMapper _mapper;

        public NotificationService(
        IMongoClient mongoClient,
        IOptions<DatabaseSettings> databaseSettings,
        IMapper mapper)
        {
            var database = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = database.GetCollection<Notification>(
                databaseSettings.Value.NotificationCollectionName);

            _mapper = mapper;
        }


        public async Task CreatNotification(CreateNotificationDto createNotificationDto)
        {
            await _collection.InsertOneAsync(_mapper.Map<Notification>(createNotificationDto));
        }

        public async Task<List<ResultNotificationDto>> GetAllNotifications()
        {
            return await _collection.Find(notification => true)
                .Project(notification => _mapper.Map<ResultNotificationDto>(notification))
                .ToListAsync(); 
        }

        public async Task<int> NotificationCountByStatusFalse()
        {
            return (int)await _collection.CountDocumentsAsync(notification => notification.Status == false);
        }
    }
}
