using AutoMapper;
using Restaurant.Catalog.Dtos.Branch1_Dtos;
using Restaurant.Catalog.Dtos.Branch2_Dtos;
using Restaurant.Catalog.Entities;

namespace Restaurant.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Branch1_Information ,ResultBranc1_Dto>().ReverseMap();
            CreateMap<Branch1_Information ,GetByIdBranc1_Dto>().ReverseMap();
            CreateMap<Branch1_Information ,CreateBranc1_Dto>().ReverseMap();
            CreateMap<Branch1_Information ,UpdateBranc1_Dto>().ReverseMap();

            CreateMap<Branch2_Information, ResultBranc2_Dto>().ReverseMap();
            CreateMap<Branch2_Information, GetByIdBranc2_Dto>().ReverseMap();
            CreateMap<Branch2_Information, CreateBranc2_Dto>().ReverseMap();
            CreateMap<Branch2_Information, UpdateBranc2_Dto>().ReverseMap();
        }
        
    }
}
