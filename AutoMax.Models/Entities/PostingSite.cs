using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoMax.Models.Entities
{
    public class PostingSite
    {
        [Key]
        public int PostingSiteID { get; set; }
        public string PostingSiteName { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<PostingField> PostingFields { get; set; }
        public ICollection<PostingDetail> PostingDetails { get; set; }
 
    }
}
