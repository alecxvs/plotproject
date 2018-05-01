using plotproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plotproject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PLotContext context)
        {
            context.Database.EnsureCreated();

            if (context.ParkingType.Any())
                return;

            var standardType = new ParkingType { Description = "Standard" };
            var handicapType = new ParkingType { Description = "Handicap" };
            context.ParkingType.Add(standardType);  
            context.ParkingType.Add(handicapType);
            context.SaveChanges();

            foreach (var i in Enumerable.Range(1, 24))
            {
                context.ParkingSpot.Add(new ParkingSpot { Type = standardType });
            }

            context.SaveChanges();

            foreach (var i in Enumerable.Range(1, 6))
            {
                context.ParkingSpot.Add(new ParkingSpot { Type = handicapType });
            }

            context.SaveChanges();
        }
    }
}
