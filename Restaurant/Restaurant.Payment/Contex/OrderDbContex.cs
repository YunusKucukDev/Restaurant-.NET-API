using Microsoft.EntityFrameworkCore;
using Restaurant.Payment.Entities;

namespace Restaurant.Payment.Contex
{
    public class PaymentDbContex : DbContext
    {
        public PaymentDbContex(DbContextOptions<PaymentDbContex> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,7004;Database=RestaurantPaymentDb;User Id=sa;Password=A12b13c14.;TrustServerCertificate=True;");
        }

        public DbSet<PaymentDb> Payments { get; set; }
    }
}
