namespace Restaurant.Catalog.Dtos.SpecialMenuDtos
{
    public class GetByIdSpecialMenuDto
    {
        public string SpecialMenuId { get; set; }

        public string SpecialMenuName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }       

        public int DisplayOrder { get; set; }        

        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
