namespace Restaurant.WebUI.Models
{
    public class RapidCurrencyViewModel
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public CurrencyInfo USD { get; set; }
        public CurrencyInfo EUR { get; set; }
        public CurrencyInfo GBP { get; set; }
        public CurrencyInfo TRY { get; set; }
    }

    public class CurrencyInfo
    {
        public string code { get; set; }
        public string rate { get; set; } // API'den string geliyor, sonra decimal'e çevirebilirsin
    }
}
