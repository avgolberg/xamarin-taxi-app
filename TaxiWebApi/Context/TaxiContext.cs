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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
