using AutoMapper;
using Restaurant.Order.Domain.Entities;
using Restaurant.Order.Dtos;


namespace Restaurant.Order.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<OrderEntity,ResultOrderDto>().ReverseMap();
            CreateMap<OrderEntity,CreateOrderDto>().ReverseMap();
            CreateMap<OrderItemEntity, OrderItemEntity>().ReverseMap();
        }
    }
}
