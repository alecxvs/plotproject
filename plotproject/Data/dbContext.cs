using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plotproject.Models;

namespace plotproject.Models
{
    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public DbSet<plotproject.Models.Vehicle> Vehicle { get; set; }
        public DbSet<plotproject.Models.Ticket> Ticket { get; set; }
        public DbSet<plotproject.Models.ParkingType> ParkingType { get; set; }
    }
}
