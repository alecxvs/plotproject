using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plotproject.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        [Required]
        public String VehicleLicense { get; set; }
        [ForeignKey("VehicleLicense")]
        public Vehicle Vehicle { get; set; }
        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public ParkingType Type { get; set; }

        public override string ToString()
        {
            return $"{Id} ({Vehicle}) [{Type}] {InTime} to {OutTime}";
        }
    }
}