using System;

namespace plotproject.Models
{
    public class Ticket
    {
        public string in_time { get; set; }
        public string out_time { get; set; }
        public Vehicle_license Vehicle_license { get; set; }
        public Type_id Type_id { get; set; }
    }
}