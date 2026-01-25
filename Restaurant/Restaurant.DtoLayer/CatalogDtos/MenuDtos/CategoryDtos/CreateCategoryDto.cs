using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Restaurant.DtoLayer.CatalogDtos.MenuDtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }         

        public bool IsActive { get; set; }             

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<SelectListItem> Categories { get; set; }
    }
}
