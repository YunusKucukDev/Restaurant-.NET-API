using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Order.Contex;
using Restaurant.Order.Domain.Entities;
using Restaurant.Order.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // Yeni Sipariş Oluşturma
        public async Task CreateAsync(CreateOrderDto dto)
        {
            var entity = _mapper.Map<OrderEntity>(dto);
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Sipariş ID'sine Göre Getirme
        public async Task<List<ResultOrderDto>> GetByIdAsync(int orderId)
        {
            var values = await _context.Orders
                  .Include(x => x.Items) // <-- EKSİK OLAN VE EKLEMEN GEREKEN SATIR BU
                  .Where(x => x.Id == orderId)
                  .ToListAsync();

            return _mapper.Map<List<ResultOrderDto>>(values);
        }

        // Kullanıcı ID'sine Göre Siparişleri Getirme
        public async Task<List<ResultOrderDto>> GetByUserIdAsync(string userId)
        {
            // Kullanıcıya ait tüm siparişleri listeler
            var values = await _context.Orders
           .Include(x => x.Items) // <-- Bu satır eksikse ürünler gelmez!
           .Where(x => x.UserId == userId)
           .ToListAsync();

            return _mapper.Map<List<ResultOrderDto>>(values);
        }
    }
}