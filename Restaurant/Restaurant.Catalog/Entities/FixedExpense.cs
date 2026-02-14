using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Catalog.Entities
{
    public class FixedExpense
    {
        [BsonId] // MongoDB _id alanı
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; } // Kira, Maaş, Elektrik vb.
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string ShiftType { get; set; }
    }
}
