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
    public class SaleProductConfig : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> entity)
        {
            entity.ToTable("SaleProduct");
            entity.HasKey(sp => sp.ShoppingCartId);
            entity.Property(sp => sp.Quantity).IsRequired();
            entity.Property(sp => sp.Price).IsRequired();
            entity.Property(sp => sp.Discount);
        }
    }
}
