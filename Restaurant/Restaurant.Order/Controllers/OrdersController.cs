using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Order.Dtos.Create;
using Restaurant.Order.Dtos.Update;
using Restaurant.Order.Services;

namespace Restaurant.Order.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            var orderId = await _orderService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = orderId }, null);
        }

        // GET /api/orders/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var orders = await _orderService.GetByUserIdAsync(userId);
            return Ok(orders);
        }

        // GET /api/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order is null)
                return NotFound();

            return Ok(order);
        }

        // PUT /api/orders/{id}/status
        [HttpPut("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            [FromBody] UpdateOrderStatusDto dto)
        {
            if (id != dto.OrderId)
                return BadRequest("Route id and body id do not match");

            await _orderService.UpdateStatusAsync(dto);
            return NoContent();
        }

        // PUT /api/orders/{id}/cancel
        [HttpPut("{id:int}/cancel")]
        public async Task<IActionResult> Cancel(
            int id,
            [FromBody] CancelOrderDto? dto)
        {
            await _orderService.CancelAsync(id, dto?.Reason);
            return NoContent();
        }
    }
}
