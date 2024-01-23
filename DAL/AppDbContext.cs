using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Car> Inventory { get; set; }
        public DbSet<TempAgreement> TempAgreements { get; set; }
        public DbSet<Agreement> Agreements { get; set; } 



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<TempAgreement>()
                .HasOne(agreement => agreement.Car)
                .WithMany()
                .HasForeignKey(agreement => agreement.CarId);

            builder.Entity<Agreement>()
                .HasOne(agreement => agreement.Car)
                .WithMany()
                .HasForeignKey(agreement => agreement.CarId);

            builder.Entity<Car>().Property(car => car.Availability)
                .HasConversion(
                status => status.ToString(),
                status => Enum.Parse<AvailabilityStatus>(status));

            builder.Entity<Car>().HasData(
                new Car { Id = 1, Maker = "Honda", Model = "City", RentalPrice = 2345.6, Availability = AvailabilityStatus.Available },
                new Car { Id = 2, Maker = "Toyota", Model = "Corolla", RentalPrice = 1899.99, Availability = AvailabilityStatus.Available },
    new Car { Id = 3, Maker = "Ford", Model = "Mustang", RentalPrice = 3456.75, Availability = AvailabilityStatus.Available },
    new Car { Id = 4, Maker = "Chevrolet", Model = "Cruze", RentalPrice = 1750.0, Availability = AvailabilityStatus.Available },
    new Car { Id = 5, Maker = "Nissan", Model = "Altima", RentalPrice = 1999.0, Availability = AvailabilityStatus.Available },
    new Car { Id = 6, Maker = "Hyundai", Model = "Elantra", RentalPrice = 1689.5, Availability = AvailabilityStatus.Available },
    new Car { Id = 7, Maker = "Volkswagen", Model = "Jetta", RentalPrice = 2200.25, Availability = AvailabilityStatus.Available },
    new Car { Id = 8, Maker = "Mazda", Model = "CX-5", RentalPrice = 2799.0, Availability = AvailabilityStatus.Available },
    new Car { Id = 9, Maker = "Subaru", Model = "Outback", RentalPrice = 2499.5, Availability = AvailabilityStatus.Available },
    new Car { Id = 10, Maker = "Tesla", Model = "Model Y", RentalPrice = 3999.99, Availability = AvailabilityStatus.Available },
    new Car { Id = 11, Maker = "Audi", Model = "A3", RentalPrice = 2999.0, Availability = AvailabilityStatus.Available },
    new Car { Id = 12, Maker = "BMW", Model = "X3", RentalPrice = 3499.75, Availability = AvailabilityStatus.Available },
    new Car { Id = 13, Maker = "Mercedes-Benz", Model = "C-Class", RentalPrice = 3899.0, Availability = AvailabilityStatus.Available },
    new Car { Id = 14, Maker = "Lexus", Model = "RX", RentalPrice = 3799.25, Availability = AvailabilityStatus.Available },
    new Car { Id = 15, Maker = "Jeep", Model = "Wrangler", RentalPrice = 2899.5, Availability = AvailabilityStatus.Available },
    new Car { Id = 16, Maker = "Land Rover", Model = "Range Rover", RentalPrice = 4999.0, Availability = AvailabilityStatus.Available });
        }

    }
}
