using AutoMax.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models.DataModel
{
    public class InventoryDDLs
    {
        public List<AutoEngine> AutoEngines { get; set; }
        public List<AutoDoor> AutoDoor { get; set; }
        public List<AutoTransmission> AutoTransmissions { get; set; }
        public List<AutoModelVM> AutoModel { get; set; }
        public List<SubModelVM> SubModels { get; set; }
        public List<AutoCondition> AutoConditions { get; set; }
        public List<AutoAirBag> AutoAirBags { get; set; }
        public List<AutoBodyStyle> AutoBodyStyles { get; set; }
        public List<AutoExteriorColor> AutoExteriorColors { get; set; }
        public List<AutoInteriorColor> AutoInteriorColors { get; set; }
        public List<AutoSteering> AutoSteerings { get; set; }
        public List<DriveType> DriveTypes { get; set; }
        public List<EngineCapacity> EngineCapacities { get; set; }
        public List<FuelType> FuelTypes { get; set; }
        public List<InventoryStatus> InventoryStatus { get; set; }
        public List<MakerVM> Makers { get; set; }
        public List<MediaPlayer> MediaPlayers { get; set; }
        public List<RoofType> RoofTypes { get; set; }
        public List<Upholstery> Upholsteries { get; set; }
        public List<VehclieTitle> VehclieTitles { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }
        public List<Year> Years { get; set; }
        public List<AutoUsedStatus> AutoUsedStatus { get; set; }
    }
    public class SubModelVM
    {
        public int SubModelID { get; set; }
        public string ModelName { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> AutoModelID { get; set; }
        public Nullable<int> LanguageID { get; set; }
    }
    public class AutoModelVM
    {
        public int AutoModelID { get; set; }
        public string ModelName { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public int? MakerID { get; internal set; }
    }
    public class MakerVM
    {
        public int MakerID { get; set; }
        public string Name { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<long> VehicleTypeID { get; set; }
    }
}