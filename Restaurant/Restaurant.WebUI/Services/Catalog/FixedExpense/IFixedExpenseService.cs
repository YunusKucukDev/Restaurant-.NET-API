
using Restaurant.DtoLayer.CatalogDtos.FixedExpenseDto;
namespace Restaurant.WebUI.Services.Catalog.FixedExpense
{
    public interface IFixedExpenseService
    {
        Task<List<ResultFixedExpense>> GetAllFixedExpense();
        Task<UpdateFixedExpense> GetByIdFixedExpense(string id);
        Task<List<ResultFixedExpense>> GetFixedExpensesByShiftAsync(string shift);
        Task CreateFixedExpense(CreateFixedExpense dto);
        Task UpdateFixedExpense(UpdateFixedExpense dto);
        Task DeleteFixedExpense(string id);
    }
}
