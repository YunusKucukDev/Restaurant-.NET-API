using Restaurant.DtoLayer.CatalogDtos.MenuDtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.CatalogDtos.MenuDtos.CategoryDtos
{
    public class CategorWithProductsDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }

        public List<ResultProductDto> Products { get; set; }
    }
}
