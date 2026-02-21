using Restaurant.DtoLayer.OrderDtos;

namespace Restaurant.WebUI.Services.Order

{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderDto dto);
        Task<List<ResultOrderDto>> GetByUserIdAsync(string userId);
        Task<List<ResultOrderDto>> GetByIdAsync(int orderId);
    }
}
