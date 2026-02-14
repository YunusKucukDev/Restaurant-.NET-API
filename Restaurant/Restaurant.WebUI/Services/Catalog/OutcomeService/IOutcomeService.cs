


using Restaurant.DtoLayer.CatalogDtos.OutcomeDto;

namespace Restaurant.WebUI.Services.Catalog.OutcomeService
{
    public interface IOutcomeService
    {
        Task<List<ResultOutcomeDto>> GetAllOutcomes();
        Task<UpdateOutComeDto> GetByIdAbotDto(string id);
        Task<List<ResultOutcomeDto>> GetOutcomesByShiftAsync(string shift);
        Task UpdateOutcomeDto(UpdateOutComeDto updateOutcomeDto);
        Task DeleteOutcomeDto(string id);
        Task CreateOutcomeDto(CreateOutcomeDto createOutcomeDto);
    }
}
