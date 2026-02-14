
using Restaurant.DtoLayer.CatalogDtos.FinalReportDtos;

namespace Restaurant.WebUI.Services.Catalog.FinalReportService
{
    public interface IFinalReportService
    {
        Task<List<ResultFinalReportDto>> GetAllFinalReports();
        Task<ResultFinalReportDto> GetByIdFinalReport(string id);
        Task<List<ResultFinalReportDto>> GetFinalReportsByShiftAsync(string shift);
        Task DeleteFinalReport(string id);
        Task CreateFinalReport(CreateFinalReportDto dto);
    }
}
