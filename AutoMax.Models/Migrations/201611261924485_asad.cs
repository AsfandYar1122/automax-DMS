namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asad : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers");
            DropForeignKey("dbo.VehiclePartImages", "VIRID", "dbo.VIRs");
            DropForeignKey("dbo.VehiclePartImages", "VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes");
            DropIndex("dbo.VehiclePartImages", new[] { "VIRID" });
            DropIndex("dbo.VehiclePartImages", new[] { "VehicleID" });
            DropIndex("dbo.VehicleWizards", new[] { "MediaPlayerID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTypeID" });
            AlterColumn("dbo.VehicleWizards", "MediaPlayerID", c => c.Long());
            DropColumn("dbo.VehicleWizards", "RecordStatus");
            DropColumn("dbo.VehicleWizards", "VehicleTypeID");
            DropTable("dbo.VehiclePartImages");
            RenameColumn(table: "dbo.VehicleWizards", name: "MediaPlayerID", newName: "MediaPlayer_MediaPlayerID");
            CreateIndex("dbo.VehicleWizards", "MediaPlayer_MediaPlayerID");
            AddForeignKey("dbo.VehicleWizards", "MediaPlayer_MediaPlayerID", "dbo.MediaPlayers", "MediaPlayerID");
        }
    }
}
