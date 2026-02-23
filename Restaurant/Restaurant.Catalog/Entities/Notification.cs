using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Catalog.Entities
{
    public class Notification
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string NotificationId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
