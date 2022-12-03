using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiWebApi.Models;

namespace TaxiWebApi.Context
{
    public class TaxiContext : DbContext
    {
        public TaxiContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Rider> Riders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverOption> DriverOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Parameter>()
                .Property(e => e.ParameterId)
                .HasConversion<int>();

            modelBuilder
                .Entity<Parameter>().HasData(
                    Enum.GetValues(typeof(ParameterId))
                        .Cast<ParameterId>()
                        .Select(e => new Parameter()
                        {
                            ParameterId = e,
                            Name = e.ToString()
                        })
                );

            modelBuilder
               .Entity<DriverOption>()
               .Property(e => e.DriverOptionId)
               .HasConversion<int>();

            modelBuilder
                .Entity<DriverOption>().HasData(
                    Enum.GetValues(typeof(DriverOptionId))
                        .Cast<DriverOptionId>()
                        .Select(e => new DriverOption()
                        {
                            DriverOptionId = e,
                            Name = e.ToString()
                        })
                );
        }
    }
}
