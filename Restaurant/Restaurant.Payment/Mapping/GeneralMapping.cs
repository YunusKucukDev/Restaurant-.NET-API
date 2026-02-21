using AutoMapper;
using Restaurant.Payment.Dtos;
using Restaurant.Payment.Entities;

namespace Restaurant.Payment.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<PaymentDb, CreatePaymentDto>();
            CreateMap<PaymentDb, ResultPaymentDto>();
        }
    }
}
