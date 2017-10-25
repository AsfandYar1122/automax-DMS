using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class VehicleImage
    {
        [Key]
        public long VehicleImageID { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public VehicleWizard VehicleWizard { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public Nullable<int> IsFeatured { get; set; }
        public string ExternalURL { get; set; }
    }

    public class VehiclePartImage
    {
        [Key]
        public long VehiclePartImageID { get; set; }
        public string ImagePath { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public VehicleWizard VehicleWizard { get; set; }
        public int VIRID { get; set; }
        [ForeignKey("VIRID")]
        public VIR VIR { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
    }
}
