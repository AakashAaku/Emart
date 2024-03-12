using System.Collections.Generic;
using EmartProd.Domain.Entities;

namespace EmartProd.Application.Interfaces
{
    public interface IProductRepository
    {
       Task<Product> GetProductByIdAsync(int id);
       Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}