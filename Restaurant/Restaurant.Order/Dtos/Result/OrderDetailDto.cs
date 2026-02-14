namespace Restaurant.Order.Dtos.Result
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }

        
        public List<OrderDetailDto> OrderItems { get; set; }
    }
}
