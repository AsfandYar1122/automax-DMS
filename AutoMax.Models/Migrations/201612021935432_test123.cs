namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
            AddColumn("dbo.VehicleWizards", "ExteriorRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "InteriorRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "MechanicsRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "FrameRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "TotalRatting", c => c.Double());
            AddColumn("dbo.VehicleWizards", "VIRCompletenessPercentage", c => c.Double());
            AddColumn("dbo.VehicleWizards", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.SubModels", "AutoModelID", c => c.Int());
            AddColumn("dbo.Users", "UserRoleID", c => c.Int());
            AddColumn("dbo.VehicleImages", "DisplayOrder", c => c.Int());
            AlterColumn("dbo.VIRs", "Severity", c => c.Double(nullable: false));
            CreateIndex("dbo.SubModels", "AutoModelID");
            CreateIndex("dbo.Users", "UserRoleID");
            AddForeignKey("dbo.SubModels", "AutoModelID", "dbo.AutoModels", "AutoModelID");
            AddForeignKey("dbo.Users", "UserRoleID", "dbo.UserRoles", "UserRoleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleID", "dbo.UserRoles");
            DropForeignKey("dbo.SubModels", "AutoModelID", "dbo.AutoModels");
            DropIndex("dbo.Users", new[] { "UserRoleID" });
            DropIndex("dbo.SubModels", new[] { "AutoModelID" });
            AlterColumn("dbo.VIRs", "Severity", c => c.String());
            DropColumn("dbo.VehicleImages", "DisplayOrder");
            DropColumn("dbo.Users", "UserRoleID");
            DropColumn("dbo.SubModels", "AutoModelID");
            DropColumn("dbo.VehicleWizards", "IsDeleted");
            DropColumn("dbo.VehicleWizards", "VIRCompletenessPercentage");
            DropColumn("dbo.VehicleWizards", "TotalRatting");
            DropColumn("dbo.VehicleWizards", "FrameRatting");
            DropColumn("dbo.VehicleWizards", "MechanicsRatting");
            DropColumn("dbo.VehicleWizards", "InteriorRatting");
            DropColumn("dbo.VehicleWizards", "ExteriorRatting");
            DropTable("dbo.UserRoles");
        }
    }
}
