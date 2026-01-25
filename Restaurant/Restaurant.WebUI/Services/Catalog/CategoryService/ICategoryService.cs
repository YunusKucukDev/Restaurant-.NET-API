using Restaurant.DtoLayer.CatalogDtos.MenuDtos.CategoryDtos;

namespace Restaurant.WebUI.Services.Catalog.CategoryService
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategories();
        Task<List<ResultCategoryDto>> GetCategoriesForSelect();
        Task<UpdateCategoryDto> GetByIdCategory(string categoryId);
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategory(string categoryId);
    }
}
