using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.CatalogDtos.MenuDtos.ProductDtos
{
    public class GetByCategoryIdProductDto
    {

        public string ProductId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }       // Satışta mı

        public int DisplayOrder { get; set; }        // Kategori içi sıralama
        [JsonPropertyName("isFavorite")] // API'den gelen küçük 'i' harfli veriyi buna zorla
        public bool IsFavorite { get; set; } = false;

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        
        public string CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
