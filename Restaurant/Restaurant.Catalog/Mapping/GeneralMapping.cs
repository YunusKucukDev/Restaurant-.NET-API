using AutoMapper;
using Restaurant.Catalog.Dtos.About;
using Restaurant.Catalog.Dtos.BookingDtos;
using Restaurant.Catalog.Dtos.Branch1_Dtos;
using Restaurant.Catalog.Dtos.Branch2_Dtos;
using Restaurant.Catalog.Dtos.CategoryDtos;
using Restaurant.Catalog.Dtos.DailyReport;
using Restaurant.Catalog.Dtos.Dtos.IncomeDtos;
using Restaurant.Catalog.Dtos.FinalReportDtos;
using Restaurant.Catalog.Dtos.FixedExpenseDto;
using Restaurant.Catalog.Dtos.IncomeDtos;
using Restaurant.Catalog.Dtos.NotificationDtos;
using Restaurant.Catalog.Dtos.OutcomeDtos;
using Restaurant.Catalog.Dtos.ProductDtos;
using Restaurant.Catalog.Dtos.SpecialMenuDtos;
using Restaurant.Catalog.Entities;

namespace Restaurant.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Branch1_Information, ResultBranc1_Dto>().ReverseMap();
            CreateMap<Branch1_Information, GetByIdBranc1_Dto>().ReverseMap();
            CreateMap<Branch1_Information, CreateBranc1_Dto>().ReverseMap();
            CreateMap<Branch1_Information, UpdateBranc1_Dto>().ReverseMap();


            CreateMap<Branch2_Information, ResultBranc2_Dto>().ReverseMap();
            CreateMap<Branch2_Information, GetByIdBranc2_Dto>().ReverseMap();
            CreateMap<Branch2_Information, CreateBranc2_Dto>().ReverseMap();
            CreateMap<Branch2_Information, UpdateBranc2_Dto>().ReverseMap();


            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();


            CreateMap<Product, ResultProductDto>()
     .ForMember(dest => dest.IsFavorite, opt => opt.MapFrom(src => src.IsFavorite)) // Açıkça belirtelim
     .ForMember(dest => dest.CategoryName,
         opt => opt.MapFrom((src, dest, destMember, context) =>
         {
             var categories = context.Items["categories"] as List<Category>;
             return categories?.FirstOrDefault(c => c.CategoryId == src.CategoryId)?.Name;
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

            CreateMap<Income, ResultIncomeDto>().ReverseMap();
            CreateMap<Income, CreateInComeDto>().ReverseMap();
            CreateMap<Income, UpdateInComeDtos>().ReverseMap();
            CreateMap<Income, GetByIdIncomeDto>().ReverseMap();

            CreateMap<Outcome, UpdateOutComeDto>().ReverseMap();
            CreateMap<Outcome, CreateOutcomeDto>().ReverseMap();
            CreateMap<Outcome, GetByIdOutcomeDto>().ReverseMap();
            CreateMap<Outcome, ResultOutcomeDto>().ReverseMap();

            CreateMap<FixedExpense, ResultFixedExpenseDto>().ReverseMap();
            CreateMap<FixedExpense, CreateFixedExpenseDto>().ReverseMap();
            CreateMap<FixedExpense, UpdateFixedExpensedto>().ReverseMap();

            CreateMap<DailyReport, ResultDailyReportDto>().ReverseMap();
            CreateMap<DailyReport, CreateDailyReportDto>().ReverseMap();

            CreateMap<FinalReport, ResultFinalReportDto>().ReverseMap();
            CreateMap<FinalReport, CreateFinalReportDto>().ReverseMap();
            CreateMap<FinalReport, GetByIdFinalReportDto>().ReverseMap();


            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();

            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();

        }

    }
}
