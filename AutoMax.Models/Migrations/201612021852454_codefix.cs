namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codefix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleWizards", "ExteriorRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "InteriorRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "MechanicsRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "FrameRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "TotalRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "VIRCompletenessPercentage", c => c.Double());
            AlterColumn("dbo.VIRs", "Severity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VIRs", "Severity", c => c.String());
            DropColumn("dbo.VehicleWizards", "VIRCompletenessPercentage");
            DropColumn("dbo.VehicleWizards", "TotalRatting");
            DropColumn("dbo.VehicleWizards", "FrameRatting");
            DropColumn("dbo.VehicleWizards", "MechanicsRatting");
            DropColumn("dbo.VehicleWizards", "InteriorRatting");
            DropColumn("dbo.VehicleWizards", "ExteriorRatting");
        }
    }
}
