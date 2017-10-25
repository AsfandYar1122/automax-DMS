namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test45 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleWizards", "AutoConditionID", "dbo.AutoConditions");
            DropForeignKey("dbo.VehicleWizards", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleWizards", "MakerID", "dbo.Makers");
            DropForeignKey("dbo.VehicleWizards", "VehicleTitleID", "dbo.VehclieTitles");
            DropForeignKey("dbo.VehicleWizards", "YearID", "dbo.Years");
            DropIndex("dbo.VehicleWizards", new[] { "AutoConditionID" });
            DropIndex("dbo.VehicleWizards", new[] { "YearID" });
            DropIndex("dbo.VehicleWizards", new[] { "MakerID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoModelID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTitleID" });
            CreateTable(
                "dbo.PostingSites",
                c => new
                    {
                        PostingSiteID = c.Int(nullable: false, identity: true),
                        PostingSiteName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostingSiteID);
            
            CreateTable(
                "dbo.PostingFields",
                c => new
                    {
                        PostingFieldID = c.Int(nullable: false, identity: true),
                        PostingSiteID = c.Int(nullable: false),
                        FieldName = c.String(),
                        LinkedFieldName = c.String(),
                        DisplayName = c.String(),
                        IncludeInPosting = c.Boolean(nullable: false),
                        IncludeOrder = c.Int(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostingFieldID)
                .ForeignKey("dbo.PostingSites", t => t.PostingSiteID, cascadeDelete: true)
                .Index(t => t.PostingSiteID);
            
            CreateTable(
                "dbo.PostingStatus",
                c => new
                    {
                        PostingStatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostingStatusID);
            
            CreateTable(
                "dbo.PostingSiteUsers",
                c => new
                    {
                        PostingSiteUserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        UserPassword = c.String(),
                        Phonenumber = c.String(),
                        PostingSiteID = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostingSiteUserID)
                .ForeignKey("dbo.PostingSites", t => t.PostingSiteID, cascadeDelete: true)
                .Index(t => t.PostingSiteID);
            
            AddColumn("dbo.VehicleWizards", "IsFeatured", c => c.Boolean());
            AddColumn("dbo.VehicleImages", "IsFeatured", c => c.Int());
            AddColumn("dbo.PostingDetails", "PublishPrice", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostingDetails", "Negotiable", c => c.Boolean(nullable: false));
            AddColumn("dbo.PostingDetails", "PostingStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.PostingDetails", "PostingSiteID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoConditionID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "YearID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "MakerID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "AutoModelID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "VehicleTitleID", c => c.Int());
            AlterColumn("dbo.VehicleWizards", "IsDeleted", c => c.Boolean());
            CreateIndex("dbo.VehicleWizards", "AutoConditionID");
            CreateIndex("dbo.VehicleWizards", "YearID");
            CreateIndex("dbo.VehicleWizards", "MakerID");
            CreateIndex("dbo.VehicleWizards", "AutoModelID");
            CreateIndex("dbo.VehicleWizards", "VehicleTitleID");
            CreateIndex("dbo.PostingDetails", "PostingStatusID");
            CreateIndex("dbo.PostingDetails", "PostingSiteID");
            AddForeignKey("dbo.PostingDetails", "PostingSiteID", "dbo.PostingSites", "PostingSiteID", cascadeDelete: true);
            AddForeignKey("dbo.PostingDetails", "PostingStatusID", "dbo.PostingStatus", "PostingStatusID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoConditionID", "dbo.AutoConditions", "AutoConditionID");
            AddForeignKey("dbo.VehicleWizards", "AutoModelID", "dbo.AutoModels", "AutoModelID");
            AddForeignKey("dbo.VehicleWizards", "MakerID", "dbo.Makers", "MakerID");
            AddForeignKey("dbo.VehicleWizards", "VehicleTitleID", "dbo.VehclieTitles", "VehicleTitleID");
            AddForeignKey("dbo.VehicleWizards", "YearID", "dbo.Years", "YearID");
            DropColumn("dbo.PostingDetails", "PostingStatus");
            DropColumn("dbo.PostingDetails", "PostingSite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostingDetails", "PostingSite", c => c.Int(nullable: false));
            AddColumn("dbo.PostingDetails", "PostingStatus", c => c.Int(nullable: false));
            DropForeignKey("dbo.VehicleWizards", "YearID", "dbo.Years");
            DropForeignKey("dbo.VehicleWizards", "VehicleTitleID", "dbo.VehclieTitles");
            DropForeignKey("dbo.VehicleWizards", "MakerID", "dbo.Makers");
            DropForeignKey("dbo.VehicleWizards", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleWizards", "AutoConditionID", "dbo.AutoConditions");
            DropForeignKey("dbo.PostingSiteUsers", "PostingSiteID", "dbo.PostingSites");
            DropForeignKey("dbo.PostingDetails", "PostingStatusID", "dbo.PostingStatus");
            DropForeignKey("dbo.PostingFields", "PostingSiteID", "dbo.PostingSites");
            DropForeignKey("dbo.PostingDetails", "PostingSiteID", "dbo.PostingSites");
            DropIndex("dbo.PostingSiteUsers", new[] { "PostingSiteID" });
            DropIndex("dbo.PostingFields", new[] { "PostingSiteID" });
            DropIndex("dbo.PostingDetails", new[] { "PostingSiteID" });
            DropIndex("dbo.PostingDetails", new[] { "PostingStatusID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTitleID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoModelID" });
            DropIndex("dbo.VehicleWizards", new[] { "MakerID" });
            DropIndex("dbo.VehicleWizards", new[] { "YearID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoConditionID" });
            AlterColumn("dbo.VehicleWizards", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VehicleWizards", "VehicleTitleID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoModelID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "MakerID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "YearID", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "AutoConditionID", c => c.Int(nullable: false));
            DropColumn("dbo.PostingDetails", "PostingSiteID");
            DropColumn("dbo.PostingDetails", "PostingStatusID");
            DropColumn("dbo.PostingDetails", "Negotiable");
            DropColumn("dbo.PostingDetails", "PublishPrice");
            DropColumn("dbo.VehicleImages", "IsFeatured");
            DropColumn("dbo.VehicleWizards", "IsFeatured");
            DropTable("dbo.PostingSiteUsers");
            DropTable("dbo.PostingStatus");
            DropTable("dbo.PostingFields");
            DropTable("dbo.PostingSites");
            CreateIndex("dbo.VehicleWizards", "VehicleTitleID");
            CreateIndex("dbo.VehicleWizards", "AutoModelID");
            CreateIndex("dbo.VehicleWizards", "MakerID");
            CreateIndex("dbo.VehicleWizards", "YearID");
            CreateIndex("dbo.VehicleWizards", "AutoConditionID");
            AddForeignKey("dbo.VehicleWizards", "YearID", "dbo.Years", "YearID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleTitleID", "dbo.VehclieTitles", "VehicleTitleID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "MakerID", "dbo.Makers", "MakerID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoModelID", "dbo.AutoModels", "AutoModelID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "AutoConditionID", "dbo.AutoConditions", "AutoConditionID", cascadeDelete: true);
        }
    }
}
