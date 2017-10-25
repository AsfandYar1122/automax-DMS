using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMax.Models.Entities
{
    public class PostingDetail
    {
        [Key]
        public int PostingDetailID { get; set; }
        public string PostingTitle { get; set; }
        public string PostingDescription { get; set; }
        public bool PublishPrice { get; set; }
        public bool Negotiable { get; set; }
        public int PostingStatusID { get; set; }
        public PostingStatus PostingStatus { get; set; }
        public int PostingSiteID { get; set; }
        public PostingSite PostingSite { get; set; }
        public PostingSiteUser PostingSiteUser { get; set; }
        public int Retries { get; set; }
        public int RetryCount { get; set; }
        public string PostingError { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public VehicleWizard VehicleWizard { get; set; }
        public long VehicleWizardId{ get; set; }

    }
}
