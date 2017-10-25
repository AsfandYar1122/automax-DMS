﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class VehicleType 
    {
        [Key]
        public long VehicleTypeID { get; set; }
        public string Type { get; set; }
        public string ArabicType { get; set; }
        public int VehicleTypeValue { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public ICollection<VehicleWizard> Vehicles { get; set; }
        public ICollection<Maker> Makers { get; set; }
    }
}