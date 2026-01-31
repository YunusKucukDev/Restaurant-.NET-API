using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch2_Dtos
{
    public class CreateBranch2_Dto
    {
       
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
