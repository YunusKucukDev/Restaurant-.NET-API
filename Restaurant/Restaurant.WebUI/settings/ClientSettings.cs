namespace Restaurant.WebUI.settings
{
    public class ClientSettings
    {
        public Client restaurantVisitorClient { get; set; }
        public Client restaurantManagerClient { get; set; }
        public Client restaurantAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
