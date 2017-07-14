using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace samples
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Engine_Capacity { get; set; }
        public string Engine_Type { get; set; }
        public string Horse_Power { get; set; }
        public string Max_Speed { get; set; }
        public string Acceleration { get; set; }
        public string Fuel_Type { get; set; }
        public string Fuel_Consuption { get; set; }
        public string Type { get; set; }
        public string Doors { get; set; }
        public string Price { get; set; }
	}

}