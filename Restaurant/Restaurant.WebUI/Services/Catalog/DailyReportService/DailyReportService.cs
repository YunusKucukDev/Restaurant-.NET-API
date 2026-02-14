using Microsoft.AspNetCore.Mvc;
using Restaurant.DtoLayer.CatalogDtos.DailyReport;


namespace Restaurant.WebUI.Services.Catalog.DailyReportService
{
    public class DailyReportService : IDailyReportService
    {

        private readonly HttpClient _httpClient;

        public DailyReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDailyReports(CreateDailyReportDto dto)
        {
            await _httpClient.PostAsJsonAsync("http://localhost:7000/api/DailyReports", dto);
        }

        public async Task<List<ResultDailyReportDto>> GetAllDailyReports()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultDailyReportDto>>("http://localhost:7000/api/DailyReports");
            return values;
        }

        public async Task<List<ResultDailyReportDto>> GetDailyReportsByShiftAsync(string shift)
        {
            // API tarafındaki DailyReportsController içindeki "GetAllByShift" endpoint'ine istek atar
            var responseMessage = await _httpClient.GetAsync($"http://localhost:7000/api/DailyReports/GetAllByShift/{shift}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultDailyReportDto>>();
                return values;
            }

            return new List<ResultDailyReportDto>();
        }

        public async Task DeleteDailyReports(string id)
        {
            await _httpClient.DeleteAsync($"http://localhost:7000/api/DailyReports/{id}");
        }
    }
}
