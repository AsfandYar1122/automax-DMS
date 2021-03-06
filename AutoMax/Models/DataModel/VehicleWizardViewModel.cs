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
    using AutoMax.Models.Entities;
    using System;
    using System.Collections.Generic;

    public class VehicleWizardViewModel
    {
        public long VehicleID { get; set; }
        public Nullable<int> InventoryStatusID { get; set; }
        public string StockNumber { get; set; }
        public string MMCode { get; set; }
        public string PlateNumber { get; set; }
        public Nullable<int> MotorizedTypeID { get; set; }
        public string VIN { get; set; }
        public Nullable<int> YearID { get; set; }
        public Nullable<int> MakerID { get; set; }
        public Nullable<int> AutoModelID { get; set; }
        public Nullable<int> SubModelID { get; set; }
        public string FreeText { get; set; }
        public int AutoBodyStyleID { get; set; }
        public string Odometer { get; set; }
        public long AutoExteriorColorID { get; set; }
        public Nullable<long> AutoInteriorColorID { get; set; }
        public Nullable<long> AutoSteeringID { get; set; }
        public Nullable<long> AutoDoorsID { get; set; }
        public Nullable<long> AutoEngineID { get; set; }
        public Nullable<long> AutoTransmissionID { get; set; }
        public Nullable<long> FuelTypeID { get; set; }
        public Nullable<long> DriveTypeID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> AutoConditionID { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public Nullable<decimal> VehiclePriceValue { get; set; }
        public string WarantyText { get; set; }
        public string Description { get; set; }
        public Nullable<long> UserID { get; set; }
        public Nullable<int> AutoAirBagID { get; set; }
        public Nullable<int> EngineCapacityID { get; set; }
        public Nullable<int> UpholsteryID { get; set; }
        public Nullable<int> VehicleTitleID { get; set; }
        public List<VehclieTitle> VehclieTitles { get; set; }
        public List<Upholstery> Upholstery { get; set; }
        public Nullable<int> RoofTypeID { get; set; }
        public List<RoofType> RoofType { get; set; }
        public Nullable<int> MediaPlayerID { get; set; }
        public List<VehicleImage> VehicleImages { get; set; }
        public List<AutoModel> AutoModels { get; set; }
        public List<Maker> Makers { get; set; }
        public List<InventoryStatus> InventoryStatusList { get; set; }
        public List<Year> Years { get; set; }
        public List<AutoCondition> AutoConditions { get; set; }
        public List<SubModel> SubModels { get; set; }
        public List<AutoSteering> AutoSteerings { get; set; }
        public List<AutoExteriorColor> AutoExteriorColors { get; set; }
        public List<AutoInteriorColor> AutoInteriorColors { get; set; }
        public List<AutoTransmission> AutoTransmissions { get; set; }
        public List<VehiclePrice> VehiclePrices { get; set; }
        public string MilageValue { get; set; }
    }
}
