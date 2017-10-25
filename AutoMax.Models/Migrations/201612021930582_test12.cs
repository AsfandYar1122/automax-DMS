namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleWizards", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleWizards", "IsDeleted");
        }
    }
}
