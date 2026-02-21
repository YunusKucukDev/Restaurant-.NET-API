using Restaurant.Payment.Entities;

namespace Restaurant.Payment.Dtos
{
    public class ResultPaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public CreditCard CreditCard { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool ChoisePaymet { get; set; }
    }
}
