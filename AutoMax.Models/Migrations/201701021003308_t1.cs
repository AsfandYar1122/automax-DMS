namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleWizards", "ExteriorRatting", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.VehicleWizards", "InteriorRatting", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.VehicleWizards", "MechanicsRatting", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.VehicleWizards", "FrameRatting", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.VehicleWizards", "TotalRatting", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.VehicleWizards", "VIRCompletenessPercentage", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.VIRs", "Ratting", c => c.Decimal(nullable: false, precision: 16, scale: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VIRs", "Ratting", c => c.Double(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VIRCompletenessPercentage", c => c.Double());
            AlterColumn("dbo.VehicleWizards", "TotalRatting", c => c.Double());
            AlterColumn("dbo.VehicleWizards", "FrameRatting", c => c.Double());
            AlterColumn("dbo.VehicleWizards", "MechanicsRatting", c => c.Double());
            AlterColumn("dbo.VehicleWizards", "InteriorRatting", c => c.Double());
            AlterColumn("dbo.VehicleWizards", "ExteriorRatting", c => c.Double());
        }
    }
}
