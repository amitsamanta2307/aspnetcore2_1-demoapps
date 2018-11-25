using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>(property =>
            {
                property.Property(p => p.Name).HasMaxLength(25);
                property.Property(p => p.Description).HasMaxLength(75);
                property.Property(p => p.Price).HasColumnType("decimal(18, 2)");
                property.Property(p => p.Category).HasMaxLength(15);
            });
        }
    }
}
