using AutoMax.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models
{
    public class AutoMaxContext : DbContext
    {
        public AutoMaxContext()
            : base("AMConnectionStr")
        {
        }

        public DbSet<AutoUsedStatus> AutoUsedStatus { get; set; }
        public DbSet<AutoBodyStyle> AutoBodyStyles { get; set; }
        public DbSet<AutoCondition> AutoConditions { get; set; }
        public DbSet<AutoDoor> AutoDoors { get; set; }
        public DbSet<AutoEngine> AutoEngines { get; set; }
        public DbSet<AutoExteriorColor> AutoExteriorColors { get; set; }
        public DbSet<AutoInteriorColor> AutoInteriorColors { get; set; }
        public DbSet<AutoModel> AutoModels { get; set; }
        public DbSet<AutoSteering> AutoSteerings { get; set; }
        public DbSet<AutoTransmission> AutoTransmissions { get; set; }
        public DbSet<DriveType> DriveTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<InventoryStatus> InventoryStatus { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<AutoInventoryStatusHistory> AutoInventoryStatusHistory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VehclieTitle> VehclieTitles { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<VehicleVideo> VehicleVideo { get; set; }
        public DbSet<VehiclePartImage> VehiclePartImage { get; set; }
        public DbSet<VehiclePrice> VehiclePrices { get; set; }
        public DbSet<VehicleTemplate> VehicleTemplates { get; set; }
        public DbSet<SubModel> SubModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleWizard> VehicleWizards { get; set; }
        public DbSet<VehicleAddress> VehicleAddress { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<AutoGlobalization> AutoGlobalizations { get; set; }
        public DbSet<AutoAirBag> AutoAirBags { get; set; }
        public DbSet<EngineCapacity> EngineCapacities { get; set; }
        public DbSet<VIROptionProperties> VIROptionProperties { get; set; }
        public DbSet<VIRFlagProperties> VIRFlagProperties { get; set; }
        public DbSet<VIR> VIR { get; set; }
        public DbSet<VIRPart> VIRPart { get; set; }
        public DbSet<VIRPartConditionSeverityLevels> VIRPartConditionSeverityLevels { get; set; }
        public DbSet<MediaPlayer> MediaPlayers { get; set; }
        public DbSet<Upholstery> Upholsteries { get; set; }
        public DbSet<RoofType> RoofTypes { get; set; }
        public DbSet<VehicleAudio> VehicleAudio { get; set; }
        public DbSet<VehicleWheel> VehicleWheel { get; set; }
        public DbSet<VehicleTopStyle> VehicleTopStyle { get; set; }
        public DbSet<VehicleInteriorType> VehicleInteriorType { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PostingDetail> PostingDetail { get; set; }
        public DbSet<MakerMapping> MakerMapping { get; set; }
        public DbSet<SubModelMapping> SubModelMapping { get; set; }
        public DbSet<AutoModelMapping> AutoModelMapping { get; set; }
        public DbSet<AutoTransmissionMapping> AutoTransmissionMapping { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<PostingSite> PostingSite { get; set; }
        public DbSet<PostingField> PostingField { get; set; }
        public DbSet<PostingStatus> PostingStatus { get; set; }
        public DbSet<PostingSiteUser> PostingSiteUser { get; set; }

        public System.Data.Entity.DbSet<AutoMax.Models.Entities.VehicleTrim> VehicleTrims { get; set; }
        public DbSet<PostingConfiguration> PostingConfiguration { get; set; }
        public DbSet<VehicleTitleMapping> VehicleTitleMapping { get; set; }
        public DbSet<Milage> Milages { get; set; }
    }
}
