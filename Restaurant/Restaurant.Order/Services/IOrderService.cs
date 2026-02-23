

using Restaurant.Order.Dtos;

namespace Restaurant.Order.Services
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderDto dto);
        Task<List<ResultOrderDto>> GetByUserIdAsync(string userId);
        Task<List<ResultOrderDto>> GetByIdAsync(int orderId);   
        Task<int> GetOrderCount();   
    }
}
