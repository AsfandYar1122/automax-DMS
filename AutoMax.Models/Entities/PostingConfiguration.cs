using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoMax.Models.Entities
{
    public class PostingConfiguration
    {
        [Key]
        public int PostingConfigurationID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}