using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class AutoBodyStyle
    {
        [Key]
        public int AutoBodyStyleID { get; set; }
        public string BodyStyle { get; set; }
        public string ArabicBodyStyle { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
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
