namespace Restaurant.Order.Dtos.Create
{
    public class CreateOrderItemDto
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
