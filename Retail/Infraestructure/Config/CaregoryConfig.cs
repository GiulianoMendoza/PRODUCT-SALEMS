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
    public class CaregoryConfig : IEntityTypeConfiguration<Caregory>
    {
        public void Configure(EntityTypeBuilder<Caregory> entity)
        {
            entity.ToTable("Caregory");
            entity.HasKey(c => c.CategoryId);
            entity.Property(c => c.Name).HasMaxLength(100).IsRequired();
            //Relación con Product
            entity.HasMany<Product>(c => c.Products).WithOne(p => p.Categoria).HasForeignKey(p => p.Category).IsRequired();
        }
    }
}
