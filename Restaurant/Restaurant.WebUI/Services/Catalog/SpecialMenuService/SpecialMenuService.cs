using Restaurant.DtoLayer.CatalogDtos.MenuDtos.SpecialMenuDtos;

namespace Restaurant.WebUI.Services.Catalog.SpecialMenuService
{
    public class SpecialMenuService : ISpecialMenuService
    {

        private readonly HttpClient _httpClient;

        public SpecialMenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialMenu(CreateSpecialMenuDtos createSpecialMenuDtos)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialMenuDtos>("http://localhost:7000/api/SpecialMenus", createSpecialMenuDtos);
        }

        public async Task DeleteSpecialMenu(string id)
        {
            await _httpClient.DeleteAsync("http://localhost:7000/api/SpecialMenus/"+id);
        }

        public async Task<List<ResultSpecialMenuDtos>> GetAllspecialMenus()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSpecialMenuDtos>>("http://localhost:7000/api/SpecialMenus");
            return values;
        }

        public async Task<UpdateSpecialMenuDtos> GetByIdSpecialMenu(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateSpecialMenuDtos>("http://localhost:7000/api/SpecialMenus/"+id);
            return values;
        }

        public async Task UpdateSpecialMenu(UpdateSpecialMenuDtos updateSpecialMenuDtos)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialMenuDtos>("http://localhost:7000/api/SpecialMenus", updateSpecialMenuDtos);
        }
    }
}
