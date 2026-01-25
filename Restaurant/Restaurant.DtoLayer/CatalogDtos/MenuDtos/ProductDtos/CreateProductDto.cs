using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.CatalogDtos.MenuDtos.ProductDtos
{
    public class CreateProductDto
    {
       

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; } = true;     // Satışta mı

        public int DisplayOrder { get; set; }        // Kategori içi sıralama

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

       
        public string CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
