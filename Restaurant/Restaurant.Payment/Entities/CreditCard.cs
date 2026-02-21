namespace Restaurant.Payment.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
