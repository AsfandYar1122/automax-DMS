using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMax.Models.Entities
{
    public class VehicleTitleMapping
    {
        [Key]
        public int VehicleTitleMappingID { get; set; }
        public VehclieTitle VehicleTitle { get; set; }
        public int VehicleTitleID { get; set; }
        public string OpensooqName { get; set; }
        public string HarajName { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
    }
}