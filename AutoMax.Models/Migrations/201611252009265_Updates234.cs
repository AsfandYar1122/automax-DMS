namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates234 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoAirBags",
                c => new
                    { 
                        AutoAirBagID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AutoAirBagID);
            
            CreateTable(
                "dbo.VehicleWizards",
                c => new
                    {
                        VehicleID = c.Long(nullable: false, identity: true),
                        InventoryStatusID = c.Int(nullable: false),
                        StockNumber = c.String(),
                        MMCode = c.String(),
                        PlateNumber = c.String(),
                        AutoConditionID = c.Int(nullable: false),
                        VIN = c.String(),
                        YearID = c.Int(nullable: false),
                        MakerID = c.Int(nullable: false),
                        AutoModelID = c.Int(nullable: false),
                        SubModelID = c.Int(nullable: false),
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
                        UpdateDate = c.DateTime(nullable: false),
                        VehiclePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WarantyText = c.String(),
                        Description = c.String(),
                        UserID = c.Long(nullable: false),
                        AutoAirBagID = c.Int(nullable: false),
                        EngineCapacityID = c.Int(nullable: false),
                        UpholsteryID = c.Int(nullable: false),
                        RoofTypeID = c.Int(nullable: false),
                        VehicleTitleID = c.Int(nullable: false),
                        VehicleTypeID = c.Long(nullable: false),
                        VehicleAudioID = c.Int(nullable: false),
                        VehicleInteriorTypeID = c.Int(nullable: false),
                        VehicleTopStyleID = c.Int(nullable: false),
                        VehicleWheelID = c.Int(nullable: false),
                        RecordStatus = c.Int(nullable: false),
                        MediaPlayerID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.AutoAirBags", t => t.AutoAirBagID, cascadeDelete: true)
                .ForeignKey("dbo.AutoBodyStyles", t => t.AutoBodyStyleID, cascadeDelete: true)
                .ForeignKey("dbo.AutoConditions", t => t.AutoConditionID, cascadeDelete: true)
                .ForeignKey("dbo.AutoDoors", t => t.AutoDoorsID, cascadeDelete: true)
                .ForeignKey("dbo.AutoEngines", t => t.AutoEngineID, cascadeDelete: true)
                .ForeignKey("dbo.AutoExteriorColors", t => t.AutoExteriorColorID, cascadeDelete: true)
                .ForeignKey("dbo.AutoInteriorColors", t => t.AutoInteriorColorID, cascadeDelete: true)
                .ForeignKey("dbo.AutoModels", t => t.AutoModelID, cascadeDelete: true)
                .ForeignKey("dbo.AutoSteerings", t => t.AutoSteeringID, cascadeDelete: true)
                .ForeignKey("dbo.AutoTransmissions", t => t.AutoTransmissionID, cascadeDelete: true)
                .ForeignKey("dbo.DriveTypes", t => t.DriveTypeID, cascadeDelete: true)
                .ForeignKey("dbo.EngineCapacities", t => t.EngineCapacityID, cascadeDelete: true)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeID, cascadeDelete: true)
                .ForeignKey("dbo.InventoryStatus", t => t.InventoryStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Makers", t => t.MakerID, cascadeDelete: true)
                .ForeignKey("dbo.MediaPlayers", t => t.MediaPlayerID, cascadeDelete: true)
                .ForeignKey("dbo.RoofTypes", t => t.RoofTypeID, cascadeDelete: true)
                .ForeignKey("dbo.SubModels", t => t.SubModelID, cascadeDelete: true)
                .ForeignKey("dbo.Upholsteries", t => t.UpholsteryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.VehclieTitles", t => t.VehicleTitleID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleAudios", t => t.VehicleAudioID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleInteriorTypes", t => t.VehicleInteriorTypeID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTopStyles", t => t.VehicleTopStyleID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleWheels", t => t.VehicleWheelID, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearID, cascadeDelete: true)
                .Index(t => t.InventoryStatusID)
                .Index(t => t.AutoConditionID)
                .Index(t => t.YearID)
                .Index(t => t.MakerID)
                .Index(t => t.AutoModelID)
                .Index(t => t.SubModelID)
                .Index(t => t.AutoBodyStyleID)
                .Index(t => t.AutoExteriorColorID)
                .Index(t => t.AutoInteriorColorID)
                .Index(t => t.AutoSteeringID)
                .Index(t => t.AutoDoorsID)
                .Index(t => t.AutoEngineID)
                .Index(t => t.AutoTransmissionID)
                .Index(t => t.FuelTypeID)
                .Index(t => t.DriveTypeID)
                .Index(t => t.UserID)
                .Index(t => t.AutoAirBagID)
                .Index(t => t.EngineCapacityID)
                .Index(t => t.UpholsteryID)
                .Index(t => t.RoofTypeID)
                .Index(t => t.VehicleTitleID)
                .Index(t => t.VehicleTypeID)
                .Index(t => t.VehicleAudioID)
                .Index(t => t.VehicleInteriorTypeID)
                .Index(t => t.VehicleTopStyleID)
                .Index(t => t.VehicleWheelID)
                .Index(t => t.MediaPlayerID);
            
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
                "dbo.EngineCapacities",
                c => new
                    {
                        EngineCapacityID = c.Int(nullable: false, identity: true),
                        Capacity = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EngineCapacityID);
            
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
                "dbo.MediaPlayers",
                c => new
                    {
                        MediaPlayerID = c.Long(nullable: false, identity: true),
                        PlayerName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MediaPlayerID);
            
            CreateTable(
                "dbo.RoofTypes",
                c => new
                    {
                        RoofTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoofTypeID);
            
            CreateTable(
                "dbo.SubModels",
                c => new
                    {
                        SubModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubModelID);
            
            CreateTable(
                "dbo.Upholsteries",
                c => new
                    {
                        UpholsteryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UpholsteryID);
            
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
                "dbo.VehicleImages",
                c => new
                    {
                        VehicleImageID = c.Long(nullable: false, identity: true),
                        ImagePath = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        VehicleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleImageID)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
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
                "dbo.VIRs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fkVehickeId = c.Int(nullable: false),
                        fkUserId = c.Int(nullable: false),
                        fkPartId = c.Int(nullable: false),
                        Condition = c.String(),
                        Part = c.String(),
                        Severity = c.String(),
                        Description = c.String(),
                        CostOfRepair = c.String(),
                        CostOfReplacement = c.String(),
                        EstimatedRepairCost = c.String(),
                        Ratting = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VIRParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VIRPartsType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VIRPartConditionSeverityLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SeverityLevels = c.Double(nullable: false),
                        VIRPartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VIRParts", t => t.VIRPartID, cascadeDelete: true)
                .Index(t => t.VIRPartID);
            
            CreateTable(
                "dbo.VIRStaticDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Name = c.String(),
                        Ratting = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VIRPartConditionSeverityLevels", "VIRPartID", "dbo.VIRParts");
            DropForeignKey("dbo.VehiclePrices", "VehicleWizard_VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehicleWizards", "YearID", "dbo.Years");
            DropForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels");
            DropForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles");
            DropForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes");
            DropForeignKey("dbo.VehicleImages", "VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios");
            DropForeignKey("dbo.VehicleWizards", "VehicleTitleID", "dbo.VehclieTitles");
            DropForeignKey("dbo.VehicleWizards", "UserID", "dbo.Users");
            DropForeignKey("dbo.VehicleWizards", "UpholsteryID", "dbo.Upholsteries");
            DropForeignKey("dbo.VehicleWizards", "SubModelID", "dbo.SubModels");
            DropForeignKey("dbo.VehicleWizards", "RoofTypeID", "dbo.RoofTypes");
            DropForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers");
            DropForeignKey("dbo.VehicleWizards", "MakerID", "dbo.Makers");
            DropForeignKey("dbo.VehicleWizards", "InventoryStatusID", "dbo.InventoryStatus");
            DropForeignKey("dbo.VehicleWizards", "FuelTypeID", "dbo.FuelTypes");
            DropForeignKey("dbo.VehicleWizards", "EngineCapacityID", "dbo.EngineCapacities");
            DropForeignKey("dbo.VehicleWizards", "DriveTypeID", "dbo.DriveTypes");
            DropForeignKey("dbo.VehicleWizards", "AutoTransmissionID", "dbo.AutoTransmissions");
            DropForeignKey("dbo.VehicleWizards", "AutoSteeringID", "dbo.AutoSteerings");
            DropForeignKey("dbo.VehicleWizards", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleWizards", "AutoInteriorColorID", "dbo.AutoInteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoExteriorColorID", "dbo.AutoExteriorColors");
            DropForeignKey("dbo.VehicleWizards", "AutoEngineID", "dbo.AutoEngines");
            DropForeignKey("dbo.VehicleWizards", "AutoDoorsID", "dbo.AutoDoors");
            DropForeignKey("dbo.VehicleWizards", "AutoConditionID", "dbo.AutoConditions");
            DropForeignKey("dbo.VehicleWizards", "AutoBodyStyleID", "dbo.AutoBodyStyles");
            DropForeignKey("dbo.VehicleWizards", "AutoAirBagID", "dbo.AutoAirBags");
            DropIndex("dbo.VIRPartConditionSeverityLevels", new[] { "VIRPartID" });
            DropIndex("dbo.VehiclePrices", new[] { "VehicleWizard_VehicleID" });
            DropIndex("dbo.VehicleImages", new[] { "VehicleID" });
            DropIndex("dbo.VehicleWizards", new[] { "MediaPlayerID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleWheelID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTopStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleInteriorTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleAudioID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTitleID" });
            DropIndex("dbo.VehicleWizards", new[] { "RoofTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "UpholsteryID" });
            DropIndex("dbo.VehicleWizards", new[] { "EngineCapacityID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoAirBagID" });
            DropIndex("dbo.VehicleWizards", new[] { "UserID" });
            DropIndex("dbo.VehicleWizards", new[] { "DriveTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "FuelTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoTransmissionID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoEngineID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoDoorsID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoSteeringID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoInteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoExteriorColorID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoBodyStyleID" });
            DropIndex("dbo.VehicleWizards", new[] { "SubModelID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoModelID" });
            DropIndex("dbo.VehicleWizards", new[] { "MakerID" });
            DropIndex("dbo.VehicleWizards", new[] { "YearID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoConditionID" });
            DropIndex("dbo.VehicleWizards", new[] { "InventoryStatusID" });
            DropTable("dbo.VIRStaticDatas");
            DropTable("dbo.VIRPartConditionSeverityLevels");
            DropTable("dbo.VIRParts");
            DropTable("dbo.VIRs");
            DropTable("dbo.VehicleTemplates");
            DropTable("dbo.VehiclePrices");
            DropTable("dbo.AutoGlobalizations");
            DropTable("dbo.Years");
            DropTable("dbo.VehicleWheels");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleTopStyles");
            DropTable("dbo.VehicleInteriorTypes");
            DropTable("dbo.VehicleImages");
            DropTable("dbo.VehicleAudios");
            DropTable("dbo.VehclieTitles");
            DropTable("dbo.Users");
            DropTable("dbo.Upholsteries");
            DropTable("dbo.SubModels");
            DropTable("dbo.RoofTypes");
            DropTable("dbo.MediaPlayers");
            DropTable("dbo.Makers");
            DropTable("dbo.InventoryStatus");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.EngineCapacities");
            DropTable("dbo.DriveTypes");
            DropTable("dbo.AutoTransmissions");
            DropTable("dbo.AutoSteerings");
            DropTable("dbo.AutoModels");
            DropTable("dbo.AutoInteriorColors");
            DropTable("dbo.AutoExteriorColors");
            DropTable("dbo.AutoEngines");
            DropTable("dbo.AutoDoors");
            DropTable("dbo.AutoConditions");
            DropTable("dbo.AutoBodyStyles");
            DropTable("dbo.VehicleWizards");
            DropTable("dbo.AutoAirBags");
        }
    }
}
