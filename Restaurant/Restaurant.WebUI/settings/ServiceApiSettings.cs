namespace Restaurant.WebUI.settings
{
    public class ServiceApiSettings
    {
        public string OcelotUrl { get; set; }
        public ServiceApi Catalog { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
