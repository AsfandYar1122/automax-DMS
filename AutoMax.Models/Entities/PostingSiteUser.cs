using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoMax.Models.Entities
{
    public class PostingSiteUser
    {
        [Key]
        public int PostingSiteUserID { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string Phonenumber { get; set; }
        public PostingSite PostingSite { get; set; }
        public int PostingSiteID { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}