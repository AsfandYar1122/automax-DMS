namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class w1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleWizards", "AutoAirBagID", "dbo.AutoAirBags");
            DropForeignKey("dbo.VehicleWizards", "AutoBodyStyleID", "dbo.AutoBodyStyles");
            DropForeignKey("dbo.VehicleWizards", "AutoDoorsID", "dbo.AutoDoors");
            DropForeignKey("dbo.VehicleWizards", "AutoEngineID", "dbo.AutoEngines");
            DropForeignKey("dbo.VehicleWizards", "AutoExteriorColorID", "dbo.AutoExteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoInteriorColorID", "dbo.AutoInteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoSteeringID", "dbo.AutoSteerings");
            DropForeignKey("dbo.VehicleWizards", "AutoTransmissionID", "dbo.AutoTransmissions");
            DropForeignKey("dbo.VehicleWizards", "DriveTypeID", "dbo.DriveTypes");
            DropForeignKey("dbo.VehicleWizards", "EngineCapacityID", "dbo.EngineCapacities");
            DropForeignKey("dbo.VehicleWizards", "FuelTypeID", "dbo.FuelTypes");
            DropForeignKey("dbo.VehicleWizards", "InventoryStatusID", "dbo.InventoryStatus");
            DropForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers");
            DropForeignKey("dbo.VehicleWizards", "RoofTypeID", "dbo.RoofTypes");
            DropForeignKey("dbo.VehicleWizards", "SubModelID", "dbo.SubModels");
            DropForeignKey("dbo.VehicleWizards", "UpholsteryID", "dbo.Upholsteries");
            DropForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios");
            DropForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes");
            DropForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles");
            DropForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels");
            DropIndex("dbo.VehicleWizards", new[] { "InventoryStatusID" });
            DropIndex("dbo.VehicleWizards", new[] { "SubModelID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoBodyStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoExteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoInteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoSteeringID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoDoorsID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoEngineID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoTransmissionID" });
            DropIndex("dbo.VehicleWizards", new[] { "FuelTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "DriveTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoAirBagID" });
            DropIndex("dbo.VehicleWizards", new[] { "EngineCapacityID" });
            DropIndex("dbo.VehicleWizards", new[] { "UpholsteryID" });
            DropIndex("dbo.VehicleWizards", new[] { "RoofTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleAudioID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleInteriorTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTopStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleWheelID" });
            DropIndex("dbo.VehicleWizards", new[] { "MediaPlayerID" });
            AlterColumn("dbo.VehicleWizards", "InventoryStatusID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "SubModelID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "AutoBodyStyleID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "AutoExteriorColorID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "AutoInteriorColorID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "AutoSteeringID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "AutoDoorsID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "AutoEngineID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "AutoTransmissionID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "FuelTypeID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "DriveTypeID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "VehiclePrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.VehicleWizards", "AutoAirBagID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "EngineCapacityID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "UpholsteryID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "RoofTypeID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "VehicleTypeID", c => c.Long());
            AlterColumn("dbo.VehicleWizards", "VehicleAudioID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "VehicleInteriorTypeID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "VehicleTopStyleID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "VehicleWheelID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "RecordStatus", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "MediaPlayerID", c => c.Long());
            CreateIndex("dbo.VehicleWizards", "InventoryStatusID");
            CreateIndex("dbo.VehicleWizards", "SubModelID");
            CreateIndex("dbo.VehicleWizards", "AutoBodyStyleID");
            CreateIndex("dbo.VehicleWizards", "AutoExteriorColorID");
            CreateIndex("dbo.VehicleWizards", "AutoInteriorColorID");
            CreateIndex("dbo.VehicleWizards", "AutoSteeringID");
            CreateIndex("dbo.VehicleWizards", "AutoDoorsID");
            CreateIndex("dbo.VehicleWizards", "AutoEngineID");
            CreateIndex("dbo.VehicleWizards", "AutoTransmissionID");
            CreateIndex("dbo.VehicleWizards", "FuelTypeID");
            CreateIndex("dbo.VehicleWizards", "DriveTypeID");
            CreateIndex("dbo.VehicleWizards", "AutoAirBagID");
            CreateIndex("dbo.VehicleWizards", "EngineCapacityID");
            CreateIndex("dbo.VehicleWizards", "UpholsteryID");
            CreateIndex("dbo.VehicleWizards", "RoofTypeID");
            CreateIndex("dbo.VehicleWizards", "VehicleTypeID");
            CreateIndex("dbo.VehicleWizards", "VehicleAudioID");
            CreateIndex("dbo.VehicleWizards", "VehicleInteriorTypeID");
            CreateIndex("dbo.VehicleWizards", "VehicleTopStyleID");
            CreateIndex("dbo.VehicleWizards", "VehicleWheelID");
            CreateIndex("dbo.VehicleWizards", "MediaPlayerID");
            AddForeignKey("dbo.VehicleWizards", "AutoAirBagID", "dbo.AutoAirBags", "AutoAirBagID");
            AddForeignKey("dbo.VehicleWizards", "AutoBodyStyleID", "dbo.AutoBodyStyles", "AutoBodyStyleID");
            AddForeignKey("dbo.VehicleWizards", "AutoDoorsID", "dbo.AutoDoors", "AutoDoorsID");
            AddForeignKey("dbo.VehicleWizards", "AutoEngineID", "dbo.AutoEngines", "AutoEngineID");
            AddForeignKey("dbo.VehicleWizards", "AutoExteriorColorID", "dbo.AutoExteriorColors", "AutoExteriorColorID");
            AddForeignKey("dbo.VehicleWizards", "AutoInteriorColorID", "dbo.AutoInteriorColors", "AutoInteriorColorID");
            AddForeignKey("dbo.VehicleWizards", "AutoSteeringID", "dbo.AutoSteerings", "AutoSteeringID");
            AddForeignKey("dbo.VehicleWizards", "AutoTransmissionID", "dbo.AutoTransmissions", "AutoTransmissionID");
            AddForeignKey("dbo.VehicleWizards", "DriveTypeID", "dbo.DriveTypes", "DriveTypeID");
            AddForeignKey("dbo.VehicleWizards", "EngineCapacityID", "dbo.EngineCapacities", "EngineCapacityID");
            AddForeignKey("dbo.VehicleWizards", "FuelTypeID", "dbo.FuelTypes", "FuelTypeID");
            AddForeignKey("dbo.VehicleWizards", "InventoryStatusID", "dbo.InventoryStatus", "InventoryStatusID");
            AddForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers", "MediaPlayerID");
            AddForeignKey("dbo.VehicleWizards", "RoofTypeID", "dbo.RoofTypes", "RoofTypeID");
            AddForeignKey("dbo.VehicleWizards", "SubModelID", "dbo.SubModels", "SubModelID");
            AddForeignKey("dbo.VehicleWizards", "UpholsteryID", "dbo.Upholsteries", "UpholsteryID");
            AddForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios", "AudioID");
            AddForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes", "InteriorTypeID");
            AddForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles", "TopStyleID");
            AddForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes", "VehicleTypeID");
            AddForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels", "WheelID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels");
            DropForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles");
            DropForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes");
            DropForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios");
            DropForeignKey("dbo.VehicleWizards", "UpholsteryID", "dbo.Upholsteries");
            DropForeignKey("dbo.VehicleWizards", "SubModelID", "dbo.SubModels");
            DropForeignKey("dbo.VehicleWizards", "RoofTypeID", "dbo.RoofTypes");
            DropForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers");
            DropForeignKey("dbo.VehicleWizards", "InventoryStatusID", "dbo.InventoryStatus");
            DropForeignKey("dbo.VehicleWizards", "FuelTypeID", "dbo.FuelTypes");
            DropForeignKey("dbo.VehicleWizards", "EngineCapacityID", "dbo.EngineCapacities");
            DropForeignKey("dbo.VehicleWizards", "DriveTypeID", "dbo.DriveTypes");
            DropForeignKey("dbo.VehicleWizards", "AutoTransmissionID", "dbo.AutoTransmissions");
            DropForeignKey("dbo.VehicleWizards", "AutoSteeringID", "dbo.AutoSteerings");
            DropForeignKey("dbo.VehicleWizards", "AutoInteriorColorID", "dbo.AutoInteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoExteriorColorID", "dbo.AutoExteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoEngineID", "dbo.AutoEngines");
            DropForeignKey("dbo.VehicleWizards", "AutoDoorsID", "dbo.AutoDoors");
            DropForeignKey("dbo.VehicleWizards", "AutoBodyStyleID", "dbo.AutoBodyStyles");
            DropForeignKey("dbo.VehicleWizards", "AutoAirBagID", "dbo.AutoAirBags");
            DropIndex("dbo.VehicleWizards", new[] { "MediaPlayerID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleWheelID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTopStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleInteriorTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleAudioID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "RoofTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "UpholsteryID" });
            DropIndex("dbo.VehicleWizards", new[] { "EngineCapacityID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoAirBagID" });
            DropIndex("dbo.VehicleWizards", new[] { "DriveTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "FuelTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoTransmissionID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoEngineID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoDoorsID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoSteeringID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoInteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoExteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoBodyStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "SubModelID" });
            DropIndex("dbo.VehicleWizards", new[] { "InventoryStatusID" });
            AlterColumn("dbo.VehicleWizards", "MediaPlayerID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "RecordStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VehicleWheelID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VehicleTopStyleID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VehicleInteriorTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VehicleAudioID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VehicleTypeID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "RoofTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "UpholsteryID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "EngineCapacityID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoAirBagID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VehiclePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.VehicleWizards", "DriveTypeID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "FuelTypeID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoTransmissionID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoEngineID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoDoorsID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoSteeringID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoInteriorColorID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoExteriorColorID", c => c.Long(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoBodyStyleID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "SubModelID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "InventoryStatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleWizards", "MediaPlayerID");
            CreateIndex("dbo.VehicleWizards", "VehicleWheelID");
            CreateIndex("dbo.VehicleWizards", "VehicleTopStyleID");
            CreateIndex("dbo.VehicleWizards", "VehicleInteriorTypeID");
            CreateIndex("dbo.VehicleWizards", "VehicleAudioID");
            CreateIndex("dbo.VehicleWizards", "VehicleTypeID");
            CreateIndex("dbo.VehicleWizards", "RoofTypeID");
            CreateIndex("dbo.VehicleWizards", "UpholsteryID");
            CreateIndex("dbo.VehicleWizards", "EngineCapacityID");
            CreateIndex("dbo.VehicleWizards", "AutoAirBagID");
            CreateIndex("dbo.VehicleWizards", "DriveTypeID");
            CreateIndex("dbo.VehicleWizards", "FuelTypeID");
            CreateIndex("dbo.VehicleWizards", "AutoTransmissionID");
            CreateIndex("dbo.VehicleWizards", "AutoEngineID");
            CreateIndex("dbo.VehicleWizards", "AutoDoorsID");
            CreateIndex("dbo.VehicleWizards", "AutoSteeringID");
            CreateIndex("dbo.VehicleWizards", "AutoInteriorColorID");
            CreateIndex("dbo.VehicleWizards", "AutoExteriorColorID");
            CreateIndex("dbo.VehicleWizards", "AutoBodyStyleID");
            CreateIndex("dbo.VehicleWizards", "SubModelID");
            CreateIndex("dbo.VehicleWizards", "InventoryStatusID");
            AddForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels", "WheelID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes", "VehicleTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles", "TopStyleID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes", "InteriorTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios", "AudioID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "UpholsteryID", "dbo.Upholsteries", "UpholsteryID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "SubModelID", "dbo.SubModels", "SubModelID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "RoofTypeID", "dbo.RoofTypes", "RoofTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers", "MediaPlayerID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "InventoryStatusID", "dbo.InventoryStatus", "InventoryStatusID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "FuelTypeID", "dbo.FuelTypes", "FuelTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "EngineCapacityID", "dbo.EngineCapacities", "EngineCapacityID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "DriveTypeID", "dbo.DriveTypes", "DriveTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoTransmissionID", "dbo.AutoTransmissions", "AutoTransmissionID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoSteeringID", "dbo.AutoSteerings", "AutoSteeringID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoInteriorColorID", "dbo.AutoInteriorColors", "AutoInteriorColorID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoExteriorColorID", "dbo.AutoExteriorColors", "AutoExteriorColorID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoEngineID", "dbo.AutoEngines", "AutoEngineID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoDoorsID", "dbo.AutoDoors", "AutoDoorsID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoBodyStyleID", "dbo.AutoBodyStyles", "AutoBodyStyleID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoAirBagID", "dbo.AutoAirBags", "AutoAirBagID", cascadeDelete: true);
        }
    }
}
