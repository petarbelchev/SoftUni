using CarDealer.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarDealer.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        public CarDealerContext()
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCar> PartCars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=AS3\SQLEXPRESS;Database=CarDealer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartCar>(e =>
            {
                e.HasKey(k => new { k.CarId, k.PartId });

                e.HasOne(c => c.Car).WithMany(p => p.PartCars).HasForeignKey(c => c.CarId);

                e.HasOne(p => p.Part).WithMany(c => c.PartCars).HasForeignKey(p => p.PartId);
            });

            modelBuilder.Entity<Part>(e =>
            {
                e.HasOne(p => p.Supplier).WithMany(s => s.Parts).HasForeignKey(p => p.SupplierId);
            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.HasOne(s => s.Car).WithMany(c => c.Sales).HasForeignKey(s => s.CarId);
                e.HasOne(s => s.Customer).WithMany(c => c.Sales).HasForeignKey(s => s.CustomerId);
            });
        }
    }
}
