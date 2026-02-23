using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Catalog.Dtos.NotificationDtos;
using Restaurant.Catalog.Services.NotificationServices;
using System.Threading.Tasks;

namespace Restaurant.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            var result = _notificationService.GetAllNotifications().Result;
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            await _notificationService.CreatNotification(createNotificationDto);
            return Ok();
        }

        [HttpGet("GetNotificationCountByStatusFalse")]
        public IActionResult GetNotificationCountByStatusFalse()
        {
            var result = _notificationService.NotificationCountByStatusFalse().Result;
            return Ok(result);
        }
    }
}
