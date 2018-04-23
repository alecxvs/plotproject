using System;
using System.ComponentModel.DataAnnotations;

namespace plotproject.Models
{
    public class Vehicle
    {
        [Key]
        public string License { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Color { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
    }
}