using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plotproject.Models
{
    public class ParkingSpot
    {
        [Key]
        public int Number { get; set; }
        [ConcurrencyCheck]
        [ForeignKey("License")]
        public String VehicleLicense { get; set; }
        public Vehicle Vehicle { get; set; }
        [Required]
        public ParkingType TypeId { get; set; }
    }
}

