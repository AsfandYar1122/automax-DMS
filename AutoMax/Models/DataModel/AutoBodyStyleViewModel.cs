//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoMax.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public class AutoBodyStyleViewModel
    {
        public AutoBodyStyleViewModel()
        {
            this.VehicleWizards = new HashSet<VehicleWizardViewModel>();
        }
    
        public int AutoBodyStyleID { get; set; }
        public string BodyStyle { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public virtual ICollection<VehicleWizardViewModel> VehicleWizards { get; set; }
    }
}
