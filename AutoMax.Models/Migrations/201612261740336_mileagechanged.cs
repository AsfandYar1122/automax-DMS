namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mileagechanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleWizards", name: "MilageID", newName: "Milage_MilageID");
            RenameIndex(table: "dbo.VehicleWizards", name: "IX_MilageID", newName: "IX_Milage_MilageID");
            AddColumn("dbo.VehicleWizards", "MilageValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleWizards", "MilageValue");
            RenameIndex(table: "dbo.VehicleWizards", name: "IX_Milage_MilageID", newName: "IX_MilageID");
            RenameColumn(table: "dbo.VehicleWizards", name: "Milage_MilageID", newName: "MilageID");
        }
    }
}
