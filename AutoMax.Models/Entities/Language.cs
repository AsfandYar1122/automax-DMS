using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public ICollection<AutoAirBag> AutoAirBags { get; set; }
        public ICollection<AutoBodyStyle> AutoBodyStyles { get; set; }
        public ICollection<AutoCondition> AutoConditions { get; set; }
        public ICollection<AutoDoor> AutoDoors { get; set; }
        public ICollection<AutoEngine> AutoEngines { get; set; }
        public ICollection<AutoExteriorColor> AutoExteriorColors { get; set; }
        public ICollection<AutoGlobalization> AutoGlobalizations { get; set; }
        public ICollection<AutoInteriorColor> AutoInteriorColors { get; set; }
        public ICollection<AutoModel> AutoModels { get; set; }
        public ICollection<AutoSteering> AutoSteerings { get; set; }
        public ICollection<AutoTransmission> AutoTransmissions { get; set; }
        public ICollection<AutoTransmissionMapping> AutoTransmissionMappings { get; set; }
        public ICollection<DriveType> DriveTypes { get; set; }
        public ICollection<EngineCapacity> EngineCapacities { get; set; }
        public ICollection<FuelType> FuelTypes { get; set; }
        public ICollection<InventoryStatus> InventoryStatus { get; set; }
        public ICollection<Maker> Makers { get; set; }
        public ICollection<MakerMapping> MakerMappings { get; set; }
        public ICollection<MediaPlayer> MediaPlayers { get; set; }
        public ICollection<MotorizedType> MotorizedTypes { get; set; }
        public ICollection<PostingDetail> PostingDetails { get; set; }
        public ICollection<RoofType> RoofTypes { get; set; }
        public ICollection<SubModel> SubModels { get; set; }
        public ICollection<SubModelMapping> SubModelMappings { get; set; }
        public ICollection<Upholstery> Upholsteries { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<VehclieTitle> VehclieTitles { get; set; }
        public ICollection<VehicleImage> VehicleImages { get; set; }
        public ICollection<VehiclePrice> VehiclePrices { get; set; }
        public ICollection<VehicleTemplate> VehicleTemplates { get; set; }
        public ICollection<VehicleType> VehicleTypes { get; set; }
        public ICollection<VehicleWizard> Vehicles { get; set; }
        public ICollection<Year> Years { get; set; }
        public ICollection<Milage> Milages { get; set; }
    }
}
