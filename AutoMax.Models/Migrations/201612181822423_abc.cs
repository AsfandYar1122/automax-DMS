namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleTrims",
                c => new
                    {
                        VehicleTrimID = c.Int(nullable: false, identity: true),
                        Trim = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleTrimID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            AddColumn("dbo.VehicleWizards", "VehicleTrimID", c => c.Int());
            AddColumn("dbo.VehicleWizards", "PurchasingCost", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.AutoModels", "MakerID", c => c.Int());
            CreateIndex("dbo.VehicleWizards", "VehicleTrimID");
            CreateIndex("dbo.AutoModels", "MakerID");
            AddForeignKey("dbo.AutoModels", "MakerID", "dbo.Makers", "MakerID");
            AddForeignKey("dbo.VehicleWizards", "VehicleTrimID", "dbo.VehicleTrims", "VehicleTrimID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "VehicleTrimID", "dbo.VehicleTrims");
            DropForeignKey("dbo.VehicleTrims", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoModels", "MakerID", "dbo.Makers");
            DropIndex("dbo.VehicleTrims", new[] { "LanguageID" });
            DropIndex("dbo.AutoModels", new[] { "MakerID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTrimID" });
            DropColumn("dbo.AutoModels", "MakerID");
            DropColumn("dbo.VehicleWizards", "PurchasingCost");
            DropColumn("dbo.VehicleWizards", "VehicleTrimID");
            DropTable("dbo.VehicleTrims");
        }
    }
}
