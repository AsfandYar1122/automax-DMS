namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flag : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VIRStaticDatas", newName: "VIROptionProperties");
            CreateTable(
                "dbo.VehicleAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhysicalAddress = c.String(),
                        GoogleAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VIRFlagProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VehicleWizards", "VehicleOptions", c => c.String());
            AddColumn("dbo.VehicleWizards", "VehicleMoreOptions", c => c.String());
            AddColumn("dbo.VehicleWizards", "VehicleFlags", c => c.String());
            AddColumn("dbo.VehicleWizards", "VehiclemoreFlags", c => c.String());
            AddColumn("dbo.VehicleWizards", "VehicleAddressId", c => c.Int());
            CreateIndex("dbo.VehicleWizards", "VehicleAddressId");
            AddForeignKey("dbo.VehicleWizards", "VehicleAddressId", "dbo.VehicleAddresses", "Id");
            DropColumn("dbo.VIROptionProperties", "Ratting");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VIROptionProperties", "Ratting", c => c.Double(nullable: false));
            DropForeignKey("dbo.VehicleWizards", "VehicleAddressId", "dbo.VehicleAddresses");
            DropIndex("dbo.VehicleWizards", new[] { "VehicleAddressId" });
            DropColumn("dbo.VehicleWizards", "VehicleAddressId");
            DropColumn("dbo.VehicleWizards", "VehiclemoreFlags");
            DropColumn("dbo.VehicleWizards", "VehicleFlags");
            DropColumn("dbo.VehicleWizards", "VehicleMoreOptions");
            DropColumn("dbo.VehicleWizards", "VehicleOptions");
            DropTable("dbo.VIRFlagProperties");
            DropTable("dbo.VehicleAddresses");
            RenameTable(name: "dbo.VIROptionProperties", newName: "VIRStaticDatas");
        }
    }
}
