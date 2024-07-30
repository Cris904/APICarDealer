using Microsoft.EntityFrameworkCore;
using CarDealershipAPI.Models;

namespace CarDealershipAPI.Data
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Car
            modelBuilder.Entity<Car>()
                .ToTable("Cars")
                .HasKey(c => c.Id);

            // Configuración de la entidad Customer
            modelBuilder.Entity<Customer>()
                .ToTable("Customers")
                .HasKey(c => c.Id);

            // Configuración de la entidad Sale
            modelBuilder.Entity<Sale>()
                .ToTable("Sales")
                .HasKey(s => s.Id);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Car)
                .WithMany()
                .HasForeignKey(s => s.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
