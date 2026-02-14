using Restaurant.Order.Domain.Entities;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Dtos.Result
{
    public class ResultOrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
        public string? CancelReason { get; set; }
        public List<OrderItemEntity> Items { get; set; } = new();
    }
}
