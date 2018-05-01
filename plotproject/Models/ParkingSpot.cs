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
        public String VehicleLicense { get; set; }
        [ForeignKey("VehicleLicense")]
        public virtual Vehicle Vehicle { get; set; }
        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public ParkingType Type { get; set; }

        public override string ToString()
        {
            return $"{Number} - {Type} (Occupant: {Vehicle})";
        }
    }
}

