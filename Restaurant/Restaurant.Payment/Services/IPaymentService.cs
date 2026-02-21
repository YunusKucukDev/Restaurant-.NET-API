using Restaurant.Payment.Dtos;

namespace Restaurant.Payment.Services
{
    public interface IPaymentService
    {
        Task<List<ResultPaymentDto>> GetAllPayments();
        Task<ResultPaymentDto> GetPaymentById(int id);
        Task<ResultPaymentDto> GetPaymentByUserId(int userId);
        Task<ResultPaymentDto> GetPaymentByOrderId(int userId);
        Task DefinePaymentOption(int orderId, bool option);
        Task CreatePayment(CreatePaymentDto createPaymentDto);
        
    }
}
