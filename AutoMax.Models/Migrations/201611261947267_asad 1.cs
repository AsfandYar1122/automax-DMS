namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asad1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VehiclePartImages",
            //    c => new
            //        {
            //            VehiclePartImageID = c.Long(nullable: false, identity: true),
            //            ImagePath = c.String(),
            //            CreatedBy = c.Long(nullable: false),
            //            UpdatedBy = c.Long(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //            UpdatedDate = c.DateTime(nullable: false),
            //            VehicleID = c.Long(nullable: false),
            //            VIRID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.VehiclePartImageID)
            //    .ForeignKey("dbo.VehicleWizards", t => t.VehicleID, cascadeDelete: true)
            //    .ForeignKey("dbo.VIRs", t => t.VIRID, cascadeDelete: true)
            //    .Index(t => t.VehicleID)
            //    .Index(t => t.VIRID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehiclePartImages", "VIRID", "dbo.VIRs");
            DropForeignKey("dbo.VehiclePartImages", "VehicleID", "dbo.VehicleWizards");
            DropIndex("dbo.VehiclePartImages", new[] { "VIRID" });
            DropIndex("dbo.VehiclePartImages", new[] { "VehicleID" });
            DropTable("dbo.VehiclePartImages");
        }
    }
}
