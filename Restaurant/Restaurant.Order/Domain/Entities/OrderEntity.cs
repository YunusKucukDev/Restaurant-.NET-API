
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Order.Domain.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int TotalPrice { get; set; }


        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }


        public DateTime CreatedDate { get; set; }
        public string? CancelReason { get; set; }
        public List<OrderItemEntity> Items { get; set; } = new();
    }
}
