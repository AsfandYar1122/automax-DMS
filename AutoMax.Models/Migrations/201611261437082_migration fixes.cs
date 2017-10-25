namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationfixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleWizards", "MediaPlayer_MediaPlayerID", "dbo.MediaPlayers");
            DropIndex("dbo.VehicleWizards", new[] { "MediaPlayer_MediaPlayerID" });
            RenameColumn(table: "dbo.VehicleWizards", name: "MediaPlayer_MediaPlayerID", newName: "MediaPlayerID");
            AddColumn("dbo.VehicleWizards", "VehicleTypeID", c => c.Long(nullable: false));
            AddColumn("dbo.VehicleWizards", "RecordStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.VehicleWizards", "MediaPlayerID", c => c.Long(nullable: false));
            CreateIndex("dbo.VehicleWizards", "VehicleTypeID");
            CreateIndex("dbo.VehicleWizards", "MediaPlayerID");
            AddForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes", "VehicleTypeID", cascadeDelete: true);
            AddForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers", "MediaPlayerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers");
            DropForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes");
            DropIndex("dbo.VehicleWizards", new[] { "MediaPlayerID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTypeID" });
            AlterColumn("dbo.VehicleWizards", "MediaPlayerID", c => c.Long());
            DropColumn("dbo.VehicleWizards", "RecordStatus");
            DropColumn("dbo.VehicleWizards", "VehicleTypeID");
            RenameColumn(table: "dbo.VehicleWizards", name: "MediaPlayerID", newName: "MediaPlayer_MediaPlayerID");
            CreateIndex("dbo.VehicleWizards", "MediaPlayer_MediaPlayerID");
            AddForeignKey("dbo.VehicleWizards", "MediaPlayer_MediaPlayerID", "dbo.MediaPlayers", "MediaPlayerID");
        }
    }
}
