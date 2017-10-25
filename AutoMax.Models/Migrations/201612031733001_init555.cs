namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init555 : DbMigration
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
