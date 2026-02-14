using Restaurant.DtoLayer.OrderDtos.Update;
using Restaurant.DtoLayer.OrderDtos.Create;
using Restaurant.DtoLayer.OrderDtos.Result;


namespace Restaurant.WebUI.Services.Order

{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetOrdersByUserIdAsync(string userId);
        Task<OrderDetailDto> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(CreateOrderDto dto);
        Task UpdateStatusAsync(UpdateOrderStatusDto dto);
    }
}
