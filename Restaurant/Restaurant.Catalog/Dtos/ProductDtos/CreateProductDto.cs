using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }       

        public int DisplayOrder { get; set; }        

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
       
        public string CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
