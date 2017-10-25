namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleWizards", "ArabicWarantyText", c => c.String());
            AddColumn("dbo.VehicleWizards", "ArabicDescription", c => c.String());
            AddColumn("dbo.VehicleWizards", "ArabicFreeText", c => c.String());
            AddColumn("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID", c => c.Int());
            CreateIndex("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID");
            AddForeignKey("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID", "dbo.PostingSiteUsers", "PostingSiteUserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID", "dbo.PostingSiteUsers");
            DropIndex("dbo.PostingDetails", new[] { "PostingSiteUser_PostingSiteUserID" });
            DropColumn("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID");
            DropColumn("dbo.VehicleWizards", "ArabicFreeText");
            DropColumn("dbo.VehicleWizards", "ArabicDescription");
            DropColumn("dbo.VehicleWizards", "ArabicWarantyText");
        }
    }
}
