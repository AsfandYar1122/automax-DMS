﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class AutoInteriorColor
    {
        [Key]
        public long AutoInteriorColorID { get; set; }
        public string InteriorColor { get; set; }
        public string ArabicInteriorColor { get; set; }
        public int Value { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public ICollection<VehicleWizard> Vehicle { get; set; }
    }
}