using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models.DataModel
{
    public class UserRoleViewModel
    {
        public int UserRoleID { get; set; }
        public string Role { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int TotalUsers { get; set; }
    }
}