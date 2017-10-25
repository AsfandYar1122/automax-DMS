namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _567 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.VehicleWizards", "Branch", c => c.String());
            AddColumn("dbo.VehicleWizards", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleTitleMappings", "VehicleTitleID", "dbo.VehclieTitles");
            DropForeignKey("dbo.VehicleTitleMappings", "LanguageID", "dbo.Languages");
            DropIndex("dbo.VehicleTitleMappings", new[] { "LanguageID" });
            DropIndex("dbo.VehicleTitleMappings", new[] { "VehicleTitleID" });
            DropColumn("dbo.VehicleWizards", "Location");
            DropColumn("dbo.VehicleWizards", "Branch");
            DropTable("dbo.VehicleTitleMappings");
            DropTable("dbo.PostingConfigurations");
        }
    }
}
