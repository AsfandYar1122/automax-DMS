namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc123 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleWizards", name: "VehicleTrimID", newName: "VehicleTrim_VehicleTrimID");
            RenameIndex(table: "dbo.VehicleWizards", name: "IX_VehicleTrimID", newName: "IX_VehicleTrim_VehicleTrimID");
            CreateTable(
                "dbo.AutoUsedStatus",
                c => new
                    {
                        AutoUsedStatusID = c.Long(nullable: false, identity: true),
                        UsedStatus = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoUsedStatusID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.Milages",
                c => new
                    {
                        MilageID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.MilageID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoModelMappings",
                c => new
                    {
                        AutoModelMappingID = c.Int(nullable: false, identity: true),
                        AutoModelID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoModelMappingID)
                .ForeignKey("dbo.AutoModels", t => t.AutoModelID, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.AutoModelID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.PostingConfigurations",
                c => new
                    {
                        PostingConfigurationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostingConfigurationID);
            
            CreateTable(
                "dbo.VehicleTitleMappings",
                c => new
                    {
                        VehicleTitleMappingID = c.Int(nullable: false, identity: true),
                        VehicleTitleID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleTitleMappingID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehclieTitles", t => t.VehicleTitleID, cascadeDelete: true)
                .Index(t => t.VehicleTitleID)
                .Index(t => t.LanguageID);
            
            AddColumn("dbo.VehicleWizards", "PurchasingCost", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.VehicleWizards", "Has360", c => c.Boolean());
            AddColumn("dbo.VehicleWizards", "MilageValue", c => c.String());
            AddColumn("dbo.VehicleWizards", "Branch", c => c.String());
            AddColumn("dbo.VehicleWizards", "Location", c => c.String());
            AddColumn("dbo.VehicleWizards", "AutoUsedStatusID", c => c.Long());
            AddColumn("dbo.VehicleWizards", "Milage_MilageID", c => c.Int());
            AddColumn("dbo.AutoModels", "MakerID", c => c.Int());
            AddColumn("dbo.Makers", "VehicleTypeID", c => c.Long());
            CreateIndex("dbo.VehicleWizards", "AutoUsedStatusID");
            CreateIndex("dbo.VehicleWizards", "Milage_MilageID");
            CreateIndex("dbo.AutoModels", "MakerID");
            CreateIndex("dbo.Makers", "VehicleTypeID");
            AddForeignKey("dbo.AutoModels", "MakerID", "dbo.Makers", "MakerID");
            AddForeignKey("dbo.Makers", "VehicleTypeID", "dbo.VehicleTypes", "VehicleTypeID");
            AddForeignKey("dbo.VehicleWizards", "AutoUsedStatusID", "dbo.AutoUsedStatus", "AutoUsedStatusID");
            AddForeignKey("dbo.VehicleWizards", "Milage_MilageID", "dbo.Milages", "MilageID");
            DropColumn("dbo.Makers", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makers", "Description", c => c.String());
            DropForeignKey("dbo.VehicleTitleMappings", "VehicleTitleID", "dbo.VehclieTitles");
            DropForeignKey("dbo.VehicleTitleMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoModelMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoModelMappings", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleWizards", "Milage_MilageID", "dbo.Milages");
            DropForeignKey("dbo.Milages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoUsedStatusID", "dbo.AutoUsedStatus");
            DropForeignKey("dbo.AutoUsedStatus", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Makers", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.AutoModels", "MakerID", "dbo.Makers");
            DropIndex("dbo.VehicleTitleMappings", new[] { "LanguageID" });
            DropIndex("dbo.VehicleTitleMappings", new[] { "VehicleTitleID" });
            DropIndex("dbo.AutoModelMappings", new[] { "LanguageID" });
            DropIndex("dbo.AutoModelMappings", new[] { "AutoModelID" });
            DropIndex("dbo.Milages", new[] { "LanguageID" });
            DropIndex("dbo.AutoUsedStatus", new[] { "LanguageID" });
            DropIndex("dbo.Makers", new[] { "VehicleTypeID" });
            DropIndex("dbo.AutoModels", new[] { "MakerID" });
            DropIndex("dbo.VehicleWizards", new[] { "Milage_MilageID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoUsedStatusID" });
            DropColumn("dbo.Makers", "VehicleTypeID");
            DropColumn("dbo.AutoModels", "MakerID");
            DropColumn("dbo.VehicleWizards", "Milage_MilageID");
            DropColumn("dbo.VehicleWizards", "AutoUsedStatusID");
            DropColumn("dbo.VehicleWizards", "Location");
            DropColumn("dbo.VehicleWizards", "Branch");
            DropColumn("dbo.VehicleWizards", "MilageValue");
            DropColumn("dbo.VehicleWizards", "Has360");
            DropColumn("dbo.VehicleWizards", "PurchasingCost");
            DropTable("dbo.VehicleTitleMappings");
            DropTable("dbo.PostingConfigurations");
            DropTable("dbo.AutoModelMappings");
            DropTable("dbo.Milages");
            DropTable("dbo.AutoUsedStatus");
            RenameIndex(table: "dbo.VehicleWizards", name: "IX_VehicleTrim_VehicleTrimID", newName: "IX_VehicleTrimID");
            RenameColumn(table: "dbo.VehicleWizards", name: "VehicleTrim_VehicleTrimID", newName: "VehicleTrimID");
        }
    }
}
