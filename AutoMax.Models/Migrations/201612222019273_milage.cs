namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class milage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Milages",
                c => new
                    {
                        MilageID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.MilageID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            AddColumn("dbo.VehicleWizards", "MilageID", c => c.Int());
            CreateIndex("dbo.VehicleWizards", "MilageID");
            AddForeignKey("dbo.VehicleWizards", "MilageID", "dbo.Milages", "MilageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "MilageID", "dbo.Milages");
            DropForeignKey("dbo.Milages", "LanguageID", "dbo.Languages");
            DropIndex("dbo.Milages", new[] { "LanguageID" });
            DropIndex("dbo.VehicleWizards", new[] { "MilageID" });
            DropColumn("dbo.VehicleWizards", "MilageID");
            DropTable("dbo.Milages");
        }
    }
}
