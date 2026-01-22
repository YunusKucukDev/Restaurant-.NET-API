using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Catalog.Entities
{
    public class Branch2_Information
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BranchId { get; set; }
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
    }
}
