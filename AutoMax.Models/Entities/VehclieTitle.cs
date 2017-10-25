using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class VehclieTitle 
    {
        [Key]
        public int VehicleTitleID { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }

        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public List<VehicleWizard> Vehicles { get; set; }
    }
}
