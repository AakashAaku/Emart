
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
    }
}