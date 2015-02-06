using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DD.TrafficLight.Web.Models
{
    public class TrafficLightConfiguration
    {
        [Key]
        public int TrafficLightID { get; set; }

        public int Red { get; set; }
        public int Green { get; set; }
        public int Yellow { get; set; }
        public bool MaintenanceMode { get; set; }
    }
}