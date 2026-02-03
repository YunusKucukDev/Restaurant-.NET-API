using System.ComponentModel.DataAnnotations;

namespace Restaurant.Order.Domain.Entities
{
    public class OrderItemEntity
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
