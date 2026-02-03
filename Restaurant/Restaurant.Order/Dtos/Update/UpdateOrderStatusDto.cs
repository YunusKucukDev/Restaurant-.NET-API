

using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Dtos.Update
{
    public class UpdateOrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
