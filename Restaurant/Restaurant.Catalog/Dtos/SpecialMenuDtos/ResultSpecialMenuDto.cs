namespace Restaurant.Catalog.Dtos.SpecialMenuDtos
{
    public class ResultSpecialMenuDto
    {
        public string SpecialMenuId { get; set; }

        public string SpecialMenuName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }       // Satışta mı

        public int DisplayOrder { get; set; }        // Kategori içi sıralama

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
