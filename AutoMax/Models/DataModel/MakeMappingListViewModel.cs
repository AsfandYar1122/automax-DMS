using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models.DataModel
{
    public class MakeMappingListViewModel
    {
        public int ID { get; set; }

        public string MakeName { get; set; }
        public int TotalCount { get; set; }
        public int MappedCount { get; set; }
    }


    public class MakeMappingViewModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }

        public string EntityName { get; set; }
        public string EntityNameForCompany { get; set; }

        public List<MappingIDName> MappingIDNames { get; set; }


    }

    public class MappingIDName
    {
        public int MappingID { get; set; }
        public string MappingName { get; set; }
        public string MappingNameForCompany { get; set; }
    }

}