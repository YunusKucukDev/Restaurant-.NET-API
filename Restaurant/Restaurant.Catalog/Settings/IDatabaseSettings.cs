namespace Restaurant.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string Branch2_InformationCollectionName { get; set; }
        public string Branch1_InformationCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
    }
}
