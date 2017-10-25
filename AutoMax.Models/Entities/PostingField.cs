using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoMax.Models.Entities
{
    public class PostingField
    {
        [Key]
        public int PostingFieldID { get; set; }
        public int PostingSiteID { get; set; }
        public PostingSite PostingSite { get; set; }
        public string FieldName { get; set; }
        public string LinkedFieldName{ get; set; }
        public string ArabicFieldName { get; set; }
        public string ArabicLinkedFieldName { get; set; }
        public string DisplayName { get; set; }
        public string ArabicDisplayName { get; set; }
        public bool IncludeInPosting { get; set; }
        public Nullable<int> IncludeOrder { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
