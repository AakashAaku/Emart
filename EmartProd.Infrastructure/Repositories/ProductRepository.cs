using EmartProd.Application.Interfaces;
using EmartProd.Domain.Entities;
using EmartProd.Infrastructure.EmartContext;
using Microsoft.EntityFrameworkCore;

namespace EmartProd.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EmartProdDbContext _context;
        public ProductRepository(EmartProdDbContext context)
        {
            _context = context;
            
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}