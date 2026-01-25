using Restaurant.Catalog.Dtos.ProductDtos;

namespace Restaurant.Catalog.Dtos.CategoryDtos
{
    public class CategoryWithProductsDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DisplayOrder { get; set; }

        public List<ResultProductDto> Products { get; set; }
    }
}
