namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial33 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoBodyStyles",
                c => new
                    {
                        AutoBodyStyleID = c.Int(nullable: false, identity: true),
                        BodyStyle = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoBodyStyleID);
            
            CreateTable(
                "dbo.VehicleWizards",
                c => new
                    {
                        VehicleID = c.Long(nullable: false, identity: true),
                        InventoryStatusID = c.Int(nullable: false),
                        StockNumber = c.String(),
                        MMCode = c.String(),
                        PlateNumber = c.String(),
                        MotorizedTypeID = c.Int(nullable: false),
                        VIN = c.String(),
                        YearID = c.Int(nullable: false),
                        MakerID = c.Int(nullable: false),
                        AutoModelID = c.Int(nullable: false),
                        VehicleTrimID = c.Int(nullable: false),
                        FreeText = c.String(),
                        AutoBodyStyleID = c.Int(nullable: false),
                        Odometer = c.String(),
                        AutoExteriorColorID = c.Long(nullable: false),
                        AutoInteriorColorID = c.Long(nullable: false),
                        AutoSteeringID = c.Long(nullable: false),
                        AutoDoorsID = c.Long(nullable: false),
                        AutoEngineID = c.Long(nullable: false),
                        AutoTransmissionID = c.Long(nullable: false),
                        FuelTypeID = c.Long(nullable: false),
                        DriveTypeID = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifieddDate = c.DateTime(nullable: false),
                        AutoCondition_AutoConditionID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.AutoBodyStyles", t => t.AutoBodyStyleID, cascadeDelete: true)
                .ForeignKey("dbo.AutoDoors", t => t.AutoDoorsID, cascadeDelete: true)
                .ForeignKey("dbo.AutoEngines", t => t.AutoEngineID, cascadeDelete: true)
                .ForeignKey("dbo.AutoExteriorColors", t => t.AutoExteriorColorID, cascadeDelete: true)
                .ForeignKey("dbo.AutoInteriorColors", t => t.AutoInteriorColorID, cascadeDelete: true)
                .ForeignKey("dbo.AutoModels", t => t.AutoModelID, cascadeDelete: true)
                .ForeignKey("dbo.AutoSteerings", t => t.AutoSteeringID, cascadeDelete: true)
                .ForeignKey("dbo.AutoTransmissions", t => t.AutoTransmissionID, cascadeDelete: true)
                .ForeignKey("dbo.DriveTypes", t => t.DriveTypeID, cascadeDelete: true)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Makers", t => t.MakerID, cascadeDelete: true)
                .ForeignKey("dbo.MotorizedTypes", t => t.MotorizedTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearID, cascadeDelete: true)
                .ForeignKey("dbo.AutoConditions", t => t.AutoCondition_AutoConditionID)
                .ForeignKey("dbo.InventoryStatus", t => t.InventoryStatusID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTrims", t => t.VehicleTrimID, cascadeDelete: true)
                .Index(t => t.InventoryStatusID)
                .Index(t => t.MotorizedTypeID)
                .Index(t => t.YearID)
                .Index(t => t.MakerID)
                .Index(t => t.AutoModelID)
                .Index(t => t.VehicleTrimID)
                .Index(t => t.AutoBodyStyleID)
                .Index(t => t.AutoExteriorColorID)
                .Index(t => t.AutoInteriorColorID)
                .Index(t => t.AutoSteeringID)
                .Index(t => t.AutoDoorsID)
                .Index(t => t.AutoEngineID)
                .Index(t => t.AutoTransmissionID)
                .Index(t => t.FuelTypeID)
                .Index(t => t.DriveTypeID)
                .Index(t => t.AutoCondition_AutoConditionID);
            
            CreateTable(
                "dbo.AutoDoors",
                c => new
                    {
                        AutoDoorsID = c.Long(nullable: false, identity: true),
                        Doors = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoDoorsID);
            
            CreateTable(
                "dbo.AutoEngines",
                c => new
                    {
                        AutoEngineID = c.Long(nullable: false, identity: true),
                        EngineName = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoEngineID);
            
            CreateTable(
                "dbo.AutoExteriorColors",
                c => new
                    {
                        AutoExteriorColorID = c.Long(nullable: false, identity: true),
                        ExteriorColor = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoExteriorColorID);
            
            CreateTable(
                "dbo.AutoInteriorColors",
                c => new
                    {
                        AutoInteriorColorID = c.Long(nullable: false, identity: true),
                        InteriorColor = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoInteriorColorID);
            
            CreateTable(
                "dbo.AutoModels",
                c => new
                    {
                        AutoModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoModelID);
            
            CreateTable(
                "dbo.AutoSteerings",
                c => new
                    {
                        AutoSteeringID = c.Long(nullable: false, identity: true),
                        Steering = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoSteeringID);
            
            CreateTable(
                "dbo.AutoTransmissions",
                c => new
                    {
                        AutoTransmissionID = c.Long(nullable: false, identity: true),
                        Transmission = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoTransmissionID);
            
            CreateTable(
                "dbo.DriveTypes",
                c => new
                    {
                        DriveTypeID = c.Long(nullable: false, identity: true),
                        DriveTypeV = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DriveTypeID);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        FuelTypeID = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FuelTypeID);
            
            CreateTable(
                "dbo.Makers",
                c => new
                    {
                        MakerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MakerID);
            
            CreateTable(
                "dbo.MotorizedTypes",
                c => new
                    {
                        MotorizedTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MotorizedTypeID);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        YearID = c.Int(nullable: false, identity: true),
                        YearName = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.YearID);
            
            CreateTable(
                "dbo.AutoConditions",
                c => new
                    {
                        AutoConditionID = c.Int(nullable: false, identity: true),
                        Condition = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoConditionID);
            
            CreateTable(
                "dbo.AutoGlobalizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        En = c.String(),
                        Ar = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InventoryStatus",
                c => new
                    {
                        InventoryStatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryStatusID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        PasswordToken = c.String(),
                        LinkExpiryDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.VehclieTitles",
                c => new
                    {
                        VehicleTitleID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleTitleID);
            
            CreateTable(
                "dbo.VehicleImages",
                c => new
                    {
                        VehicleImageID = c.Long(nullable: false, identity: true),
                        ImagePath = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        Vechile_VehicleID = c.Long(),
                    })
                .PrimaryKey(t => t.VehicleImageID)
                .ForeignKey("dbo.VehicleWizards", t => t.Vechile_VehicleID)
                .Index(t => t.Vechile_VehicleID);
            
            CreateTable(
                "dbo.VehiclePrices",
                c => new
                    {
                        VehiclePriceID = c.Int(nullable: false, identity: true),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ByNowWholeSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConsignedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaleCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InternetPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlternativePrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlternativePrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlternativePrice3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceVehicleID = c.Long(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        VehicleWizard_VehicleID = c.Long(),
                    })
                .PrimaryKey(t => t.VehiclePriceID)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleWizard_VehicleID)
                .Index(t => t.VehicleWizard_VehicleID);
            
            CreateTable(
                "dbo.VehicleTemplates",
                c => new
                    {
                        VehicleTemplateID = c.Int(nullable: false, identity: true),
                        TemplateName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleTemplateID);
            
            CreateTable(
                "dbo.VehicleTrims",
                c => new
                    {
                        VehicleTrimID = c.Int(nullable: false, identity: true),
                        TrimName = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleTrimID);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeID = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        VehicleTypeValue = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWizards", "VehicleTrimID", "dbo.VehicleTrims");
            DropForeignKey("dbo.VehiclePrices", "VehicleWizard_VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehicleImages", "Vechile_VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehicleWizards", "InventoryStatusID", "dbo.InventoryStatus");
            DropForeignKey("dbo.VehicleWizards", "AutoCondition_AutoConditionID", "dbo.AutoConditions");
            DropForeignKey("dbo.VehicleWizards", "YearID", "dbo.Years");
            DropForeignKey("dbo.VehicleWizards", "MotorizedTypeID", "dbo.MotorizedTypes");
            DropForeignKey("dbo.VehicleWizards", "MakerID", "dbo.Makers");
            DropForeignKey("dbo.VehicleWizards", "FuelTypeID", "dbo.FuelTypes");
            DropForeignKey("dbo.VehicleWizards", "DriveTypeID", "dbo.DriveTypes");
            DropForeignKey("dbo.VehicleWizards", "AutoTransmissionID", "dbo.AutoTransmissions");
            DropForeignKey("dbo.VehicleWizards", "AutoSteeringID", "dbo.AutoSteerings");
            DropForeignKey("dbo.VehicleWizards", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleWizards", "AutoInteriorColorID", "dbo.AutoInteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoExteriorColorID", "dbo.AutoExteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoEngineID", "dbo.AutoEngines");
            DropForeignKey("dbo.VehicleWizards", "AutoDoorsID", "dbo.AutoDoors");
            DropForeignKey("dbo.VehicleWizards", "AutoBodyStyleID", "dbo.AutoBodyStyles");
            DropIndex("dbo.VehiclePrices", new[] { "VehicleWizard_VehicleID" });
            DropIndex("dbo.VehicleImages", new[] { "Vechile_VehicleID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoCondition_AutoConditionID" });
            DropIndex("dbo.VehicleWizards", new[] { "DriveTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "FuelTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoTransmissionID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoEngineID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoDoorsID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoSteeringID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoInteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoExteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoBodyStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTrimID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoModelID" });
            DropIndex("dbo.VehicleWizards", new[] { "MakerID" });
            DropIndex("dbo.VehicleWizards", new[] { "YearID" });
            DropIndex("dbo.VehicleWizards", new[] { "MotorizedTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "InventoryStatusID" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleTrims");
            DropTable("dbo.VehicleTemplates");
            DropTable("dbo.VehiclePrices");
            DropTable("dbo.VehicleImages");
            DropTable("dbo.VehclieTitles");
            DropTable("dbo.Users");
            DropTable("dbo.InventoryStatus");
            DropTable("dbo.AutoGlobalizations");
            DropTable("dbo.AutoConditions");
            DropTable("dbo.Years");
            DropTable("dbo.MotorizedTypes");
            DropTable("dbo.Makers");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.DriveTypes");
            DropTable("dbo.AutoTransmissions");
            DropTable("dbo.AutoSteerings");
            DropTable("dbo.AutoModels");
            DropTable("dbo.AutoInteriorColors");
            DropTable("dbo.AutoExteriorColors");
            DropTable("dbo.AutoEngines");
            DropTable("dbo.AutoDoors");
            DropTable("dbo.VehicleWizards");
            DropTable("dbo.AutoBodyStyles");
        }
    }
}
