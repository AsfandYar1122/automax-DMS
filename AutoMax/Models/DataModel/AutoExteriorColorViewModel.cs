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
    
    public class AutoExteriorColorViewModel
    {
        public AutoExteriorColorViewModel()
        {
            this.VehicleWizards = new HashSet<VehicleWizardViewModel>();
        }
    
        public long AutoExteriorColorID { get; set; }
        public string ExteriorColor { get; set; }
        public int Value { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public virtual ICollection<VehicleWizardViewModel> VehicleWizards { get; set; }
    }
}
