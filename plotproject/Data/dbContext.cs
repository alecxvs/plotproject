using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebugEFCore;
using Microsoft.EntityFrameworkCore;
using plotproject.Models;

namespace plotproject.Models
{
    public class PLotContext : DbContext
    {
        public PLotContext (DbContextOptions<PLotContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableLogging(true);
        }

        public DbSet<plotproject.Models.Vehicle> Vehicle { get; set; }
        public DbSet<plotproject.Models.Ticket> Ticket { get; set; }
        public DbSet<plotproject.Models.ParkingType> ParkingType { get; set; }
        public DbSet<plotproject.Models.ParkingSpot> ParkingSpot { get; set; }
    }
}
