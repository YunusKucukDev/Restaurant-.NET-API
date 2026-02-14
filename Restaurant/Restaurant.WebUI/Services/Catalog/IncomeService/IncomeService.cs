
using Restaurant.DtoLayer.CatalogDtos.IncomeDto;

namespace Restaurant.WebUI.Services.Catalog.IncomeService
{
    public class IncomeService : IIncomeService
    {
        private readonly HttpClient _httpClient;
        public IncomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateIncomeDto(CreateInComeDto createIncomeDto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/Incomes", createIncomeDto);

        }

        public async Task DeleteIncomeDto(string id)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/Incomes/{id}");
        }

        public async Task<List<ResultIncomeDto>> GetIncomesByShiftAsync(string shift)
        {
           
            var responseMessage = await _httpClient.GetAsync($"http://localhost:7000/api/Incomes/GetIncomesByShift/{shift}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultIncomeDto>>();
                return values;
            }

            return new List<ResultIncomeDto>();
        }

        public async Task<List<ResultIncomeDto>> GetAllIncomes()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultIncomeDto>>("http://localhost:7000/api/Incomes");
            return values;
        }

        public async Task<UpdateInComeDtos> GetByIdAbotDto(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateInComeDtos>("http://localhost:7000/api/Incomes/" + id);
            return values;
        }

        public async Task UpdateIncomeDto(UpdateInComeDtos updateIncomeDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateInComeDtos>("http://localhost:7000/api/Incomes", updateIncomeDto);
        }
    }
}
