using Restaurant.Order.Dtos.Create;
using Restaurant.Order.Dtos.Result;
using Restaurant.Order.Dtos.Update;

namespace Restaurant.Order.Services
{
    public interface IOrderService
    {
        Task<int> CreateAsync(CreateOrderDto dto);

        Task<List<ResultOrderDto>> GetByUserIdAsync(string userId);

        Task<OrderDetailDto?> GetByIdAsync(int orderId);

        Task UpdateStatusAsync(UpdateOrderStatusDto dto);

        Task CancelAsync(int orderId, string? reason);
    }
}
