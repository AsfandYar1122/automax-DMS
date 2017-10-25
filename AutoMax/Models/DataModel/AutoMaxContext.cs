using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AutoMax.Models.Entities;

namespace AutoMax.Models.DataModel
{
    public class AutoMaxContext : IdentityDbContext<ApplicationUser>
    {   
        public AutoMaxContext() : base("name=AMConnectionStr")
        {

        }

        public static AutoMaxContext Create()
        {
            return new AutoMaxContext();
        }

       
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
        public DbSet<MotorizedType> MotorizedTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VehclieTitle> VehclieTitles { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<VehiclePrice> VehiclePrices { get; set; }
        public DbSet<VehicleTemplate> VehicleTemplates { get; set; }
        public DbSet<SubModel> SubModel { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleWizard> VehicleWizards { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<AutoGlobalization> AutoGlobalizations { get; set; }
        public DbSet<AutoAirBag> AutoAirBags { get; set; }
        public DbSet<EngineCapacity> EngineCapacities { get; set; }
        public DbSet<MediaPlayer> MediaPlayers { get; set; }
        public DbSet<Upholstery> Upholsteries { get; set; }
        public DbSet<RoofType> RoofTypes { get; set; }
    }
}