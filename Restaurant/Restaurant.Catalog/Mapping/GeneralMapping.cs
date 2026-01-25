using AutoMapper;
using Restaurant.Catalog.Dtos.About;
using Restaurant.Catalog.Dtos.Branch1_Dtos;
using Restaurant.Catalog.Dtos.Branch2_Dtos;
using Restaurant.Catalog.Dtos.CategoryDtos;
using Restaurant.Catalog.Dtos.ProductDtos;
using Restaurant.Catalog.Dtos.SpecialMenuDtos;
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


            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();


            CreateMap<Product, ResultProductDto>()
           .ForMember(dest => dest.CategoryName,
               opt => opt.MapFrom((src, dest, destMember, context) =>
               {
                   var categories = context.Items["categories"] as List<Category>;

                   return categories?
                       .FirstOrDefault(c => c.CategoryId == src.CategoryId)
                       ?.Name;
               }));
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, GetByCategoryIdProductsDto>().ReverseMap();


            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CategorySelectDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();


            CreateMap<SpecialMenu, ResultSpecialMenuDto>().ReverseMap();
            CreateMap<SpecialMenu, GetByIdSpecialMenuDto>().ReverseMap();
            CreateMap<SpecialMenu, CreateSpecialMenuDto>().ReverseMap();
            CreateMap<SpecialMenu, UpdateSpecialMenuDto>().ReverseMap();
           
        }
        
    }
}
