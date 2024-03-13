using System.Text.Json;
using EmartProd.Domain.Entities;
using EmartProd.Infrastructure.EmartContext;

namespace EmartProd.Infrastructure.SeedFile
{
    public class EmartProdContextSeed
    {
        public static async Task SeedAppDataAysnc(EmartProdDbContext context)
        {
            if (!context.ProductBrands.Any())
            {
                 var brandJsonData = File.ReadAllText(@"D:\TryCatchLearnAngularCoreEcommerce\EmartProd\EmartProd.Infrastructure/SeedFile/brands.json");
                 var brandData = JsonSerializer.Deserialize<List<ProductBrand>>(brandJsonData);
                 context.ProductBrands.AddRange(brandData);
            }
            if (!context.ProductTypes.Any())
            {
                 var prodTypeJsonData = File.ReadAllText(@"D:\TryCatchLearnAngularCoreEcommerce\EmartProd\EmartProd.Infrastructure/SeedFile/types.json");
                 var prodTypeData = JsonSerializer.Deserialize<List<ProductType>>(prodTypeJsonData);
                 context.ProductTypes.AddRange(prodTypeData);
            }
            if (!context.Products.Any())
            {
                 var productJsonData = File.ReadAllText(@"D:\TryCatchLearnAngularCoreEcommerce\EmartProd\EmartProd.Infrastructure/SeedFile/products.json");
                 var productData = JsonSerializer.Deserialize<List<Product>>(productJsonData);
                 context.Products.AddRange(productData);
            }

            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}