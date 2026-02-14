using AutoMapper;
using MongoDB.Driver;
using Restaurant.Catalog.Dtos.Dtos.IncomeDtos;
using Restaurant.Catalog.Dtos.IncomeDtos;


namespace Restaurant.Catalog.Services.IncomeService
{
    public interface IIncomeService
    {
        Task<List<ResultIncomeDto>> GetAllIncomes();
        Task<GetByIdIncomeDto> GetByIdAbotDto(string id);
        Task<List<ResultIncomeDto>> GetIncomesByShiftAsync(string shift);
        Task UpdateIncomeDto(UpdateInComeDtos updateIncomeDto);
        Task DeleteIncomeDto(string id);
        Task CreateIncomeDto(CreateInComeDto createIncomeDto);
    }
}
