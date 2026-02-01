using Microsoft.EntityFrameworkCore;
using Restaurant.Discount.Entities;
using System.Collections.Generic;

namespace Restaurant.Discount.Contex
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,7002;Database=RestaurantDiscountDb;User Id=sa;Password=A12b13c14.;TrustServerCertificate=True;");
        }

        public DbSet<DiscountCoupon> Discounts { get; set; }
    }
}
