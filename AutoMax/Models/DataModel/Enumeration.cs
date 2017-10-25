using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models.DataModel
{
    /// <summary>
    /// Add Dropdowns will have their child items listed here
    /// They will be differentiated by their EnumerationType 
    /// </summary>
    
    public class Enumeration
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual EnumerationType Type { get; set; }
    }
}