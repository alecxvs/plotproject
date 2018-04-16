using System;

namespace plotproject.Models
{
    public class Vehicle
    {
        public string License { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
    }
}