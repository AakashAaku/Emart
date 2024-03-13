
using System.Reflection;
using EmartProd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmartProd.Infrastructure.EmartContext
{
    public class EmartProdDbContext : DbContext
    {
        public EmartProdDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}