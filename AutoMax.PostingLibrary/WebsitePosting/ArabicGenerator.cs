using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMax.Models;
using AutoMax.Models.Entities;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public class ArabicGenerator : PostingDetailsGenerator
    {
        public ArabicGenerator()
        { }
        protected override string GetTitle(VehicleWizard vehicle)
        {
            return String.Format("{1} {2} {0} {4} {3}"
                , vehicle.VehclieTitle != null && vehicle.VehclieTitle.Title == "NEW" ? "جديدة " : ""
                , vehicle.Maker.ArabicName
                , vehicle.AutoModel.ArabicModelName
                , vehicle.VehicleID
                , "المرجعية"); ;
        }
        protected override string GetDescription(VehicleWizard vehicle)
        {
            return vehicle.ArabicDescription;
        }
        protected override string GetPostingFieldFieldName(PostingField p)
        {
            return p.ArabicFieldName;
        }
        protected override string GetPostingFieldLinkedFieldName(PostingField p)
        {
            return p.ArabicLinkedFieldName;
        }
        protected override string GetPostingFieldDisplayName(PostingField p)
        {
            return p.ArabicDisplayName;
        }
        protected override void updateDescription(string name, string value)
        {
            description += string.Format("{0}: {1}{2}", name, value, Environment.NewLine);
        }
    }
}
