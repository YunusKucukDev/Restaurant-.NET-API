namespace Restaurant.DtoLayer.PaymentDtos
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
