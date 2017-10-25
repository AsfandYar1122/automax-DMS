namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class w1 : DbMigration
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
            CreateIndex("dbo.VehicleWizards", "VehicleTrimID");
            AddForeignKey("dbo.VehicleWizards", "VehicleTrimID", "dbo.VehicleTrims", "VehicleTrimID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "VehicleTrimID", "dbo.VehicleTrims");
            DropForeignKey("dbo.VehicleTrims", "LanguageID", "dbo.Languages");
            DropIndex("dbo.VehicleTrims", new[] { "LanguageID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTrimID" });
            DropColumn("dbo.VehicleWizards", "VehicleTrimID");
            DropTable("dbo.VehicleTrims");
        }
    }
}
