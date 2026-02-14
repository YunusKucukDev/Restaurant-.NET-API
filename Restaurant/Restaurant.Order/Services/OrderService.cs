using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Order.Contex;
using Restaurant.Order.Domain.Entities;
using Restaurant.Order.Domain.Enum;
using Restaurant.Order.Dtos.Create;
using Restaurant.Order.Dtos.Result;
using Restaurant.Order.Dtos.Update;

namespace Restaurant.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContex _context;
        private readonly IMapper _mapper;

        public OrderService(OrderDbContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<int> CreateAsync(CreateOrderDto dto)
        {
            var order = _mapper.Map<OrderEntity>(dto);
            order.Status = OrderStatus.Pending;
            order.CreatedDate = DateTime.UtcNow;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

       
        public async Task<List<ResultOrderDto>> GetByUserIdAsync(string userId)
        {
            var orders = await _context.Orders
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
            return _mapper.Map<List<ResultOrderDto>>(orders);
        }

      
        public async Task<OrderDetailDto?> GetByIdAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order is null)
                return null;

            return _mapper.Map<OrderDetailDto>(order);
        }

       
        public async Task UpdateStatusAsync(UpdateOrderStatusDto dto)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == dto.OrderId);

            if (order is null)
                throw new Exception("Order not found");

            
            if (order.Status == OrderStatus.Cancelled ||
                order.Status == OrderStatus.Completed)
                throw new Exception("Order status cannot be changed");

            order.Status = dto.Status;

            await _context.SaveChangesAsync();
        }


        public async Task CancelAsync(int orderId, string? reason)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order is null)
                throw new Exception("Order not found");

            if (order.Status != OrderStatus.Pending)
                throw new Exception("Only pending orders can be cancelled");

            order.Status = OrderStatus.Cancelled;
            order.CancelReason = reason;

            await _context.SaveChangesAsync();
        }
    }
}
