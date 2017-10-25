using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models.DataModel
{
    public class VehicleViewModel
    {
        public string UpholsteryName { get; set; }
        public string RoofTypeName { get; set; }
        public long VehicleID { get; set; }
        public string VehicleAudio { get; set; }
        public string VehicleTitle { get; set; }
        public string InventoryStatus { get; set; }
        public string StockNumber { get; set; }
        public string MMCode { get; set; }
        public string PlateNumber { get; set; } //(i.e.Automax)
        public string VIN { get; set; }//(i.e.e Budget)
        public string YearName { get; set; }//(i.e.Hyundai)
        public string Maker { get; set; } //(i.e.Elantra)
        public string AutoModelName { get; set; }
        public string SubModelName { get; set; }
        public string FreeText { get; set; } //Sub Model(i.e.STD )
        public string BodyStyle { get; set; }
        public string Odometer { get; set; } //Transmission(i.e.A/T )
        public string ExteriorColor { get; set; } //(i.e.KMHDG41C8EU080267 )
        public string InteriorColor { get; set; } //Plate No
        public string AutoSteering { get; set; } //Milage
        public string AutoDoor { get; set; }
        public string EngineName { get; set; }//Year
        public string AutoTransmission { get; set; }
        public string FuelType { get; set; }
        public string DriveType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AutoCondition { get; set; }
        public Nullable<decimal> VehiclePrice { get; set; }
        public string WarantyText { get; set; }
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public string OwnerName { get; set; }
        public Nullable<int> AutoAirBag { get; set; }
        public string EngineCapacity { get; set; }
        public Nullable<bool> IsFeatured { get; set; }

        public Nullable<bool> IsFacebook { get; set; }
        public Nullable<bool> HasDealerImages { get; set; }
        public Nullable<double> VIRCompletenessPercentage { get; set; }
        public Nullable<double> TotalRatting { get; set; }
        public string ImageName { get; set; }
        public string VehicleType { get; set; }
        public Nullable<int> PublishedOnHaraj { get; set; }
        public string HarajID { get; set; }
        public Nullable<int> PublishedOnOpenSouq { get; set; }
        public string OpenSouqID { get; set; }
        public string TopStyle { get; set; }
        public string AutoWheel { get; set; }
        public string Milage { get; set; }
        public string AutoUsedStatus { get; set; }
        public Nullable<bool> Has360 { get; set; }
        public string VehicleAddress { get; set; }

        public string ImageName2 { get; set; }

        public string VehicleOptions { get; set; }
        public string Options { get; set; }
    }
}