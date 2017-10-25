namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
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
            
            AddColumn("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID", c => c.Int());
            CreateIndex("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID");
            AddForeignKey("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID", "dbo.PostingSiteUsers", "PostingSiteUserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID", "dbo.PostingSiteUsers");
            DropIndex("dbo.PostingDetails", new[] { "PostingSiteUser_PostingSiteUserID" });
            DropColumn("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID");
            DropTable("dbo.AutoInventoryStatusHistories");
        }
    }
}
