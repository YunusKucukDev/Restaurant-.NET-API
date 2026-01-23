using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Catalog.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string BranchImage1 { get; set; }
        public string BranchImage2 { get; set; }
        public string? GalleryImage1 { get; set; }
        public string? GalleryImage2 { get; set; }
        public string? GalleryImage3 { get; set; }
        public string? GalleryImage4 { get; set; }
        public string? GalleryImage5 { get; set; }
        public string? GalleryImage6 { get; set; }
    }
}
