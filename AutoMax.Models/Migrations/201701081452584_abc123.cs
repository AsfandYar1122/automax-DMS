namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoInventoryStatusHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleId = c.Long(nullable: false),
                        FromInventoryStatusID = c.Int(nullable: false),
                        ToInventoryStatusID = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AutoInventoryStatusHistories");
        }
    }
}
