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
        public ParkingType TypeId { get; set; }
    }
}