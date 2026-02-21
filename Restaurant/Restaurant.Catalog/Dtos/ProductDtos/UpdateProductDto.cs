namespace Restaurant.Catalog.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public int DisplayOrder { get; set; }

        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public string CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
