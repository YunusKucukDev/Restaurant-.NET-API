using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        public string Name { get; set; }              

        public string Description { get; set; }

        public int DisplayOrder { get; set; }          // Menü sırası

        public bool IsActive { get; set; }             // Kategori aktif mi

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
