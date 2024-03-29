using EmartProd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmartProd.Infrastructure.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(p=>p.Id).IsRequired();
           builder.Property(p=>p.Name).IsRequired().HasMaxLength(200);
           builder.Property(p=>p.Description).IsRequired().HasMaxLength(300);
           builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
           builder.Property(p=>p.ImageUrl).IsRequired();
           builder.HasOne(p=>p.ProductBrands).WithMany().HasForeignKey(p=>p.ProductBrandId);
           builder.HasOne(p=>p.ProductTypes).WithMany().HasForeignKey(p=>p.ProductTypeId);

        }
    }
}