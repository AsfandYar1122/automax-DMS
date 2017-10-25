namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
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
            
            AddColumn("dbo.VehicleWizards", "MilageID", c => c.Int());
            AddColumn("dbo.VehicleWizards", "AutoUsedStatusID", c => c.Long());
            CreateIndex("dbo.VehicleWizards", "MilageID");
            CreateIndex("dbo.VehicleWizards", "AutoUsedStatusID");
            AddForeignKey("dbo.VehicleWizards", "AutoUsedStatusID", "dbo.AutoUsedStatus", "AutoUsedStatusID");
            AddForeignKey("dbo.VehicleWizards", "MilageID", "dbo.Milages", "MilageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "MilageID", "dbo.Milages");
            DropForeignKey("dbo.Milages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoUsedStatusID", "dbo.AutoUsedStatus");
            DropForeignKey("dbo.AutoUsedStatus", "LanguageID", "dbo.Languages");
            DropIndex("dbo.Milages", new[] { "LanguageID" });
            DropIndex("dbo.AutoUsedStatus", new[] { "LanguageID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoUsedStatusID" });
            DropIndex("dbo.VehicleWizards", new[] { "MilageID" });
            DropColumn("dbo.VehicleWizards", "AutoUsedStatusID");
            DropColumn("dbo.VehicleWizards", "MilageID");
            DropTable("dbo.Milages");
            DropTable("dbo.AutoUsedStatus");
            RenameIndex(table: "dbo.VehicleWizards", name: "IX_VehicleTrim_VehicleTrimID", newName: "IX_VehicleTrimID");
            RenameColumn(table: "dbo.VehicleWizards", name: "VehicleTrim_VehicleTrimID", newName: "VehicleTrimID");
        }
    }
}
