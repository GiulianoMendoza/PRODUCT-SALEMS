using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Config
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entity)
        {
            entity.ToTable("Sale");
            entity.HasKey(s => s.SaleId);
            entity.Property(s => s.TotalPay).IsRequired();
            entity.Property(s => s.Subtotal).IsRequired();
            entity.Property(s => s.TotalDiscount).IsRequired();
            entity.Property(s => s.Taxes).IsRequired();
            entity.Property(s => s.Date).IsRequired();
            //Relación con SaleProduct
            entity.HasMany<SaleProduct>(s => s.SaleProducts).WithOne(sp => sp.Venta).HasForeignKey(sp => sp.Sale).IsRequired();
        }
    }
}
