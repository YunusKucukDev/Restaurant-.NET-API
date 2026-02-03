using Microsoft.EntityFrameworkCore;
using Restaurant.Order.Domain.Entities;

namespace Restaurant.Order.Contex
{
    public class OrderDbContex : DbContext
    {
        public OrderDbContex(DbContextOptions<OrderDbContex> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,7003;Database=RestaurantOrderDb;User Id=sa;Password=A12b13c14.;TrustServerCertificate=True;");
        }

        public DbSet<OrderEntity> Orders { get; set; }
    }
}
