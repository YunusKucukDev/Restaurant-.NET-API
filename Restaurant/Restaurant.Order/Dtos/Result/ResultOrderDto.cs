namespace Restaurant.Order.Dtos.Result
{
    public class ResultOrderDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = null!;
    }
}
