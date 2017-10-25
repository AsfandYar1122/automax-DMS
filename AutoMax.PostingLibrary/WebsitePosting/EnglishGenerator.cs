using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMax.Models;
using AutoMax.Models.Entities;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public class EnglishGenerator : PostingDetailsGenerator
    {
        public EnglishGenerator()
        { }
        protected override string GetTitle(VehicleWizard vehicle)
        {
            return String.Format("{0}{1} {2} Ref {3}"
                , vehicle.VehclieTitle.Title == "NEW" ? "New " : ""
                , vehicle.Maker.Name
                , vehicle.AutoModel.ModelName
                , vehicle.VehicleID); ;
        }
        protected override string GetDescription(VehicleWizard vehicle)
        {
            return vehicle.Description;
        }
        protected override string GetPostingFieldFieldName(PostingField p)
        {
            return p.FieldName;
        }
        protected override string GetPostingFieldLinkedFieldName(PostingField p)
        {
            return p.LinkedFieldName;
        }
        protected override string GetPostingFieldDisplayName(PostingField p)
        {
            return p.DisplayName;
        }
        protected override void updateDescription(string name, string value)
        {
            description += string.Format("{0}: {1}{2}", name, value, Environment.NewLine);
        }
    }
}
