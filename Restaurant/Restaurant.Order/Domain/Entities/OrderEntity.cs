using Restaurant.Order.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Order.Domain.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatus Status { get; set; }
        public string? CancelReason { get; set; }
        public List<OrderItemEntity> Items { get; set; } = new();
    }
}
