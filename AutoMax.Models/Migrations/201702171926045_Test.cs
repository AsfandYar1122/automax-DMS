namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleImages", "ExternalURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleImages", "ExternalURL");
        }
    }
}
