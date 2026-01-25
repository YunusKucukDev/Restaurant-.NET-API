using Restaurant.DtoLayer.CatalogDtos.MenuDtos.CategoryDtos;

namespace Restaurant.WebUI.Services.Catalog.CategoryService
{
    public class CategoryService : ICategoryService
    {

        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/Categories", createCategoryDto);
        }

        public async Task DeleteCategory(string categoryId)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/Categories/{categoryId}");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategories()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCategoryDto>>("http://localhost:7000/api/Categories");
            return values;
        }

        public async Task<UpdateCategoryDto> GetByIdCategory(string categoryId)
        {
            var values = await  _httpClient.GetFromJsonAsync<UpdateCategoryDto>($"http://localhost:7000/api/Categories/{categoryId}");
            return values;
        }

        public async Task<List<ResultCategoryDto>> GetCategoriesForSelect()
        {
            return await GetAllCategories();
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("http://localhost:7000/api/Categories", updateCategoryDto);
        }
    }
}
