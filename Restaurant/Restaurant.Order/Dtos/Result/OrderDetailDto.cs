namespace Restaurant.Order.Dtos.Result
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
    }
}
