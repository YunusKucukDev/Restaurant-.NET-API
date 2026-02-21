using System.ComponentModel.DataAnnotations;

namespace Restaurant.DtoLayer.OrderDtos
{
    public class OrderItemEntity
    {
        
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
