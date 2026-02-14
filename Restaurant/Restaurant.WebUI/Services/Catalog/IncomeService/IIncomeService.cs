
using Restaurant.DtoLayer.CatalogDtos.IncomeDto;

namespace Restaurant.WebUI.Services.Catalog.IncomeService
{
    public interface IIncomeService
    {
        Task<List<ResultIncomeDto>> GetAllIncomes();
        Task<UpdateInComeDtos> GetByIdAbotDto(string id);
        Task<List<ResultIncomeDto>> GetIncomesByShiftAsync(string shift);
        Task UpdateIncomeDto(UpdateInComeDtos updateIncomeDto);
        Task DeleteIncomeDto(string id);
        Task CreateIncomeDto(CreateInComeDto createIncomeDto);
    }
}
