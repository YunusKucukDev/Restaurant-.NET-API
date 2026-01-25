using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Restaurant.DtoLayer.CatalogDtos.MenuDtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }          // Menü sırası

        public bool IsActive { get; set; }             // Kategori aktif mi

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<SelectListItem> Categories { get; set; }
    }
}
