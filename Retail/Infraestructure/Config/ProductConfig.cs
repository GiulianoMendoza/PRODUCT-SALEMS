using Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product");
            entity.HasKey(p => p.ProductId);
            entity.Property(p => p.Name).HasMaxLength(100).IsRequired();
            entity.Property(p => p.Description);
            entity.Property(p => p.Price).HasConversion<decimal>().IsRequired();
            entity.Property(p => p.Discount);
            entity.Property(p => p.ImageUrl);
            //Relación con Categoria
            entity.HasOne(p => p.Categoria).WithMany(c => c.Products).HasForeignKey(p => p.Category).IsRequired();
            //Relación con Saleproduct
            entity.HasMany<SaleProduct>(p => p.SaleProducts).WithOne(sp => sp.Producto).HasForeignKey(sp => sp.Product).IsRequired();
        }

    }
}
