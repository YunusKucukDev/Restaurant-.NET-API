

using Restaurant.DtoLayer.CatalogDtos.FixedExpenseDto;

namespace Restaurant.WebUI.Services.Catalog.FixedExpense
{
    public class FixedExpenseService : IFixedExpenseService
    {

        private readonly HttpClient _httpClient;

        public FixedExpenseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFixedExpense(CreateFixedExpense dto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/FixedExpenses", dto);
        }

        public async  Task DeleteFixedExpense(string id)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/FixedExpenses/{id}");
        }

        public async Task<List<ResultFixedExpense>> GetAllFixedExpense()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultFixedExpense>>("http://localhost:7000/api/FixedExpenses");
            return values;
        }

        public async Task<List<ResultFixedExpense>> GetFixedExpensesByShiftAsync(string shift)
        {
            // API'deki endpoint'i çağırıyoruz
            var responseMessage = await _httpClient.GetAsync($"http://localhost:7000/api/FixedExpenses/GetFixedExpensesByShift/{shift}");
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultFixedExpense>>();
        }

        public async Task<UpdateFixedExpense> GetByIdFixedExpense(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateFixedExpense>("http://localhost:7000/api/FixedExpenses/" + id);
            return values;
        }

        public async Task UpdateFixedExpense(UpdateFixedExpense dto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFixedExpense>("http://localhost:7000/api/FixedExpenses", dto);
        }
    }
}
