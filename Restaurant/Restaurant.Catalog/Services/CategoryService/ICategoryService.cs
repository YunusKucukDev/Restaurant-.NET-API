using Restaurant.Catalog.Dtos.CategoryDtos;

namespace Restaurant.Catalog.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task<List<CategorySelectDto>> GetCategoriesForSelectAsync();
        Task<List<ResultCategoryDto>> GetCategoriesWithProductsAsync();
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        
    }
}
