using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Order.Dtos;
using Restaurant.Order.Services;

namespace Restaurant.Order.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")] // Veya "api/orders"
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var values = await _orderService.GetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var values = await _orderService.GetByUserIdAsync(userId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _orderService.CreateAsync(createOrderDto);
            return Ok("Sipariş başarıyla oluşturuldu.");
        }
    }
}