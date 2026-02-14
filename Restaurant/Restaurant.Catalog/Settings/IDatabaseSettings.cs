namespace Restaurant.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string Branch2_InformationCollectionName { get; set; }
        public string Branch1_InformationCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string SpecialMenuCollectionName { get; set; }

        public string InComeCollectionName { get; set; }
        public string OutcomeCollectionName { get; set; }
        public string FixedExpenseCollectionName { get; set; }
        public string DailyReportCollectionName { get; set; }
        public string FinalReportCollectionName { get; set; }
    }
}
