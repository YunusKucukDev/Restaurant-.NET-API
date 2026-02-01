namespace Restaurant.Discount.Dtos
{
    public class UpdateDiscountDto
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }   // Kupon başlangıç
        public DateTime EndDate { get; set; }     // Kupon bitiş
    }
}
