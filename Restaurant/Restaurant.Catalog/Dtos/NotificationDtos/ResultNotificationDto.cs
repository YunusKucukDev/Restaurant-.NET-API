namespace Restaurant.Catalog.Dtos.NotificationDtos
{
    public class ResultNotificationDto
    {
        public string NotificationId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
