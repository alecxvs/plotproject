using System;
using System.ComponentModel.DataAnnotations;

namespace plotproject.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        [Required]
        public Vehicle VehicleId { get; set; }
        [Required]
        public ParkingType TypeId { get; set; }
    }
}