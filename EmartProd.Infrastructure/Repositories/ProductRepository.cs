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

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(e=>e.ProductBrands).Include(e=>e.ProductTypes).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(e=>e.ProductBrands).Include(e=>e.ProductTypes).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}