
using Restaurant.DtoLayer.CatalogDtos.OutcomeDto;

namespace Restaurant.WebUI.Services.Catalog.OutcomeService
{
    public class OutcomeService : IOutcomeService
    {
        private readonly HttpClient _httpClient;
        public OutcomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOutcomeDto(CreateOutcomeDto createOutcomeDto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/Outcomes", createOutcomeDto);

        }

        public async Task DeleteOutcomeDto(string id)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/Outcomes/{id}");
        }

        public async Task<List<ResultOutcomeDto>> GetOutcomesByShiftAsync(string shift)
        {
            // API tarafındaki OutcomesController içinde yazdığımız endpoint'e istek atar
            var responseMessage = await _httpClient.GetAsync($"http://localhost:7000/api/Outcomes/GetOutcomesByShift/{shift}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultOutcomeDto>>();
                return values;
            }

            return new List<ResultOutcomeDto>();
        }

        public async Task<List<ResultOutcomeDto>> GetAllOutcomes()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultOutcomeDto>>("http://localhost:7000/api/Outcomes");
            return values;
        }

        public async Task<UpdateOutComeDto> GetByIdAbotDto(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateOutComeDto>("http://localhost:7000/api/Outcomes");
            return values;
        }

        public async Task UpdateOutcomeDto(UpdateOutComeDto updateOutcomeDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOutComeDto>("http://localhost:7000/api/Outcomes", updateOutcomeDto);
        }
    }
}
