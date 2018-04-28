using System;
using System.ComponentModel.DataAnnotations;

namespace plotproject.Models
{
    public class ParkingType
    {
        public int Id { get; set; }
        [StringLength(250)]
        [Required]
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
