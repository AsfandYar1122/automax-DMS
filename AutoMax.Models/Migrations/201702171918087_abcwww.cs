namespace AutoMax.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcwww : DbMigration
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
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoAirBagID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoBodyStyles",
                c => new
                    {
                        AutoBodyStyleID = c.Int(nullable: false, identity: true),
                        BodyStyle = c.String(),
                        ArabicBodyStyle = c.String(),
                        Description = c.String(),
                        ArabicDescription = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoBodyStyleID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VehicleWizards",
                c => new
                    {
                        VehicleID = c.Long(nullable: false, identity: true),
                        InventoryStatusID = c.Int(),
                        StockNumber = c.String(),
                        MMCode = c.String(),
                        PlateNumber = c.String(),
                        AutoConditionID = c.Int(),
                        VIN = c.String(),
                        YearID = c.Int(),
                        MakerID = c.Int(),
                        AutoModelID = c.Int(),
                        SubModelID = c.Int(),
                        FreeText = c.String(),
                        AutoBodyStyleID = c.Int(),
                        Odometer = c.String(),
                        AutoExteriorColorID = c.Long(),
                        AutoInteriorColorID = c.Long(),
                        AutoSteeringID = c.Long(),
                        AutoDoorsID = c.Long(),
                        AutoEngineID = c.Long(),
                        AutoTransmissionID = c.Long(),
                        FuelTypeID = c.Long(),
                        DriveTypeID = c.Long(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        VehiclePrice = c.Decimal(precision: 18, scale: 2),
                        WarantyText = c.String(),
                        Description = c.String(),
                        UserID = c.Long(nullable: false),
                        AutoAirBagID = c.Int(),
                        EngineCapacityID = c.Int(),
                        UpholsteryID = c.Int(),
                        RoofTypeID = c.Int(),
                        VehicleTitleID = c.Int(),
                        VehicleTypeID = c.Long(),
                        VehicleAudioID = c.Int(),
                        VehicleInteriorTypeID = c.Int(),
                        VehicleTopStyleID = c.Int(),
                        VehicleWheelID = c.Int(),
                        MediaPlayerID = c.Long(),
                        VehicleOptions = c.String(),
                        VehicleMoreOptions = c.String(),
                        VehicleFlags = c.String(),
                        VehiclemoreFlags = c.String(),
                        VehicleAddressId = c.Int(),
                        ExteriorRatting = c.Double(),
                        InteriorRatting = c.Double(),
                        MechanicsRatting = c.Double(),
                        FrameRatting = c.Double(),
                        TotalRatting = c.Double(),
                        VIRCompletenessPercentage = c.Double(),
                        IsDeleted = c.Boolean(),
                        LanguageID = c.Int(),
                        IsFeatured = c.Boolean(),
                        PurchasingCost = c.Decimal(precision: 18, scale: 2),
                        Has360 = c.Boolean(),
                        MilageValue = c.String(),
                        Branch = c.String(),
                        Location = c.String(),
                        AutoUsedStatusID = c.Long(),
                        ArabicWarantyText = c.String(),
                        ArabicDescription = c.String(),
                        ArabicFreeText = c.String(),
                        ArabicVehicleMoreOptions = c.String(),
                        ArabicVehicleMoreFlags = c.String(),
                        EvaluatorExteriorRatting = c.Double(),
                        EvaluatorInteriorRatting = c.Double(),
                        EvaluatorMechanicsRatting = c.Double(),
                        EvaluatorFrameRatting = c.Double(),
                        EvaluatorTotalRatting = c.Double(),
                        Milage_MilageID = c.Int(),
                        MotorizedType_MotorizedTypeID = c.Int(),
                        VehicleTrim_VehicleTrimID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.AutoAirBags", t => t.AutoAirBagID)
                .ForeignKey("dbo.AutoBodyStyles", t => t.AutoBodyStyleID)
                .ForeignKey("dbo.AutoConditions", t => t.AutoConditionID)
                .ForeignKey("dbo.AutoDoors", t => t.AutoDoorsID)
                .ForeignKey("dbo.AutoEngines", t => t.AutoEngineID)
                .ForeignKey("dbo.AutoExteriorColors", t => t.AutoExteriorColorID)
                .ForeignKey("dbo.AutoInteriorColors", t => t.AutoInteriorColorID)
                .ForeignKey("dbo.Makers", t => t.MakerID)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeID)
                .ForeignKey("dbo.SubModels", t => t.SubModelID)
                .ForeignKey("dbo.AutoModels", t => t.AutoModelID)
                .ForeignKey("dbo.AutoSteerings", t => t.AutoSteeringID)
                .ForeignKey("dbo.AutoTransmissions", t => t.AutoTransmissionID)
                .ForeignKey("dbo.AutoUsedStatus", t => t.AutoUsedStatusID)
                .ForeignKey("dbo.DriveTypes", t => t.DriveTypeID)
                .ForeignKey("dbo.EngineCapacities", t => t.EngineCapacityID)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeID)
                .ForeignKey("dbo.InventoryStatus", t => t.InventoryStatusID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.MediaPlayers", t => t.MediaPlayerID)
                .ForeignKey("dbo.RoofTypes", t => t.RoofTypeID)
                .ForeignKey("dbo.Upholsteries", t => t.UpholsteryID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.VehclieTitles", t => t.VehicleTitleID)
                .ForeignKey("dbo.VehicleAddresses", t => t.VehicleAddressId)
                .ForeignKey("dbo.VehicleAudios", t => t.VehicleAudioID)
                .ForeignKey("dbo.VehicleInteriorTypes", t => t.VehicleInteriorTypeID)
                .ForeignKey("dbo.VehicleTopStyles", t => t.VehicleTopStyleID)
                .ForeignKey("dbo.VehicleWheels", t => t.VehicleWheelID)
                .ForeignKey("dbo.Years", t => t.YearID)
                .ForeignKey("dbo.Milages", t => t.Milage_MilageID)
                .ForeignKey("dbo.MotorizedTypes", t => t.MotorizedType_MotorizedTypeID)
                .ForeignKey("dbo.VehicleTrims", t => t.VehicleTrim_VehicleTrimID)
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
                .Index(t => t.MediaPlayerID)
                .Index(t => t.VehicleAddressId)
                .Index(t => t.LanguageID)
                .Index(t => t.AutoUsedStatusID)
                .Index(t => t.Milage_MilageID)
                .Index(t => t.MotorizedType_MotorizedTypeID)
                .Index(t => t.VehicleTrim_VehicleTrimID);
            
            CreateTable(
                "dbo.AutoConditions",
                c => new
                    {
                        AutoConditionID = c.Int(nullable: false, identity: true),
                        Condition = c.String(),
                        ArabicCondition = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoConditionID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoDoors",
                c => new
                    {
                        AutoDoorsID = c.Long(nullable: false, identity: true),
                        Doors = c.String(),
                        ArabicDoors = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoDoorsID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoEngines",
                c => new
                    {
                        AutoEngineID = c.Long(nullable: false, identity: true),
                        EngineName = c.String(),
                        ArabicEngineName = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoEngineID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoExteriorColors",
                c => new
                    {
                        AutoExteriorColorID = c.Long(nullable: false, identity: true),
                        ExteriorColor = c.String(),
                        ArabicExteriorColor = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoExteriorColorID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoInteriorColors",
                c => new
                    {
                        AutoInteriorColorID = c.Long(nullable: false, identity: true),
                        InteriorColor = c.String(),
                        ArabicInteriorColor = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoInteriorColorID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoModels",
                c => new
                    {
                        AutoModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        ArabicModelName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                        MakerID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoModelID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.Makers", t => t.MakerID)
                .Index(t => t.LanguageID)
                .Index(t => t.MakerID);
            
            CreateTable(
                "dbo.Makers",
                c => new
                    {
                        MakerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArabicName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                        VehicleTypeID = c.Long(),
                    })
                .PrimaryKey(t => t.MakerID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeID)
                .Index(t => t.LanguageID)
                .Index(t => t.VehicleTypeID);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeID = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        ArabicType = c.String(),
                        VehicleTypeValue = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleTypeID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.SubModels",
                c => new
                    {
                        SubModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        ArabicModelName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AutoModelID = c.Int(),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.SubModelID)
                .ForeignKey("dbo.AutoModels", t => t.AutoModelID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.AutoModelID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoSteerings",
                c => new
                    {
                        AutoSteeringID = c.Long(nullable: false, identity: true),
                        Steering = c.String(),
                        ArabicSteering = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoSteeringID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoTransmissions",
                c => new
                    {
                        AutoTransmissionID = c.Long(nullable: false, identity: true),
                        Transmission = c.String(),
                        ArabicTransmission = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoTransmissionID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoUsedStatus",
                c => new
                    {
                        AutoUsedStatusID = c.Long(nullable: false, identity: true),
                        UsedStatus = c.String(),
                        ArabicUsedStatus = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoUsedStatusID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.DriveTypes",
                c => new
                    {
                        DriveTypeID = c.Long(nullable: false, identity: true),
                        DriveTypeV = c.String(),
                        ArabicDriveTypeV = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.DriveTypeID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.EngineCapacities",
                c => new
                    {
                        EngineCapacityID = c.Int(nullable: false, identity: true),
                        Capacity = c.String(),
                        ArabicCapacity = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.EngineCapacityID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        FuelTypeID = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        ArabicType = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.FuelTypeID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.InventoryStatus",
                c => new
                    {
                        InventoryStatusID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        ArabicStatus = c.String(),
                        Description = c.String(),
                        ArabicDescription = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryStatusID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.MediaPlayers",
                c => new
                    {
                        MediaPlayerID = c.Long(nullable: false, identity: true),
                        PlayerName = c.String(),
                        ArabicPlayerName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.MediaPlayerID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.RoofTypes",
                c => new
                    {
                        RoofTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ArabicType = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.RoofTypeID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.Upholsteries",
                c => new
                    {
                        UpholsteryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArabicName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.UpholsteryID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        ArabicFirstName = c.String(),
                        LastName = c.String(),
                        ArabicLastName = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        PasswordToken = c.String(),
                        LinkExpiryDate = c.DateTime(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UserRoleID = c.Int(),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleID)
                .Index(t => t.UserRoleID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        ArabicRole = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.UserRoleID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VehclieTitles",
                c => new
                    {
                        VehicleTitleID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ArabicTitle = c.String(),
                        Description = c.String(),
                        ArabicDescription = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleTitleID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VehicleAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArabicName = c.String(),
                        PhysicalAddress = c.String(),
                        ArabicPhysicalAddress = c.String(),
                        GoogleAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleAudios",
                c => new
                    {
                        AudioID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ArabicType = c.String(),
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
                        DisplayOrder = c.Int(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        VehicleID = c.Long(nullable: false),
                        LanguageID = c.Int(),
                        IsFeatured = c.Int(),
                        ExternalURL = c.String(),
                    })
                .PrimaryKey(t => t.VehicleImageID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VehicleInteriorTypes",
                c => new
                    {
                        InteriorTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ArabicType = c.String(),
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
                        ArabicType = c.String(),
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
                        ArabicType = c.String(),
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
                        ArabicYearName = c.String(),
                        Value = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.YearID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoGlobalizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        En = c.String(),
                        Ar = c.String(),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.AutoTransmissionMappings",
                c => new
                    {
                        AutoTransmissionMappingID = c.Int(nullable: false, identity: true),
                        AutoTransmissionID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                        AutoTransmission_AutoTransmissionID = c.Long(),
                    })
                .PrimaryKey(t => t.AutoTransmissionMappingID)
                .ForeignKey("dbo.AutoTransmissions", t => t.AutoTransmission_AutoTransmissionID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID)
                .Index(t => t.AutoTransmission_AutoTransmissionID);
            
            CreateTable(
                "dbo.MakerMappings",
                c => new
                    {
                        MakerMappingID = c.Int(nullable: false, identity: true),
                        MakerId = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.MakerMappingID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.Makers", t => t.MakerId, cascadeDelete: true)
                .Index(t => t.MakerId)
                .Index(t => t.LanguageID);
            
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
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.MotorizedTypeID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.PostingDetails",
                c => new
                    {
                        PostingDetailID = c.Int(nullable: false, identity: true),
                        PostingTitle = c.String(),
                        PostingDescription = c.String(),
                        PublishPrice = c.Boolean(nullable: false),
                        Negotiable = c.Boolean(nullable: false),
                        PostingStatusID = c.Int(nullable: false),
                        PostingSiteID = c.Int(nullable: false),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                        VehicleWizardId = c.Long(nullable: false),
                        PostingSiteUser_PostingSiteUserID = c.Int(),
                        VehicleWizard_VehicleID = c.Long(),
                    })
                .PrimaryKey(t => t.PostingDetailID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.PostingSites", t => t.PostingSiteID, cascadeDelete: true)
                .ForeignKey("dbo.PostingSiteUsers", t => t.PostingSiteUser_PostingSiteUserID)
                .ForeignKey("dbo.PostingStatus", t => t.PostingStatusID, cascadeDelete: true)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleWizard_VehicleID)
                .Index(t => t.PostingStatusID)
                .Index(t => t.PostingSiteID)
                .Index(t => t.LanguageID)
                .Index(t => t.PostingSiteUser_PostingSiteUserID)
                .Index(t => t.VehicleWizard_VehicleID);
            
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
                        ArabicFieldName = c.String(),
                        ArabicLinkedFieldName = c.String(),
                        DisplayName = c.String(),
                        ArabicDisplayName = c.String(),
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
                "dbo.SubModelMappings",
                c => new
                    {
                        SubModelMappingID = c.Int(nullable: false, identity: true),
                        SubModelID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.SubModelMappingID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.SubModels", t => t.SubModelID, cascadeDelete: true)
                .Index(t => t.SubModelID)
                .Index(t => t.LanguageID);
            
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
                        LanguageID = c.Int(),
                        VehicleWizard_VehicleID = c.Long(),
                    })
                .PrimaryKey(t => t.VehiclePriceID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleWizard_VehicleID)
                .Index(t => t.LanguageID)
                .Index(t => t.VehicleWizard_VehicleID);
            
            CreateTable(
                "dbo.VehicleTemplates",
                c => new
                    {
                        VehicleTemplateID = c.Int(nullable: false, identity: true),
                        TemplateName = c.String(),
                        ArabicTemplateName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleTemplateID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
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
            
            CreateTable(
                "dbo.AutoModelMappings",
                c => new
                    {
                        AutoModelMappingID = c.Int(nullable: false, identity: true),
                        AutoModelID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.AutoModelMappingID)
                .ForeignKey("dbo.AutoModels", t => t.AutoModelID, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.AutoModelID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.PostingConfigurations",
                c => new
                    {
                        PostingConfigurationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostingConfigurationID);
            
            CreateTable(
                "dbo.VehiclePartImages",
                c => new
                    {
                        VehiclePartImageID = c.Long(nullable: false, identity: true),
                        ImagePath = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        VehicleID = c.Long(nullable: false),
                        VIRID = c.Int(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehiclePartImageID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.VIRs", t => t.VIRID, cascadeDelete: true)
                .Index(t => t.VehicleID)
                .Index(t => t.VIRID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VIRs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fkVehickeId = c.Int(nullable: false),
                        fkUserId = c.Int(nullable: false),
                        fkPartId = c.Int(nullable: false),
                        Condition = c.String(),
                        ArabicCondition = c.String(),
                        Part = c.String(),
                        ArabicPart = c.String(),
                        Severity = c.Double(nullable: false),
                        Description = c.String(),
                        ArabicDescription = c.String(),
                        CostOfRepair = c.String(),
                        CostOfReplacement = c.String(),
                        EstimatedRepairCost = c.String(),
                        Ratting = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTitleMappings",
                c => new
                    {
                        VehicleTitleMappingID = c.Int(nullable: false, identity: true),
                        VehicleTitleID = c.Int(nullable: false),
                        OpensooqName = c.String(),
                        HarajName = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleTitleMappingID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehclieTitles", t => t.VehicleTitleID, cascadeDelete: true)
                .Index(t => t.VehicleTitleID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VehicleTrims",
                c => new
                    {
                        VehicleTrimID = c.Int(nullable: false, identity: true),
                        Trim = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        UpdatedBy = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        LanguageID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleTrimID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VehicleVideos",
                c => new
                    {
                        VehicleVideoID = c.Long(nullable: false, identity: true),
                        VideoPath = c.String(),
                        DisplayOrder = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        VehicleID = c.Long(nullable: false),
                        LanguageID = c.Int(),
                        IsFeatured = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleVideoID)
                .ForeignKey("dbo.Languages", t => t.LanguageID)
                .ForeignKey("dbo.VehicleWizards", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.VIRFlagProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VIROptionProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VIRParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArabicName = c.String(),
                        VIRPartsType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VIRPartConditionSeverityLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ArabicName = c.String(),
                        SeverityLevels = c.Double(nullable: false),
                        VIRPartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VIRParts", t => t.VIRPartID, cascadeDelete: true)
                .Index(t => t.VIRPartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VIRPartConditionSeverityLevels", "VIRPartID", "dbo.VIRParts");
            DropForeignKey("dbo.VehicleVideos", "VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehicleVideos", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "VehicleTrim_VehicleTrimID", "dbo.VehicleTrims");
            DropForeignKey("dbo.VehicleTrims", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleTitleMappings", "VehicleTitleID", "dbo.VehclieTitles");
            DropForeignKey("dbo.VehicleTitleMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehiclePartImages", "VIRID", "dbo.VIRs");
            DropForeignKey("dbo.VehiclePartImages", "VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehiclePartImages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoModelMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoModelMappings", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleTemplates", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehiclePrices", "VehicleWizard_VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehiclePrices", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.SubModelMappings", "SubModelID", "dbo.SubModels");
            DropForeignKey("dbo.SubModelMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.PostingDetails", "VehicleWizard_VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.PostingDetails", "PostingStatusID", "dbo.PostingStatus");
            DropForeignKey("dbo.PostingDetails", "PostingSiteUser_PostingSiteUserID", "dbo.PostingSiteUsers");
            DropForeignKey("dbo.PostingSiteUsers", "PostingSiteID", "dbo.PostingSites");
            DropForeignKey("dbo.PostingFields", "PostingSiteID", "dbo.PostingSites");
            DropForeignKey("dbo.PostingDetails", "PostingSiteID", "dbo.PostingSites");
            DropForeignKey("dbo.PostingDetails", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "MotorizedType_MotorizedTypeID", "dbo.MotorizedTypes");
            DropForeignKey("dbo.MotorizedTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "Milage_MilageID", "dbo.Milages");
            DropForeignKey("dbo.Milages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.MakerMappings", "MakerId", "dbo.Makers");
            DropForeignKey("dbo.MakerMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoTransmissionMappings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoTransmissionMappings", "AutoTransmission_AutoTransmissionID", "dbo.AutoTransmissions");
            DropForeignKey("dbo.AutoGlobalizations", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "YearID", "dbo.Years");
            DropForeignKey("dbo.Years", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "VehicleWheelID", "dbo.VehicleWheels");
            DropForeignKey("dbo.VehicleWizards", "VehicleTopStyleID", "dbo.VehicleTopStyles");
            DropForeignKey("dbo.VehicleWizards", "VehicleInteriorTypeID", "dbo.VehicleInteriorTypes");
            DropForeignKey("dbo.VehicleImages", "VehicleID", "dbo.VehicleWizards");
            DropForeignKey("dbo.VehicleImages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "VehicleAudioID", "dbo.VehicleAudios");
            DropForeignKey("dbo.VehicleWizards", "VehicleAddressId", "dbo.VehicleAddresses");
            DropForeignKey("dbo.VehicleWizards", "VehicleTitleID", "dbo.VehclieTitles");
            DropForeignKey("dbo.VehclieTitles", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRoleID", "dbo.UserRoles");
            DropForeignKey("dbo.UserRoles", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Users", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "UpholsteryID", "dbo.Upholsteries");
            DropForeignKey("dbo.Upholsteries", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "RoofTypeID", "dbo.RoofTypes");
            DropForeignKey("dbo.RoofTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "MediaPlayerID", "dbo.MediaPlayers");
            DropForeignKey("dbo.MediaPlayers", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "InventoryStatusID", "dbo.InventoryStatus");
            DropForeignKey("dbo.InventoryStatus", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "FuelTypeID", "dbo.FuelTypes");
            DropForeignKey("dbo.FuelTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "EngineCapacityID", "dbo.EngineCapacities");
            DropForeignKey("dbo.EngineCapacities", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "DriveTypeID", "dbo.DriveTypes");
            DropForeignKey("dbo.DriveTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoUsedStatusID", "dbo.AutoUsedStatus");
            DropForeignKey("dbo.AutoUsedStatus", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoTransmissionID", "dbo.AutoTransmissions");
            DropForeignKey("dbo.AutoTransmissions", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoSteeringID", "dbo.AutoSteerings");
            DropForeignKey("dbo.AutoSteerings", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleWizards", "SubModelID", "dbo.SubModels");
            DropForeignKey("dbo.SubModels", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.SubModels", "AutoModelID", "dbo.AutoModels");
            DropForeignKey("dbo.VehicleWizards", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.Makers", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypes", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "MakerID", "dbo.Makers");
            DropForeignKey("dbo.AutoModels", "MakerID", "dbo.Makers");
            DropForeignKey("dbo.Makers", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoModels", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoInteriorColorID", "dbo.AutoInteriorColors");
            DropForeignKey("dbo.AutoInteriorColors", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoExteriorColorID", "dbo.AutoExteriorColors");
            DropForeignKey("dbo.AutoExteriorColors", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoEngineID", "dbo.AutoEngines");
            DropForeignKey("dbo.AutoEngines", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoDoorsID", "dbo.AutoDoors");
            DropForeignKey("dbo.AutoDoors", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoConditionID", "dbo.AutoConditions");
            DropForeignKey("dbo.AutoConditions", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.VehicleWizards", "AutoBodyStyleID", "dbo.AutoBodyStyles");
            DropForeignKey("dbo.VehicleWizards", "AutoAirBagID", "dbo.AutoAirBags");
            DropForeignKey("dbo.AutoBodyStyles", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.AutoAirBags", "LanguageID", "dbo.Languages");
            DropIndex("dbo.VIRPartConditionSeverityLevels", new[] { "VIRPartID" });
            DropIndex("dbo.VehicleVideos", new[] { "LanguageID" });
            DropIndex("dbo.VehicleVideos", new[] { "VehicleID" });
            DropIndex("dbo.VehicleTrims", new[] { "LanguageID" });
            DropIndex("dbo.VehicleTitleMappings", new[] { "LanguageID" });
            DropIndex("dbo.VehicleTitleMappings", new[] { "VehicleTitleID" });
            DropIndex("dbo.VehiclePartImages", new[] { "LanguageID" });
            DropIndex("dbo.VehiclePartImages", new[] { "VIRID" });
            DropIndex("dbo.VehiclePartImages", new[] { "VehicleID" });
            DropIndex("dbo.AutoModelMappings", new[] { "LanguageID" });
            DropIndex("dbo.AutoModelMappings", new[] { "AutoModelID" });
            DropIndex("dbo.VehicleTemplates", new[] { "LanguageID" });
            DropIndex("dbo.VehiclePrices", new[] { "VehicleWizard_VehicleID" });
            DropIndex("dbo.VehiclePrices", new[] { "LanguageID" });
            DropIndex("dbo.SubModelMappings", new[] { "LanguageID" });
            DropIndex("dbo.SubModelMappings", new[] { "SubModelID" });
            DropIndex("dbo.PostingSiteUsers", new[] { "PostingSiteID" });
            DropIndex("dbo.PostingFields", new[] { "PostingSiteID" });
            DropIndex("dbo.PostingDetails", new[] { "VehicleWizard_VehicleID" });
            DropIndex("dbo.PostingDetails", new[] { "PostingSiteUser_PostingSiteUserID" });
            DropIndex("dbo.PostingDetails", new[] { "LanguageID" });
            DropIndex("dbo.PostingDetails", new[] { "PostingSiteID" });
            DropIndex("dbo.PostingDetails", new[] { "PostingStatusID" });
            DropIndex("dbo.MotorizedTypes", new[] { "LanguageID" });
            DropIndex("dbo.Milages", new[] { "LanguageID" });
            DropIndex("dbo.MakerMappings", new[] { "LanguageID" });
            DropIndex("dbo.MakerMappings", new[] { "MakerId" });
            DropIndex("dbo.AutoTransmissionMappings", new[] { "AutoTransmission_AutoTransmissionID" });
            DropIndex("dbo.AutoTransmissionMappings", new[] { "LanguageID" });
            DropIndex("dbo.AutoGlobalizations", new[] { "LanguageID" });
            DropIndex("dbo.Years", new[] { "LanguageID" });
            DropIndex("dbo.VehicleImages", new[] { "LanguageID" });
            DropIndex("dbo.VehicleImages", new[] { "VehicleID" });
            DropIndex("dbo.VehclieTitles", new[] { "LanguageID" });
            DropIndex("dbo.UserRoles", new[] { "LanguageID" });
            DropIndex("dbo.Users", new[] { "LanguageID" });
            DropIndex("dbo.Users", new[] { "UserRoleID" });
            DropIndex("dbo.Upholsteries", new[] { "LanguageID" });
            DropIndex("dbo.RoofTypes", new[] { "LanguageID" });
            DropIndex("dbo.MediaPlayers", new[] { "LanguageID" });
            DropIndex("dbo.InventoryStatus", new[] { "LanguageID" });
            DropIndex("dbo.FuelTypes", new[] { "LanguageID" });
            DropIndex("dbo.EngineCapacities", new[] { "LanguageID" });
            DropIndex("dbo.DriveTypes", new[] { "LanguageID" });
            DropIndex("dbo.AutoUsedStatus", new[] { "LanguageID" });
            DropIndex("dbo.AutoTransmissions", new[] { "LanguageID" });
            DropIndex("dbo.AutoSteerings", new[] { "LanguageID" });
            DropIndex("dbo.SubModels", new[] { "LanguageID" });
            DropIndex("dbo.SubModels", new[] { "AutoModelID" });
            DropIndex("dbo.VehicleTypes", new[] { "LanguageID" });
            DropIndex("dbo.Makers", new[] { "VehicleTypeID" });
            DropIndex("dbo.Makers", new[] { "LanguageID" });
            DropIndex("dbo.AutoModels", new[] { "MakerID" });
            DropIndex("dbo.AutoModels", new[] { "LanguageID" });
            DropIndex("dbo.AutoInteriorColors", new[] { "LanguageID" });
            DropIndex("dbo.AutoExteriorColors", new[] { "LanguageID" });
            DropIndex("dbo.AutoEngines", new[] { "LanguageID" });
            DropIndex("dbo.AutoDoors", new[] { "LanguageID" });
            DropIndex("dbo.AutoConditions", new[] { "LanguageID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleTrim_VehicleTrimID" });
            DropIndex("dbo.VehicleWizards", new[] { "MotorizedType_MotorizedTypeID" });
            DropIndex("dbo.VehicleWizards", new[] { "Milage_MilageID" });
            DropIndex("dbo.VehicleWizards", new[] { "AutoUsedStatusID" });
            DropIndex("dbo.VehicleWizards", new[] { "LanguageID" });
            DropIndex("dbo.VehicleWizards", new[] { "VehicleAddressId" });
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
            DropIndex("dbo.AutoBodyStyles", new[] { "LanguageID" });
            DropIndex("dbo.AutoAirBags", new[] { "LanguageID" });
            DropTable("dbo.VIRPartConditionSeverityLevels");
            DropTable("dbo.VIRParts");
            DropTable("dbo.VIROptionProperties");
            DropTable("dbo.VIRFlagProperties");
            DropTable("dbo.VehicleVideos");
            DropTable("dbo.VehicleTrims");
            DropTable("dbo.VehicleTitleMappings");
            DropTable("dbo.VIRs");
            DropTable("dbo.VehiclePartImages");
            DropTable("dbo.PostingConfigurations");
            DropTable("dbo.AutoModelMappings");
            DropTable("dbo.AutoInventoryStatusHistories");
            DropTable("dbo.VehicleTemplates");
            DropTable("dbo.VehiclePrices");
            DropTable("dbo.SubModelMappings");
            DropTable("dbo.PostingStatus");
            DropTable("dbo.PostingSiteUsers");
            DropTable("dbo.PostingFields");
            DropTable("dbo.PostingSites");
            DropTable("dbo.PostingDetails");
            DropTable("dbo.MotorizedTypes");
            DropTable("dbo.Milages");
            DropTable("dbo.MakerMappings");
            DropTable("dbo.AutoTransmissionMappings");
            DropTable("dbo.AutoGlobalizations");
            DropTable("dbo.Years");
            DropTable("dbo.VehicleWheels");
            DropTable("dbo.VehicleTopStyles");
            DropTable("dbo.VehicleInteriorTypes");
            DropTable("dbo.VehicleImages");
            DropTable("dbo.VehicleAudios");
            DropTable("dbo.VehicleAddresses");
            DropTable("dbo.VehclieTitles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Upholsteries");
            DropTable("dbo.RoofTypes");
            DropTable("dbo.MediaPlayers");
            DropTable("dbo.InventoryStatus");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.EngineCapacities");
            DropTable("dbo.DriveTypes");
            DropTable("dbo.AutoUsedStatus");
            DropTable("dbo.AutoTransmissions");
            DropTable("dbo.AutoSteerings");
            DropTable("dbo.SubModels");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Makers");
            DropTable("dbo.AutoModels");
            DropTable("dbo.AutoInteriorColors");
            DropTable("dbo.AutoExteriorColors");
            DropTable("dbo.AutoEngines");
            DropTable("dbo.AutoDoors");
            DropTable("dbo.AutoConditions");
            DropTable("dbo.VehicleWizards");
            DropTable("dbo.AutoBodyStyles");
            DropTable("dbo.Languages");
            DropTable("dbo.AutoAirBags");
        }
    }
}
