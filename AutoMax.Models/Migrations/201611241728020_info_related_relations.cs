namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class info_related_relations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleAudios",
                c => new
                    {
                        AudioID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AudioID);
            
            CreateTable(
                "dbo.VehicleInteriorTypes",
                c => new
                    {
                        InteriorTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InteriorTypeID);
            
            CreateTable(
                "dbo.VehicleTopStyles",
                c => new
                    {
                        TopStyleID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TopStyleID);
            
            CreateTable(
                "dbo.VehicleWheels",
                c => new
                    {
                        WheelID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WheelID);
            
            AddColumn("dbo.VehicleWizards", "VehicleAudioID", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleWizards", "VehicleInteriorTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleWizards", "VehicleTopStyleID", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleWizards", "VehicleWheelID", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleWizards", "VehicleAudioID");
            CreateIndex("dbo.VehicleWizards", "VehicleInteriorTypeID");
            CreateIndex("dbo.VehicleWizards", "VehicleTopStyleID");
            CreateIndex("dbo.VehicleWizards", "VehicleWheelID");

            Sql("INSERT INTO [dbo].[VehicleWheels] ([Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate]) VALUES (N'abc',  '1', '1', '2016-11-24 22:31:59', '2016-11-24 22:32:01')");
            Sql("INSERT INTO [dbo].[VehicleInteriorTypes] ([Type], [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate]) VALUES (N'abc',  '1', '1', '2016-11-24 22:31:59', '2016-11-24 22:32:01')");
            Sql("INSERT INTO [dbo].[VehicleTopStyles] ([Type],  [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate]) VALUES (N'abc',  '1', '1', '2016-11-24 22:31:59', '2016-11-24 22:32:01')");
            Sql("INSERT INTO [dbo].[VehicleAudios] ([Type],  [CreatedBy], [UpdatedBy], [CreatedDate], [UpdatedDate]) VALUES (N'abc',  '1', '1', '2016-11-24 22:31:59', '2016-11-24 22:32:01')");

            Sql("UPDATE dbo.VehicleWizards SET VehicleWheelID = 1");
            Sql("UPDATE dbo.VehicleWizards SET VehicleInteriorTypeID = 1");
            Sql("UPDATE dbo.VehicleWizards SET VehicleTopStyleID = 1");
            Sql("UPDATE dbo.VehicleWizards SET VehicleAudioID = 1");


            AddForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios", "AudioID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes", "InteriorTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles", "TopStyleID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels", "WheelID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels");
            DropForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles");
            DropForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes");
            DropForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios");
            DropIndex("dbo.VehicleWizards", new[] { "VehicleWheelID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTopStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleInteriorTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleAudioID" });
            DropColumn("dbo.VehicleWizards", "VehicleWheelID");
            DropColumn("dbo.VehicleWizards", "VehicleTopStyleID");
            DropColumn("dbo.VehicleWizards", "VehicleInteriorTypeID");
            DropColumn("dbo.VehicleWizards", "VehicleAudioID");
            DropTable("dbo.VehicleWheels");
            DropTable("dbo.VehicleTopStyles");
            DropTable("dbo.VehicleInteriorTypes");
            DropTable("dbo.VehicleAudios");
        }
    }
}
