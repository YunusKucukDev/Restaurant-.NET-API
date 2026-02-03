namespace Restaurant.Order.Dtos.Create
{
    public class CreateOrderDto
    {
        public string UserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }

        public List<CreateOrderItemDto> Items { get; set; } = new();
    }
}
