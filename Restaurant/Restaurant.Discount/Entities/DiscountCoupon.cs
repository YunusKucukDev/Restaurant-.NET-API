using System.ComponentModel.DataAnnotations;

namespace Restaurant.Discount.Entities
{
    public class DiscountCoupon
    {
        [Key]
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; } 
        public bool IsActive { get; set; } = true;
        public DateTime StartDate { get; set; }   // Kupon başlangıç
        public DateTime EndDate { get; set; }     // Kupon bitiş
    }
}
