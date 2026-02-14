

using Restaurant.DtoLayer.CatalogDtos.DailyReport;

namespace Restaurant.WebUI.Services.Catalog.DailyReportService
{
    public interface IDailyReportService
    {
        Task<List<ResultDailyReportDto>> GetAllDailyReports();
        Task<List<ResultDailyReportDto>> GetDailyReportsByShiftAsync(string shift);
        Task CreateDailyReports(CreateDailyReportDto dto);
        Task DeleteDailyReports(string id);
    }
}
