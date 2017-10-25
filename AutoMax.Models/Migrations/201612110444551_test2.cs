namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoTransmissionMappings",
                c => new
                    {
                        AutoTransmissionMappingID = c.Int(nullable: false, identity: true),
                        AutoTransmissionID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                        AutoTransmission_AutoTransmissionID = c.Long(),
                    })
                .PrimaryKey(t => t.AutoTransmissionMappingID)
                .ForeignKey("dbo.AutoTransmissions", t => t.AutoTransmission_AutoTransmissionID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID)
                .Index(t => t.AutoTransmission_AutoTransmissionID);
            
            CreateTable(
                "dbo.MakerMappings",
                c => new
                    {
                        MakerMappingID = c.Int(nullable: false, identity: true),
                        MakerId = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.MakerMappingID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.Makers", t => t.MakerId, cascadeDelete: true)
                .Index(t => t.MakerId)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.MotorizedTypes",
                c => new
                    {
                        MotorizedTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.MotorizedTypeID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.PostingDetails",
                c => new
                    {
                        PostingDetailID = c.Int(nullable: false, identity: true),
                        PostingTitle = c.String(),
                        PostingDescription = c.String(),
                        PostingStatus = c.Int(nullable: false),
                        PostingSite = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                        VehicleWizardId = c.Long(nullable: false),
                        VehicleWizard_VehicleID = c.Long(),
                    })
                .PrimaryKey(t => t.PostingDetailID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleWizard_VehicleID)
                .Index(t => t.LanguageID)
                .Index(t => t.VehicleWizard_VehicleID);
            
            CreateTable(
                "dbo.SubModelMappings",
                c => new
                    {
                        SubModelMappingID = c.Int(nullable: false, identity: true),
                        SubModelID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.SubModelMappingID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.SubModels", t => t.SubModelID, cascadeDelete: true)
                .Index(t => t.SubModelID)
                .Index(t => t.LanguageID);
            
            AddColumn("dbo.AutoAirBags", "LanguageID", c => c.Int());
            AddColumn("dbo.VehicleWizards", "LanguageID", c => c.Int());
            AddColumn("dbo.VehicleWizards", "MotorizedType_MotorizedTypeID", c => c.Int());
            AddColumn("dbo.AutoBodyStyles", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoConditions", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoDoors", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoEngines", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoExteriorColors", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoInteriorColors", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoModels", "LanguageID", c => c.Int());
            AddColumn("dbo.SubModels", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoSteerings", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoTransmissions", "LanguageID", c => c.Int());
            AddColumn("dbo.DriveTypes", "LanguageID", c => c.Int());
            AddColumn("dbo.EngineCapacities", "LanguageID", c => c.Int());
            AddColumn("dbo.FuelTypes", "LanguageID", c => c.Int());
            AddColumn("dbo.InventoryStatus", "LanguageID", c => c.Int());
            AddColumn("dbo.Makers", "LanguageID", c => c.Int());
            AddColumn("dbo.MediaPlayers", "LanguageID", c => c.Int());
            AddColumn("dbo.RoofTypes", "LanguageID", c => c.Int());
            AddColumn("dbo.Upholsteries", "LanguageID", c => c.Int());
            AddColumn("dbo.Users", "LanguageID", c => c.Int());
            AddColumn("dbo.UserRoles", "LanguageID", c => c.Int());
            AddColumn("dbo.VehclieTitles", "LanguageID", c => c.Int());
            AddColumn("dbo.VehicleImages", "LanguageID", c => c.Int());
            AddColumn("dbo.VehicleTypes", "LanguageID", c => c.Int());
            AddColumn("dbo.Years", "LanguageID", c => c.Int());
            AddColumn("dbo.AutoGlobalizations", "LanguageID", c => c.Int());
            AddColumn("dbo.VehiclePartImages", "LanguageID", c => c.Int());
            AddColumn("dbo.VehiclePrices", "LanguageID", c => c.Int());
            AddColumn("dbo.VehicleTemplates", "LanguageID", c => c.Int());
            CreateIndex("dbo.AutoAirBags", "LanguageID");
            CreateIndex("dbo.AutoBodyStyles", "LanguageID");
            CreateIndex("dbo.VehicleWizards", "LanguageID");
            CreateIndex("dbo.VehicleWizards", "MotorizedType_MotorizedTypeID");
            CreateIndex("dbo.AutoConditions", "LanguageID");
            CreateIndex("dbo.AutoDoors", "LanguageID");
            CreateIndex("dbo.AutoEngines", "LanguageID");
            CreateIndex("dbo.AutoExteriorColors", "LanguageID");
            CreateIndex("dbo.AutoInteriorColors", "LanguageID");
            CreateIndex("dbo.AutoModels", "LanguageID");
            CreateIndex("dbo.SubModels", "LanguageID");
            CreateIndex("dbo.AutoSteerings", "LanguageID");
            CreateIndex("dbo.AutoTransmissions", "LanguageID");
            CreateIndex("dbo.DriveTypes", "LanguageID");
            CreateIndex("dbo.EngineCapacities", "LanguageID");
            CreateIndex("dbo.FuelTypes", "LanguageID");
            CreateIndex("dbo.InventoryStatus", "LanguageID");
            CreateIndex("dbo.Makers", "LanguageID");
            CreateIndex("dbo.MediaPlayers", "LanguageID");
            CreateIndex("dbo.RoofTypes", "LanguageID");
            CreateIndex("dbo.Upholsteries", "LanguageID");
            CreateIndex("dbo.Users", "LanguageID");
            CreateIndex("dbo.UserRoles", "LanguageID");
            CreateIndex("dbo.VehclieTitles", "LanguageID");
            CreateIndex("dbo.VehicleImages", "LanguageID");
            CreateIndex("dbo.VehicleTypes", "LanguageID");
            CreateIndex("dbo.Years", "LanguageID");
            CreateIndex("dbo.AutoGlobalizations", "LanguageID");
            CreateIndex("dbo.VehiclePrices", "LanguageID");
            CreateIndex("dbo.VehicleTemplates", "LanguageID");
            CreateIndex("dbo.VehiclePartImages", "LanguageID");
            AddForeignKey("dbo.AutoAirBags", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoBodyStyles", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoConditions", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoDoors", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoEngines", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoExteriorColors", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoInteriorColors", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoModels", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.SubModels", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoSteerings", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoTransmissions", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.DriveTypes", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.EngineCapacities", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.FuelTypes", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.InventoryStatus", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.VehicleWizards", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.Makers", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.MediaPlayers", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.RoofTypes", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.Upholsteries", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.Users", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.UserRoles", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.VehclieTitles", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.VehicleImages", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.VehicleTypes", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.Years", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.AutoGlobalizations", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.VehicleWizards", "MotorizedType_MotorizedTypeID", "dbo.MotorizedTypes", "MotorizedTypeID");
            AddForeignKey("dbo.VehiclePrices", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.VehicleTemplates", "LanguageID", "dbo.Languages", "LanguageID");
            AddForeignKey("dbo.VehiclePartImages", "LanguageID", "dbo.Languages", "LanguageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehiclePartImages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleTemplates", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehiclePrices", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.SubModelMappings", "SubModelID", "dbo.SubModels");
            DropForeignKey("dbo.SubModelMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.PostingDetails", "VehicleWizard_VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.PostingDetails", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "MotorizedType_MotorizedTypeID", "dbo.MotorizedTypes");
            DropForeignKey("dbo.MotorizedTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.MakerMappings", "MakerId", "dbo.Makers");
            DropForeignKey("dbo.MakerMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoTransmissionMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoTransmissionMappings", "AutoTransmission_AutoTransmissionID", "dbo.AutoTransmissions");
            DropForeignKey("dbo.AutoGlobalizations", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Years", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleImages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehclieTitles", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.UserRoles", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Users", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Upholsteries", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.RoofTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.MediaPlayers", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Makers", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.InventoryStatus", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.FuelTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.EngineCapacities", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.DriveTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoTransmissions", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoSteerings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.SubModels", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoModels", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoInteriorColors", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoExteriorColors", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoEngines", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoDoors", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoConditions", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoBodyStyles", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoAirBags", "LanguageID", "dbo.Languages");
            DropIndex("dbo.VehiclePartImages", new[] { "LanguageID" });
            DropIndex("dbo.VehicleTemplates", new[] { "LanguageID" });
            DropIndex("dbo.VehiclePrices", new[] { "LanguageID" });
            DropIndex("dbo.SubModelMappings", new[] { "LanguageID" });
            DropIndex("dbo.SubModelMappings", new[] { "SubModelID" });
            DropIndex("dbo.PostingDetails", new[] { "VehicleWizard_VehicleID" });
            DropIndex("dbo.PostingDetails", new[] { "LanguageID" });
            DropIndex("dbo.MotorizedTypes", new[] { "LanguageID" });
            DropIndex("dbo.MakerMappings", new[] { "LanguageID" });
            DropIndex("dbo.MakerMappings", new[] { "MakerId" });
            DropIndex("dbo.AutoTransmissionMappings", new[] { "AutoTransmission_AutoTransmissionID" });
            DropIndex("dbo.AutoTransmissionMappings", new[] { "LanguageID" });
            DropIndex("dbo.AutoGlobalizations", new[] { "LanguageID" });
            DropIndex("dbo.Years", new[] { "LanguageID" });
            DropIndex("dbo.VehicleTypes", new[] { "LanguageID" });
            DropIndex("dbo.VehicleImages", new[] { "LanguageID" });
            DropIndex("dbo.VehclieTitles", new[] { "LanguageID" });
            DropIndex("dbo.UserRoles", new[] { "LanguageID" });
            DropIndex("dbo.Users", new[] { "LanguageID" });
            DropIndex("dbo.Upholsteries", new[] { "LanguageID" });
            DropIndex("dbo.RoofTypes", new[] { "LanguageID" });
            DropIndex("dbo.MediaPlayers", new[] { "LanguageID" });
            DropIndex("dbo.Makers", new[] { "LanguageID" });
            DropIndex("dbo.InventoryStatus", new[] { "LanguageID" });
            DropIndex("dbo.FuelTypes", new[] { "LanguageID" });
            DropIndex("dbo.EngineCapacities", new[] { "LanguageID" });
            DropIndex("dbo.DriveTypes", new[] { "LanguageID" });
            DropIndex("dbo.AutoTransmissions", new[] { "LanguageID" });
            DropIndex("dbo.AutoSteerings", new[] { "LanguageID" });
            DropIndex("dbo.SubModels", new[] { "LanguageID" });
            DropIndex("dbo.AutoModels", new[] { "LanguageID" });
            DropIndex("dbo.AutoInteriorColors", new[] { "LanguageID" });
            DropIndex("dbo.AutoExteriorColors", new[] { "LanguageID" });
            DropIndex("dbo.AutoEngines", new[] { "LanguageID" });
            DropIndex("dbo.AutoDoors", new[] { "LanguageID" });
            DropIndex("dbo.AutoConditions", new[] { "LanguageID" });
            DropIndex("dbo.VehicleWizards", new[] { "MotorizedType_MotorizedTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "LanguageID" });
            DropIndex("dbo.AutoBodyStyles", new[] { "LanguageID" });
            DropIndex("dbo.AutoAirBags", new[] { "LanguageID" });
            DropColumn("dbo.VehicleTemplates", "LanguageID");
            DropColumn("dbo.VehiclePrices", "LanguageID");
            DropColumn("dbo.VehiclePartImages", "LanguageID");
            DropColumn("dbo.AutoGlobalizations", "LanguageID");
            DropColumn("dbo.Years", "LanguageID");
            DropColumn("dbo.VehicleTypes", "LanguageID");
            DropColumn("dbo.VehicleImages", "LanguageID");
            DropColumn("dbo.VehclieTitles", "LanguageID");
            DropColumn("dbo.UserRoles", "LanguageID");
            DropColumn("dbo.Users", "LanguageID");
            DropColumn("dbo.Upholsteries", "LanguageID");
            DropColumn("dbo.RoofTypes", "LanguageID");
            DropColumn("dbo.MediaPlayers", "LanguageID");
            DropColumn("dbo.Makers", "LanguageID");
            DropColumn("dbo.InventoryStatus", "LanguageID");
            DropColumn("dbo.FuelTypes", "LanguageID");
            DropColumn("dbo.EngineCapacities", "LanguageID");
            DropColumn("dbo.DriveTypes", "LanguageID");
            DropColumn("dbo.AutoTransmissions", "LanguageID");
            DropColumn("dbo.AutoSteerings", "LanguageID");
            DropColumn("dbo.SubModels", "LanguageID");
            DropColumn("dbo.AutoModels", "LanguageID");
            DropColumn("dbo.AutoInteriorColors", "LanguageID");
            DropColumn("dbo.AutoExteriorColors", "LanguageID");
            DropColumn("dbo.AutoEngines", "LanguageID");
            DropColumn("dbo.AutoDoors", "LanguageID");
            DropColumn("dbo.AutoConditions", "LanguageID");
            DropColumn("dbo.AutoBodyStyles", "LanguageID");
            DropColumn("dbo.VehicleWizards", "MotorizedType_MotorizedTypeID");
            DropColumn("dbo.VehicleWizards", "LanguageID");
            DropColumn("dbo.AutoAirBags", "LanguageID");
            DropTable("dbo.SubModelMappings");
            DropTable("dbo.PostingDetails");
            DropTable("dbo.MotorizedTypes");
            DropTable("dbo.MakerMappings");
            DropTable("dbo.AutoTransmissionMappings");
            DropTable("dbo.Languages");
        }
    }
}
