
using Restaurant.DtoLayer.PaymentDtos;


namespace Restaurant.WebUI.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<List<ResultPaymentDto>> GetAllPaymentsAsync();
        Task<ResultPaymentDto> GetByOrderIdPaymentsAsync(string orderId);
        Task<ResultPaymentDto> GetByUserIdPaymentsAsync(string userId);
        Task<ResultPaymentDto> DefinePaymentChoiceAsync(string orderId,bool choice);
        Task CreatePaymnetAsync(CreatePaymentDto paymnet);
    }
}
