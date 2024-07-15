using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BorusanDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BorusanDB; Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Car entity configuration
            modelBuilder.Entity<Car>().ToTable("Cars").HasKey(c => c.Id);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Color)
                .WithMany(cl => cl.Cars)
                .HasForeignKey(c => c.ColorId);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Transmission)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.TransmissionId);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Fuel)
                .WithMany(f => f.Cars)
                .HasForeignKey(c => c.FuelId);

            // Brand entity configuration
            modelBuilder.Entity<Brand>().ToTable("Brands").HasKey(b => b.Id);
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Cars)
                .WithOne(c => c.Brand)
                .HasForeignKey(c => c.BrandId);
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Models)
                .WithOne(m => m.Brand)
                .HasForeignKey(m => m.BrandId);

            // Color entity configuration
            modelBuilder.Entity<Color>().ToTable("Colors").HasKey(cl => cl.Id);
            modelBuilder.Entity<Color>()
                .HasMany(cl => cl.Cars)
                .WithOne(c => c.Color)
                .HasForeignKey(c => c.ColorId);

            // Fuel entity configuration
            modelBuilder.Entity<Fuel>().ToTable("Fuels").HasKey(f => f.Id);
            modelBuilder.Entity<Fuel>()
                .HasMany(f => f.Cars)
                .WithOne(c => c.Fuel)
                .HasForeignKey(c => c.FuelId);

            // Model entity configuration
            modelBuilder.Entity<Model>().ToTable("Models").HasKey(m => m.Id);
            modelBuilder.Entity<Model>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId);
            //modelBuilder.Entity<Model>()
            //    .HasMany(m => m.Cars)
            //    .WithOne(c => c.Model)
            //    .HasForeignKey(c => c.ModelId);

            // Transmission entity configuration
            modelBuilder.Entity<Transmission>().ToTable("Transmissions").HasKey(t => t.Id);
            modelBuilder.Entity<Transmission>()
                .HasMany(t => t.Cars)
                .WithOne(c => c.Transmission)
                .HasForeignKey(c => c.TransmissionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}