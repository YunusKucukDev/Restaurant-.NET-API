using Restaurant.Catalog.Dtos.OutcomeDtos;


namespace Restaurant.Catalog.Services.OutComeService
{
    public interface IOutcomeService
    {
        Task<List<ResultOutcomeDto>> GetAllOutcomes();
        Task<GetByIdOutcomeDto> GetByIdAbotDto(string id);
        Task<List<ResultOutcomeDto>> GetOutcomesByShiftAsync(string shift);
        Task UpdateOutcomeDto(UpdateOutComeDto updateOutcomeDto);
        Task DeleteOutcomeDto(string id);
        Task CreateOutcomeDto(CreateOutcomeDto createOutcomeDto);
    }
}
