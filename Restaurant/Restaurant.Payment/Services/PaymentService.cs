using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Payment.Contex;
using Restaurant.Payment.Dtos;
using Restaurant.Payment.Entities; // PaymentDb entity'sinin olduğu yer

namespace Restaurant.Payment.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentDbContex _context;
        private readonly IMapper _mapper;

        public PaymentService(PaymentDbContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Tüm ödemeleri getir
        public async Task<List<ResultPaymentDto>> GetAllPayments()
        {
            var values = await _context.Payments.ToListAsync();
            return _mapper.Map<List<ResultPaymentDto>>(values);
        }

        // ID'ye göre ödeme getir
        public async Task<ResultPaymentDto> GetPaymentById(int id)
        {
            var value = await _context.Payments.FindAsync(id);
            return _mapper.Map<ResultPaymentDto>(value);
        }

        // Sipariş ID'sine göre ödeme getir
        public async Task<ResultPaymentDto> GetPaymentByOrderId(int orderId)
        {
            var value = await _context.Payments.FirstOrDefaultAsync(x => x.OrderId == orderId);
            return _mapper.Map<ResultPaymentDto>(value);
        }

        // Kullanıcı ID'sine göre ödeme getir
        public async Task<ResultPaymentDto> GetPaymentByUserId(int userId)
        {
            var value = await _context.Payments.FirstOrDefaultAsync(x => x.UserId == userId.ToString());
            return _mapper.Map<ResultPaymentDto>(value);
        }

        // Yeni ödeme oluştur
        public async Task CreatePayment(CreatePaymentDto createPaymentDto)
        {
            var value = _mapper.Map<PaymentDb>(createPaymentDto);
            _context.Payments.Add(value);
            await _context.SaveChangesAsync();
        }

        // Ödeme seçeneğini (Kart/Nakit) güncelleme
        public async Task DefinePaymentOption(int orderId, bool option)
        {
            var value = await _context.Payments.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (value != null)
            {
                value.ChoisePaymet = option;
                await _context.SaveChangesAsync();
            }
        }
    }
}