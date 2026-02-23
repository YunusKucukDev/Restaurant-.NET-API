using Microsoft.AspNetCore.SignalR;
using Restaurant.WebUI.Services.Catalog.BookingService;
using Restaurant.WebUI.Services.Catalog.CategoryService;
using Restaurant.WebUI.Services.Catalog.NotificationService;
using Restaurant.WebUI.Services.Catalog.ProductService;
using Restaurant.WebUI.Services.Catalog.SpecialMenuService;
using Restaurant.WebUI.Services.Interfaces;
using Restaurant.WebUI.Services.Order;

namespace Restaurant.WebUI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ISpecialMenuService _specialMenuService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, ISpecialMenuService specialMenuService, IUserService userService, IOrderService orderService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _specialMenuService = specialMenuService;
            _userService = userService;
            _orderService = orderService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        private static int clientCount = 0;


        public async Task SendCategoryCount()
        {
            int categoryCount = await _categoryService.GetCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }

        public async Task SendProductCount()
        {
            int productCount = await _productService.GetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
        }

        public async Task SendSpecialMenuCount()
        {
            int specialMenuCount = await _specialMenuService.GetSpecialMenuCount();
            await Clients.All.SendAsync("ReceiveSpecialMenuCount", specialMenuCount);
        }

        public async Task SendUserCount()
        {
            int userCount = await _userService.GetAllUserCount();
            await Clients.All.SendAsync("ReceiveUserCount", userCount);
        }

        public async Task SendOrderCount()
        {
            int orderCount = await _orderService.GetOrderCount();
            await Clients.All.SendAsync("ReceiveOrderCount", orderCount);
        }

        public async Task SendBookingCount()
        {
            int bookingCount = await _bookingService.GetBookingCount();
            await Clients.All.SendAsync("ReceiveBookingCount", bookingCount);
        }

        public async Task SendMessage( string message)
        {
            var userInfo = await _userService.GetUserInfo();
            var user = userInfo.Name ?? "Misafir";
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendNotification()
        {
            int notReadingNotification = await _notificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotReadingNotificationCount", notReadingNotification);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
