using System;

namespace plotproject.Models
{
    public class Parking_spot
    {
       // Made Number a String because we will need to read that data
       // and all other data is Strings, worried we will get error 
       // about converting int to String. If it should be and int 
       // we can change it.
        public String Number { get; set; }
        public Vehicle_license Vehicle_license { get; set; }
        public Type_id Type_id { get; set; }
    }
}

