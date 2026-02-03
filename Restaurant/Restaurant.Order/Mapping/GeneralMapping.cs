using AutoMapper;
using Restaurant.Order.Domain.Entities;
using Restaurant.Order.Dtos.Create;
using Restaurant.Order.Dtos.Result;

namespace Restaurant.Order.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateOrderDto, OrderEntity>();
            CreateMap<CreateOrderItemDto, OrderItemEntity>();

            CreateMap<OrderEntity, ResultOrderDto>();
            CreateMap<OrderEntity, OrderDetailDto>();
            CreateMap<OrderItemEntity, OrderItemDto>();
        }
    }
}
