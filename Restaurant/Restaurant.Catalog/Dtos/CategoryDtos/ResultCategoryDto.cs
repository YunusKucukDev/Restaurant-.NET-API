using Restaurant.Catalog.Dtos.ProductDtos;

namespace Restaurant.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }          // Menü sırası

        public bool IsActive { get; set; }             // Kategori aktif mi

 
        public string CategoryName { get; set; }
   

        public List<ResultProductDto> Products { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
