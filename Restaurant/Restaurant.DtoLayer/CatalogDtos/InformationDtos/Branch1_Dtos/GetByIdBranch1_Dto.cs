using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.CatalogDtos.InformationDtos.Branch1_Dtos
{
    public class GetByIdBranch1_Dto
    {
        public string BranchId { get; set; }
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
