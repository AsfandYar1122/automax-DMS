using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class AutoModel
    {
        [Key]
        public int AutoModelID { get; set; }
        public string ModelName { get; set; }
        public string ArabicModelName { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public ICollection<SubModel> SubModels { get; set; }
        public ICollection<VehicleWizard> Vehicle { get; set; }
        public Nullable<int> MakerID { get; set; }
        [ForeignKey("MakerID")]
        public Maker Maker { get; set; }
    }
}
