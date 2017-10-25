using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models.DataModel
{
    public class VehicleColorViewModel
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public bool IsInterior { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}