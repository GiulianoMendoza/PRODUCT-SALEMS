using Domain.Entities;
using Infraestructure.Config;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;



namespace Infraestructure.Persistence
{
    public class AppDBContext : DbContext
    {
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleProduct> SaleProduct { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Caregory> Caregory { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SaleProductConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductData());
            modelBuilder.ApplyConfiguration(new CaregoryConfig());
            modelBuilder.ApplyConfiguration(new CategoryData());
        }
    }
}
