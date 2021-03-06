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

    public class VehiclePriceViewModel
    {
        public int VehiclePriceID { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal ByNowWholeSalePrice { get; set; }
        public decimal ConsignedPrice { get; set; }
        public decimal SaleCost { get; set; }
        public decimal MSRP { get; set; }
        public decimal BookValue { get; set; }
        public decimal InternetPrice { get; set; }
        public decimal AlternativePrice1 { get; set; }
        public decimal AlternativePrice2 { get; set; }
        public decimal AlternativePrice3 { get; set; }
        public long PriceVehicleID { get; set; }
        public long VehicleID { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public virtual VehicleWizardViewModel VehicleWizard { get; set; }
    }
}
