using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Catalog.Entities
{
    public class SpecialMenu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialMenuId { get; set; }

        public string SpecialMenuName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }       // Satışta mı

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
