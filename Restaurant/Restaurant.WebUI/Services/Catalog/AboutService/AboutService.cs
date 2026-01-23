

using Restaurant.DtoLayer.CatalogDtos.InformationDtos.Aboutservice;

namespace Restaurant.WebUI.Services.Catalog.AboutService
{
    public class AboutService : IAboutService
    {

        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       

        public async Task<List<ResultAboutDto>> GetAllAbouts()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("http://localhost:7000/api/Abouts");
            return values;
        }

        public async Task<UpdateAboutDto> GetByIdAbotDto(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateAboutDto>($"http://localhost:7000/api/Abouts/{id}");
            return values;
        }

        public async Task UpdateAboutDto(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("http://localhost:7000/api/Abouts", updateAboutDto);
        }
    }
}
