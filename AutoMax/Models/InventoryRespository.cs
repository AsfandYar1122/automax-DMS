using AutoMax.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models
{
    public class InventoryRespository
    {
        private AutoMaxContext db = new AutoMaxContext();
        public ResultSetViewModel GetInventoryList()
        {
            try
            {
                var lst = (from data in db.VehicleWizards
                           select data
                               ).ToList();
                return new ResultSetViewModel(lst);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
        public ResultSetViewModel GetInventoryViewModelListWeb(bool isArabic)
        {
            try
            {
                string arabic = "";
                if (isArabic)
                    arabic = @"Arabic";
                //var sqlQuery = "SELECT        VehicleID,Has360,(SELECT AUUS.UsedStatus From AutoUsedStatus AUUS Where AUUS.AutoUsedStatusID= VZ.AutoUsedStatusID ) AS AutoUsedStatus,(SELECT VTS.Type FROM VehicleTopStyles VTS WHERE VTS.TopStyleID= VZ.VehicleTopStyleID) AS TopStyle,(SELECT VWL.Type from VehicleWheels VWL WHERE VWL.WheelID= VZ.VehicleWheelID) AS AutoWheel,(SELECT MLG.Value from Milages MLG WHERE MLG.MilageID= VZ.MilageID) AS Milage,(SELECT ASM.ModelName from SubModels ASM where ASM.SubModelID = VZ.SubModelID) SubModelName, (select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 1) AS PublishedOnHaraj,  (select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 2) AS PublishedOnOpenSouq,(SELECT VT.Title from VehclieTitles VT where VT.VehicleTitleID= VZ.VehicleTitleID) VehicleTitle,(SELECT VTP.Type from VehicleTypes VTP where VTP.VehicleTypeID= VZ.VehicleTypeID) VehicleType, " +
                var sqlQuery = "SELECT       HasDealerImages, VehicleID,Has360,(SELECT AUUS.UsedStatus From AutoUsedStatus AUUS Where AUUS.AutoUsedStatusID= VZ.AutoUsedStatusID ) AS AutoUsedStatus,(SELECT VTS.Type FROM VehicleTopStyles VTS WHERE VTS.TopStyleID= VZ.VehicleTopStyleID) AS TopStyle,(SELECT VWL.Type from VehicleWheels VWL WHERE VWL.WheelID= VZ.VehicleWheelID) AS AutoWheel,VZ.MilageValue AS Milage,(SELECT [___ARABIC___]ModelName from SubModels ASM where ASM.SubModelID = VZ.SubModelID) SubModelName, (select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 1 and PostingStatusID = 2) AS PublishedOnHaraj,  (select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 2 and PostingStatusID = 2) AS PublishedOnOpenSouq,(SELECT VT.Title from VehclieTitles VT where VT.VehicleTitleID= VZ.VehicleTitleID) VehicleTitle,(SELECT VTP.Type from VehicleTypes VTP where VTP.VehicleTypeID= VZ.VehicleTypeID) VehicleType, " +
             "(SELECT        Status" +
                              " FROM            InventoryStatus AS INS" +
                              " WHERE        (InventoryStatusID = VZ.InventoryStatusID)) AS InventoryStatus, StockNumber, MMCode, PlateNumber," +
                           " VIN," +
                            " (SELECT        [___ARABIC___]YearName" +
                             "  FROM            Years AS YR" +
                             "  WHERE        (YearID = VZ.YearID)) AS YearName," +
                            " (SELECT        [___ARABIC___]Name" +
                             "  FROM            Makers AS MK" +
                             "  WHERE        (MakerID = VZ.MakerID)) AS Maker," +
                            " (SELECT        [___ARABIC___]ModelName" +
                              " FROM            AutoModels AS AM" +
                             "  WHERE        (AutoModelID = VZ.AutoModelID)) AS AutoModelName," +
                            " [FreeText]," +
                            " (SELECT        [___ARABIC___]BodyStyle" +
                             "  FROM            AutoBodyStyles AS ABD" +
                              " WHERE        (AutoBodyStyleID = VZ.AutoBodyStyleID)) AS BodyStyle, Odometer,( SELECT AEC.ExteriorColor from AutoExteriorColors AEC where AEC.AutoExteriorColorID = VZ.AutoExteriorColorID) ExteriorColor , (SELECT AIC.InteriorColor from AutoInteriorColors AIC where AIC.AutoInteriorColorID = VZ.AutoInteriorColorID) InteriorColor, ( SELECT AST.Steering from AutoSteerings AST where AST.AutoSteeringID = VZ.AutoSteeringID) AutoSteering,(SELECT AD.Doors from AutoDoors AD where  AD.AutoDoorsID= VZ.AutoDoorsID) AutoDoor,(SELECT AE.EngineName from AutoEngines AE Where AE.AutoEngineID=VZ.AutoEngineID) EngineName, (SELECT ATS.Transmission from AutoTransmissions ATS where ATS.AutoTransmissionID= VZ.AutoTransmissionID)AutoTransmission,(SELECT FT.Type from FuelTypes FT where FT.FuelTypeID= VZ.FuelTypeID) FuelType, " +
                        "(SELECT DT.DriveTypeV from DriveTypes DT where DT.DriveTypeID= VZ.DriveTypeID) DriveType,TotalRatting, VIRCompletenessPercentage,CreatedDate, (SELECT ACD.Condition from AutoConditions ACD where ACD.AutoConditionID= VZ.AutoConditionID) AutoCondition, VehiclePrice, WarantyText, Description, UpdateDate,(SELECT US.FirstName + ' '+ US.LastName from Users US where US.UserID = VZ.UserID) OwnerName, (SELECT AAB.Value from AutoAirBags AAB where AAB.AutoAirBagID= VZ.AutoAirBagID) AutoAirBag, (SELECT EC.Capacity from EngineCapacities EC where EC.EngineCapacityID = VZ.EngineCapacityID) EngineCapacity , VZ.IsFeatured, (SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 1) ImageName" +
" FROM  VehicleWizards AS VZ WHERE (VZ.VIN IS NOT NULL AND VZ.Odometer IS NOT NULL AND  VZ.AutoModelID IS NOT NULL AND VZ.MakerID IS NOT NULL)AND ( VZ.IsDeleted = 0 OR VZ.IsDeleted IS NULL )";
                sqlQuery = sqlQuery.Replace("[___ARABIC___]", arabic);
                var vList = db.Database.SqlQuery<AutoMax.Models.DataModel.VehicleViewModel>(sqlQuery).ToList();
                return new ResultSetViewModel(vList);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
        public ResultSetViewModel GetInventoryViewModelDetail(long VehilceID, bool isArabic = false)
        {
            try
            {
                string arabic = "";
                if (isArabic)
                    arabic = @"Arabic";

                var sqlQuery = "SELECT     VehicleOptions,HasDealerImages, VehicleID,Has360,(SELECT AUUS.UsedStatus From AutoUsedStatus AUUS Where AUUS.AutoUsedStatusID= VZ.AutoUsedStatusID ) AS AutoUsedStatus,(SELECT VTS.Type FROM VehicleTopStyles VTS WHERE VTS.TopStyleID= VZ.VehicleTopStyleID) AS TopStyle,(SELECT VWL.Type  from VehicleWheels VWL WHERE VWL.WheelID= VZ.VehicleWheelID) AS AutoWheel,VZ.MilageValue AS Milage,(SELECT [___ARABIC___]ModelName from SubModels ASM where ASM.SubModelID = VZ.SubModelID) SubModelName, (select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 1 and PostingStatusID = 2) AS PublishedOnHaraj,  (select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 2 and PostingStatusID = 2) AS PublishedOnOpenSouq,(SELECT [___ARABIC___]Title from VehclieTitles VT where VT.VehicleTitleID= VZ.VehicleTitleID) VehicleTitle,(SELECT VTP.Type from VehicleTypes VTP where VTP.VehicleTypeID= VZ.VehicleTypeID) VehicleType, " +
              "(SELECT        Status" +
               " FROM            InventoryStatus AS INS" +
               " WHERE        (InventoryStatusID = VZ.InventoryStatusID)) AS InventoryStatus, StockNumber, MMCode, PlateNumber," +
            " VIN," +
             " (SELECT        [___ARABIC___]YearName" +
              "  FROM            Years AS YR" +
              "  WHERE        (YearID = VZ.YearID)) AS YearName," +

              " (SELECT        [___ARABIC___]Type" +
              "  FROM            RoofTypes AS RTypes" +
              "  WHERE        (RoofTypeID = VZ.RoofTypeID)) AS RoofTypeName," +

               " (SELECT        [___ARABIC___]Name" +
              "  FROM            Upholsteries AS Upsteries" +
              "  WHERE        (UpholsteryID = VZ.UpholsteryID)) AS UpholsteryName," +

              " (SELECT        [___ARABIC___]Type" +
              "  FROM            VehicleAudios AS VAudio" +
              "  WHERE        (AudioID = VZ.VehicleAudioID)) AS VehicleAudio," +
             " (SELECT        [___ARABIC___]Name" +
              "  FROM            Makers AS MK" +
              "  WHERE        (MakerID = VZ.MakerID)) AS Maker," +
             " (SELECT        [___ARABIC___]ModelName" +
               " FROM            AutoModels AS AM" +
              "  WHERE        (AutoModelID = VZ.AutoModelID)) AS AutoModelName," +
             " [FreeText]," +
             " (SELECT        [___ARABIC___]BodyStyle" +
              "  FROM            AutoBodyStyles AS ABD" +
               " WHERE        (AutoBodyStyleID = VZ.AutoBodyStyleID)) AS BodyStyle, Odometer,( SELECT [___ARABIC___]ExteriorColor from AutoExteriorColors AEC where AEC.AutoExteriorColorID = VZ.AutoExteriorColorID) ExteriorColor , (SELECT [___ARABIC___]InteriorColor from AutoInteriorColors AIC where AIC.AutoInteriorColorID = VZ.AutoInteriorColorID) InteriorColor, ( SELECT AST.Steering from AutoSteerings AST where AST.AutoSteeringID = VZ.AutoSteeringID) AutoSteering,(SELECT [___ARABIC___]Doors from AutoDoors AD where  AD.AutoDoorsID= VZ.AutoDoorsID) AutoDoor,(SELECT [___ARABIC___]EngineName from AutoEngines AE Where AE.AutoEngineID=VZ.AutoEngineID) EngineName, (SELECT [___ARABIC___]Transmission from AutoTransmissions ATS where ATS.AutoTransmissionID= VZ.AutoTransmissionID)AutoTransmission,(SELECT [___ARABIC___]Type from FuelTypes FT where FT.FuelTypeID= VZ.FuelTypeID) FuelType, " +
         "(SELECT [___ARABIC___]DriveTypeV from DriveTypes DT where DT.DriveTypeID= VZ.DriveTypeID) DriveType,TotalRatting, VIRCompletenessPercentage,CreatedDate, (SELECT [___ARABIC___]Condition from AutoConditions ACD where ACD.AutoConditionID= VZ.AutoConditionID) AutoCondition, VehiclePrice, WarantyText, Description, UpdateDate,(SELECT US.FirstName + ' '+ US.LastName from Users US where US.UserID = VZ.UserID) OwnerName, (SELECT AAB.Value from AutoAirBags AAB where AAB.AutoAirBagID= VZ.AutoAirBagID) AutoAirBag, (SELECT EC.Capacity from EngineCapacities EC where EC.EngineCapacityID = VZ.EngineCapacityID) EngineCapacity , VZ.IsFeatured, (SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 1) ImageName, (SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 2) ImageName2" +
 " FROM  VehicleWizards AS VZ WHERE (VZ.VIN IS NOT NULL AND VZ.Odometer IS NOT NULL AND  VZ.AutoModelID IS NOT NULL AND VZ.MakerID IS NOT NULL)AND ( VZ.IsDeleted = 0 OR VZ.IsDeleted IS NULL ) AND (VZ.VehicleID=" + VehilceID + ")";

                sqlQuery = sqlQuery.Replace("[___ARABIC___]", arabic);
                var objVehicles = db.Database.SqlQuery<AutoMax.Models.DataModel.VehicleViewModel>(sqlQuery).FirstOrDefault();

                if (!string.IsNullOrEmpty(objVehicles.VehicleOptions))
                {
                    try
                    {
                        var lstIDs = objVehicles.VehicleOptions.Split(',').Where(a => !string.IsNullOrEmpty(a)).Select(a => Convert.ToInt32(a)).ToList();
                        var lst = db.VIROptionProperties.Where(a => lstIDs.Contains(a.Id)).Select(a => a.Name).ToList();
                        if (lst != null && lst.Count > 0)
                        {
                            objVehicles.Options = string.Join(", ", lst);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                return new ResultSetViewModel(objVehicles);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
        public ResultSetViewModel GetInventoryStatusVM(bool isArabic)
        {
            return GetVEhiclesForWebsite(isArabic, "INVENTORY");
        }

        public List<VehicleType> GetVehicleType(int status)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.VehicleTypeID != null).Select(a => a.VehicleTypeID).Distinct().ToList();
            var lstResults = db.VehicleTypes.Where(a => lst.Contains(a.VehicleTypeID)).ToList();
            return lstResults;
        }

        public List<Maker> GetMakers(int status, int vehicleTypeId)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.MakerID != null && a.VehicleTypeID == vehicleTypeId && a.IsDeleted != true).Select(a => a.MakerID).Distinct().ToList();
            var lstResults = db.Makers.Where(a => lst.Contains(a.MakerID)).ToList();
            return lstResults;
        }

        public List<AutoModel> GetModels(int status, int vehicleTypeId, int makerId)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.AutoModelID != null && a.VehicleTypeID == vehicleTypeId && a.MakerID == makerId && a.IsDeleted != true).Select(a => a.AutoModelID).Distinct().ToList();
            var lstResults = db.AutoModels.Where(a => lst.Contains(a.AutoModelID)).ToList();
            return lstResults;
        }

        public List<SubModel> GetSubModels(int status, int vehicleTypeId, int makerId, int modelId)
        {
            var lst = db.VehicleWizards.Where(a => (a.InventoryStatusID == status || status == -1) && a.SubModelID != null && a.VehicleTypeID == vehicleTypeId && a.MakerID == makerId && a.AutoModelID == modelId && a.IsDeleted != true).Select(a => a.SubModelID).Distinct().ToList();
            var lstResults = db.SubModels.Where(a => lst.Contains(a.SubModelID)).ToList();
            return lstResults;
        }


        private ResultSetViewModel GetVEhiclesForWebsite(bool isArabic, string status)
        {
            try
            {
                string arabic = "";
                if (isArabic)
                    arabic = @"Arabic";

                var sqlQuery = @"SELECT
	VehicleID,HasDealerImages,
(
SELECT [___ARABIC___]ModelName from SubModels ASM where ASM.SubModelID = VZ.SubModelID 
) as SubModelName,
	Has360,
	(
		SELECT
			AUUS.UsedStatus
		FROM
			AutoUsedStatus AUUS
		WHERE
			AUUS.AutoUsedStatusID = VZ.AutoUsedStatusID
	) AS AutoUsedStatus,
(
		SELECT
			va.Name
		FROM
			VehicleAddresses va
		WHERE
			va.Id = VZ.VehicleAddressId
	) AS VehicleAddress,
	(
		SELECT
			VTS.Type
		FROM
			VehicleTopStyles VTS
		WHERE
			VTS.TopStyleID = VZ.VehicleTopStyleID
	) AS TopStyle,
	(
		SELECT
			VWL.Type
		FROM
			VehicleWheels VWL
		WHERE
			VWL.WheelID = VZ.VehicleWheelID
	) AS AutoWheel,
	VZ.MilageValue AS Milage,
	(
		SELECT
			VT.Title
		FROM
			VehclieTitles VT
		WHERE
			VT.VehicleTitleID = VZ.VehicleTitleID
	) VehicleTitle,
	(
		SELECT
			[___ARABIC___]Type
		FROM
			VehicleTypes VTP
		WHERE
			VTP.VehicleTypeID = VZ.VehicleTypeID
	) VehicleType,
	ISSS.Status AS InventoryStatus,
	StockNumber,
	MMCode,
	PlateNumber,
	VIN,
	(
		SELECT
			[___ARABIC___]YearName
		FROM
			Years AS YR
		WHERE
			(YearID = VZ.YearID)
	) AS YearName,
	(
		SELECT
			[___ARABIC___]Name
		FROM
			Makers AS MK
		WHERE
			(MakerID = VZ.MakerID)
	) AS Maker,
	(
		SELECT
			[___ARABIC___]ModelName
		FROM
			AutoModels AS AM
		WHERE
			(AutoModelID = VZ.AutoModelID)
	) AS AutoModelName,
	[FreeText],
	(
		SELECT
			BodyStyle
		FROM
			AutoBodyStyles AS ABD
		WHERE
			(
				AutoBodyStyleID = VZ.AutoBodyStyleID
			)
	) AS BodyStyle,
	Odometer,
	(
		SELECT
			[___ARABIC___]ExteriorColor
		FROM
			AutoExteriorColors AEC
		WHERE
			AEC.AutoExteriorColorID = VZ.AutoExteriorColorID
	) ExteriorColor,
	(
		SELECT
			[___ARABIC___]InteriorColor
		FROM
			AutoInteriorColors AIC
		WHERE
			AIC.AutoInteriorColorID = VZ.AutoInteriorColorID
	) InteriorColor,
	(
		SELECT
			AST.Steering
		FROM
			AutoSteerings AST
		WHERE
			AST.AutoSteeringID = VZ.AutoSteeringID
	) AutoSteering,
	(
		SELECT
			AD.Doors
		FROM
			AutoDoors AD
		WHERE
			AD.AutoDoorsID = VZ.AutoDoorsID
	) AutoDoor,
	(
		SELECT
			AE.EngineName
		FROM
			AutoEngines AE
		WHERE
			AE.AutoEngineID = VZ.AutoEngineID
	) EngineName,
	(
		SELECT
			[___ARABIC___]Transmission
		FROM
			AutoTransmissions ATS
		WHERE
			ATS.AutoTransmissionID = VZ.AutoTransmissionID
	) AutoTransmission,
	(
		SELECT
			FT.Type
		FROM
			FuelTypes FT
		WHERE
			FT.FuelTypeID = VZ.FuelTypeID
	) FuelType,
	(
		SELECT
			DT.DriveTypeV
		FROM
			DriveTypes DT
		WHERE
			DT.DriveTypeID = VZ.DriveTypeID
	) DriveType,
	TotalRatting,
	VIRCompletenessPercentage,
	VZ.CreatedDate,
	(
		SELECT
			ACD.Condition
		FROM
			AutoConditions ACD
		WHERE
			ACD.AutoConditionID = VZ.AutoConditionID
	) AutoCondition,
	VehiclePrice,
	WarantyText,
	VZ.Description,
	UpdateDate,
	(
		SELECT
			US.FirstName + ' ' + US.LastName
		FROM
			Users US
		WHERE
			US.UserID = VZ.UserID
	) OwnerName,
	(
		SELECT
			AAB.
		VALUE

		FROM
			AutoAirBags AAB
		WHERE
			AAB.AutoAirBagID = VZ.AutoAirBagID
	) AutoAirBag,
	(
		SELECT
			EC.Capacity
		FROM
			EngineCapacities EC
		WHERE
			EC.EngineCapacityID = VZ.EngineCapacityID
	) EngineCapacity,
	VZ.IsFeatured,
	(
		SELECT
			TOP (1) VI.ImagePath
		FROM
			VehicleImages VI
		WHERE
			VI.VehicleID = VZ.VehicleID
		AND VI.ImagePath IS NOT NULL
		AND VI.DisplayOrder = 1
	) ImageName,
(SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 2) ImageName2
FROM
	VehicleWizards AS VZ
INNER JOIN InventoryStatus ISSS ON ISSS.InventoryStatusID = VZ.InventoryStatusID
WHERE
	(
		VZ.VIN IS NOT NULL		
		AND VZ.Odometer IS NOT NULL
		AND VZ.AutoModelID IS NOT NULL
		AND VZ.MakerID IS NOT NULL
	)
AND (
	VZ.IsDeleted = 0
	OR VZ.IsDeleted IS NULL
)
AND (
	LOWER (ISSS.Status) = LOWER ('[__INVENTORY_STATUS__]')
)";
                sqlQuery = sqlQuery.Replace("[___ARABIC___]", arabic);
                sqlQuery = sqlQuery.Replace("[__INVENTORY_STATUS__]", status);

                var vList = db.Database.SqlQuery<AutoMax.Models.DataModel.VehicleViewModel>(sqlQuery).ToList();
                return new ResultSetViewModel(vList);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel GetInventoryStatusVMWholeSale(bool isArabic)
        {
            return GetVEhiclesForWebsite(isArabic, "WHOLESALE");
        }


        public ResultSetViewModel GetFeaturedInventoryViewModelList()
        {
            try
            {
                var sqlQuery = "SELECT       HasDealerImages, VehicleID,Has360,(SELECT AUUS.UsedStatus From AutoUsedStatus AUUS Where AUUS.AutoUsedStatusID= VZ.AutoUsedStatusID ) AS AutoUsedStatus,(SELECT VTS.Type FROM VehicleTopStyles VTS WHERE VTS.TopStyleID= VZ.VehicleTopStyleID) AS TopStyle,(SELECT VWL.Type from VehicleWheels VWL WHERE VWL.WheelID= VZ.VehicleWheelID) AS AutoWheel,VZ.MilageValue AS Milage,(SELECT VT.Title from VehclieTitles VT where VT.VehicleTitleID= VZ.VehicleTitleID) VehicleTitle,(SELECT VTP.Type from VehicleTypes VTP where VTP.VehicleTypeID= VZ.VehicleTypeID) VehicleType, " +
                             "(SELECT        Status" +
                              " FROM            InventoryStatus AS INS" +
                              " WHERE        (InventoryStatusID = VZ.InventoryStatusID)) AS InventoryStatus, StockNumber, MMCode, PlateNumber," +
                           " VIN," +
                            " (SELECT        YearName" +
                             "  FROM            Years AS YR" +
                             "  WHERE        (YearID = VZ.YearID)) AS YearName," +
                            " (SELECT        Name" +
                             "  FROM            Makers AS MK" +
                             "  WHERE        (MakerID = VZ.MakerID)) AS Maker," +
                            " (SELECT        ModelName" +
                              " FROM            AutoModels AS AM" +
                             "  WHERE        (AutoModelID = VZ.AutoModelID)) AS AutoModelName," +
                            " [FreeText]," +
                            " (SELECT        BodyStyle" +
                             "  FROM            AutoBodyStyles AS ABD" +
                              " WHERE        (AutoBodyStyleID = VZ.AutoBodyStyleID)) AS BodyStyle, Odometer,( SELECT AEC.ExteriorColor from AutoExteriorColors AEC where AEC.AutoExteriorColorID = VZ.AutoExteriorColorID) ExteriorColor , (SELECT AIC.InteriorColor from AutoInteriorColors AIC where AIC.AutoInteriorColorID = VZ.AutoInteriorColorID) InteriorColor, ( SELECT AST.Steering from AutoSteerings AST where AST.AutoSteeringID = VZ.AutoSteeringID) AutoSteering,(SELECT AD.Doors from AutoDoors AD where  AD.AutoDoorsID= VZ.AutoDoorsID) AutoDoor,(SELECT AE.EngineName from AutoEngines AE Where AE.AutoEngineID=VZ.AutoEngineID) EngineName, (SELECT ATS.Transmission from AutoTransmissions ATS where ATS.AutoTransmissionID= VZ.AutoTransmissionID)AutoTransmission,(SELECT FT.Type from FuelTypes FT where FT.FuelTypeID= VZ.FuelTypeID) FuelType, " +
                        "(SELECT DT.DriveTypeV from DriveTypes DT where DT.DriveTypeID= VZ.DriveTypeID) DriveType,TotalRatting, VIRCompletenessPercentage, (SELECT ACD.Condition from AutoConditions ACD where ACD.AutoConditionID= VZ.AutoConditionID) AutoCondition, VehiclePrice, WarantyText, UpdateDate,(SELECT US.FirstName + ' '+ US.LastName from Users US where US.UserID = VZ.UserID) OwnerName, (SELECT AAB.Value from AutoAirBags AAB where AAB.AutoAirBagID= VZ.AutoAirBagID) AutoAirBag, (SELECT EC.Capacity from EngineCapacities EC where EC.EngineCapacityID = VZ.EngineCapacityID) EngineCapacity , VZ.IsFeatured, (SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 1) ImageName,(SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 2) ImageName2" +
" FROM  VehicleWizards AS VZ INNER JOIN InventoryStatus ISSS ON ISSS.InventoryStatusID = VZ.InventoryStatusID WHERE (VZ.VIN IS NOT NULL AND VZ.Odometer IS NOT NULL AND  VZ.AutoModelID IS NOT NULL AND VZ.MakerID IS NOT NULL)AND ( VZ.IsDeleted = 0 OR VZ.IsDeleted IS NULL ) AND (VZ.IsFeatured=1) AND (LOWER(ISSS.Status) = LOWER('Inventory'))";
                var vList = db.Database.SqlQuery<AutoMax.Models.DataModel.VehicleViewModel>(sqlQuery).ToList();
                return new ResultSetViewModel(vList);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
        public ResultSetViewModel GetFeaturedInventoryViewModelById(long? VehicleID)
        {
            try
            {
                var sqlQuery = "SELECT       HasDealerImages, VehicleID,Has360,(SELECT AUUS.UsedStatus From AutoUsedStatus AUUS Where AUUS.AutoUsedStatusID= VZ.AutoUsedStatusID ) AS AutoUsedStatus,(SELECT VTS.Type FROM VehicleTopStyles VTS WHERE VTS.TopStyleID= VZ.VehicleTopStyleID) AS TopStyle,(SELECT VWL.Type from VehicleWheels VWL WHERE VWL.WheelID= VZ.VehicleWheelID) AS AutoWheel,VZ.MilageValue AS Milage,(SELECT VT.Title from VehclieTitles VT where VT.VehicleTitleID= VZ.VehicleTitleID) VehicleTitle,(SELECT VTP.Type from VehicleTypes VTP where VTP.VehicleTypeID= VZ.VehicleTypeID) VehicleType, " +
                             "(SELECT        Status" +
                              " FROM            InventoryStatus AS INS" +
                              " WHERE        (InventoryStatusID = VZ.InventoryStatusID)) AS InventoryStatus, StockNumber, MMCode, PlateNumber," +
                           " VIN," +
                            " (SELECT        YearName" +
                             "  FROM            Years AS YR" +
                             "  WHERE        (YearID = VZ.YearID)) AS YearName," +
                            " (SELECT        Name" +
                             "  FROM            Makers AS MK" +
                             "  WHERE        (MakerID = VZ.MakerID)) AS Maker," +
                            " (SELECT        ModelName" +
                              " FROM            AutoModels AS AM" +
                             "  WHERE        (AutoModelID = VZ.AutoModelID)) AS AutoModelName," +
                            " [FreeText]," +
                            " (SELECT        BodyStyle" +
                             "  FROM            AutoBodyStyles AS ABD" +
                              " WHERE        (AutoBodyStyleID = VZ.AutoBodyStyleID)) AS BodyStyle, Odometer,( SELECT AEC.ExteriorColor from AutoExteriorColors AEC where AEC.AutoExteriorColorID = VZ.AutoExteriorColorID) ExteriorColor , (SELECT AIC.InteriorColor from AutoInteriorColors AIC where AIC.AutoInteriorColorID = VZ.AutoInteriorColorID) InteriorColor, ( SELECT AST.Steering from AutoSteerings AST where AST.AutoSteeringID = VZ.AutoSteeringID) AutoSteering,(SELECT AD.Doors from AutoDoors AD where  AD.AutoDoorsID= VZ.AutoDoorsID) AutoDoor,(SELECT AE.EngineName from AutoEngines AE Where AE.AutoEngineID=VZ.AutoEngineID) EngineName, (SELECT ATS.Transmission from AutoTransmissions ATS where ATS.AutoTransmissionID= VZ.AutoTransmissionID)AutoTransmission,(SELECT FT.Type from FuelTypes FT where FT.FuelTypeID= VZ.FuelTypeID) FuelType, " +
                        "(SELECT DT.DriveTypeV from DriveTypes DT where DT.DriveTypeID= VZ.DriveTypeID) DriveType,TotalRatting, VIRCompletenessPercentage,CreatedDate, (SELECT ACD.Condition from AutoConditions ACD where ACD.AutoConditionID= VZ.AutoConditionID) AutoCondition, VehiclePrice, WarantyText, Description, UpdateDate,(SELECT US.FirstName + ' '+ US.LastName from Users US where US.UserID = VZ.UserID) OwnerName, (SELECT AAB.Value from AutoAirBags AAB where AAB.AutoAirBagID= VZ.AutoAirBagID) AutoAirBag, (SELECT EC.Capacity from EngineCapacities EC where EC.EngineCapacityID = VZ.EngineCapacityID) EngineCapacity , VZ.IsFeatured, (SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 1) ImageName" +
" FROM  VehicleWizards AS VZ WHERE (VZ.VIN IS NOT NULL AND VZ.Odometer IS NOT NULL AND  VZ.AutoModelID IS NOT NULL AND VZ.MakerID IS NOT NULL)AND ( VZ.IsDeleted = 0 OR VZ.IsDeleted IS NULL ) AND (VZ.IsFeatured=1) AND (VZ.VehicleID=" + VehicleID + ")";
                if (VehicleID != null)
                {
                    var vList = db.Database.SqlQuery<AutoMax.Models.DataModel.VehicleViewModel>(sqlQuery).ToList();
                    return new ResultSetViewModel(vList);
                }
                else
                {
                    return new ResultSetViewModel(null);
                }
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
        public ResultSetViewModel GetInventoryViewModelList(int? VehicleTypeID = null, int? VehicleTitleID = null, int? MakerID = null, string VIN = null,
            string SearchAny = null, int? automodelName = null, int? subModelName = null, long? UserID = null, int? StatusID = null, int? IsFeatured = null, int? HasDealerImages = null, bool isArabic = false,
            string sortingColumnName = "", bool isASC = false)
        {
            try
            {
                string arabic = "";
                if (isArabic)
                    arabic = @"Arabic";

                string VehicleType = VehicleTypeID == null ? "NULL" : VehicleTypeID.ToString();
                string VehicleTitle = VehicleTitleID == null ? "NULL" : VehicleTitleID.ToString();
                string UserIDValue = UserID == null ? "NULL" : UserID.ToString();
                string Maker = MakerID == null ? "NULL" : MakerID.ToString();
                string AutoModel = automodelName == null ? "NULL" : automodelName.ToString();
                string SubModel = subModelName == null ? "NULL" : subModelName.ToString();
                string Status = StatusID == null ? "NULL" : StatusID.ToString();
                string Featured = IsFeatured == null ? "NULL" : IsFeatured.ToString();
                string DealerImages = HasDealerImages == null ? "NULL" : HasDealerImages.ToString();
                var sqlQuery = "SELECT       IsFacebook,HasDealerImages, VehicleID,Has360,(SELECT AUUS.UsedStatus From AutoUsedStatus AUUS Where AUUS.AutoUsedStatusID= VZ.AutoUsedStatusID ) AS AutoUsedStatus,(SELECT VTS.Type FROM VehicleTopStyles VTS WHERE VTS.TopStyleID= VZ.VehicleTopStyleID) AS TopStyle,(SELECT VIS.Status FROM InventoryStatus VIS WHERE VIS.InventoryStatusID = VZ.InventoryStatusID) AS Status,(SELECT VWL.Type from VehicleWheels VWL WHERE VWL.WheelID= VZ.VehicleWheelID) AS AutoWheel,VZ.MilageValue AS Milage,(SELECT ASM.[___ARABIC___]ModelName from SubModels ASM where ASM.SubModelID = VZ.SubModelID) SubModelName,(select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 1 and PostingStatusID = 2) AS PublishedOnHaraj,  (select COUNT(*) from postingdetails where vehiclewizardid = VZ.VehicleID and postingsiteid = 2 and PostingStatusID = 2) AS PublishedOnOpenSouq,(SELECT VT.Title from VehclieTitles VT where VT.VehicleTitleID= VZ.VehicleTitleID) VehicleTitle,(SELECT VTP.Type from VehicleTypes VTP where VTP.VehicleTypeID= VZ.VehicleTypeID) VehicleType, " +
                             "(SELECT        Status" +
                              " FROM            InventoryStatus AS INS" +
                              " WHERE        (InventoryStatusID = VZ.InventoryStatusID)) AS InventoryStatus, StockNumber, MMCode, PlateNumber," +
                           " VIN," +
                            " (SELECT        [___ARABIC___]YearName" +
                             "  FROM            Years AS YR" +
                             "  WHERE        (YearID = VZ.YearID)) AS YearName," +
                            " (SELECT        [___ARABIC___]Name" +
                             "  FROM            Makers AS MK" +
                             "  WHERE        (MakerID = VZ.MakerID)) AS Maker," +
                            " (SELECT        [___ARABIC___]ModelName" +
                              " FROM            AutoModels AS AM" +
                             "  WHERE        (AutoModelID = VZ.AutoModelID)) AS AutoModelName," +
                            " [FreeText]," +
                            " (SELECT        [___ARABIC___]BodyStyle" +
                             "  FROM            AutoBodyStyles AS ABD" +
                              " WHERE        (AutoBodyStyleID = VZ.AutoBodyStyleID)) AS BodyStyle, Odometer,( SELECT AEC.ExteriorColor from AutoExteriorColors AEC where AEC.AutoExteriorColorID = VZ.AutoExteriorColorID) ExteriorColor , (SELECT AIC.InteriorColor from AutoInteriorColors AIC where AIC.AutoInteriorColorID = VZ.AutoInteriorColorID) InteriorColor, ( SELECT AST.Steering from AutoSteerings AST where AST.AutoSteeringID = VZ.AutoSteeringID) AutoSteering,(SELECT AD.Doors from AutoDoors AD where  AD.AutoDoorsID= VZ.AutoDoorsID) AutoDoor,(SELECT AE.EngineName from AutoEngines AE Where AE.AutoEngineID=VZ.AutoEngineID) EngineName, (SELECT ATS.Transmission from AutoTransmissions ATS where ATS.AutoTransmissionID= VZ.AutoTransmissionID)AutoTransmission,(SELECT FT.Type from FuelTypes FT where FT.FuelTypeID= VZ.FuelTypeID) FuelType, " +
                        "(SELECT DT.DriveTypeV from DriveTypes DT where DT.DriveTypeID= VZ.DriveTypeID) DriveType,TotalRatting,VIRCompletenessPercentage, CreatedDate, (SELECT ACD.Condition from AutoConditions ACD where ACD.AutoConditionID= VZ.AutoConditionID) AutoCondition, VehiclePrice, WarantyText, Description, UpdateDate,(SELECT US.FirstName + ' '+ US.LastName from Users US where US.UserID = VZ.UserID) OwnerName, (SELECT AAB.Value from AutoAirBags AAB where AAB.AutoAirBagID= VZ.AutoAirBagID) AutoAirBag, (SELECT EC.Capacity from EngineCapacities EC where EC.EngineCapacityID = VZ.EngineCapacityID) EngineCapacity , VZ.IsFeatured, (SELECT TOP(1) VI.ImagePath from VehicleImages VI where VI.VehicleID = VZ.VehicleID AND VI.ImagePath IS NOT NULL AND VI.DisplayOrder = 1) ImageName, '' as ImageName2" +
" FROM  VehicleWizards AS VZ" +
            " WHERE (VZ.VIN IS NOT NULL AND VZ.Odometer IS NOT NULL AND  VZ.AutoModelID IS NOT NULL AND VZ.MakerID IS NOT NULL) AND ( VZ.IsDeleted = 0 OR VZ.IsDeleted IS NULL ) AND (VZ.VehicleTypeID= " + VehicleType + " OR " + VehicleType + " IS NULL) AND (VZ.VehicleTitleID=" + VehicleTitle + " OR " + VehicleTitle + " IS NULL) AND (VZ.AutoModelID=" + AutoModel + " OR " + AutoModel + " IS NULL) AND (VZ.SubModelID=" + SubModel + " OR " + SubModel + " IS NULL) AND (VZ.InventoryStatusID=" + Status + " OR " + Status + " IS NULL)  AND (VZ.MakerID=" + Maker + " OR " + Maker + " IS NULL) AND (VZ.UserID=" + UserIDValue + " OR " + UserIDValue + " IS NULL)";
                if (!string.IsNullOrEmpty(VIN))
                {
                    sqlQuery += "AND (VZ.VIN Like '%" + VIN + "%')";
                }
                if (IsFeatured != -1)
                {
                    sqlQuery += "AND (VZ.IsFeatured=" + Featured + " OR " + Featured + " IS NULL)";
                }
                if (HasDealerImages != -1)
                {
                    sqlQuery += "AND (VZ.HasDealerImages=" + DealerImages + " OR " + DealerImages + " IS NULL)";
                }
                sqlQuery += " ORDER BY CreatedDate DESC";
                sqlQuery = sqlQuery.Replace("[___ARABIC___]", arabic);
                var vList = db.Database.SqlQuery<AutoMax.Models.DataModel.VehicleViewModel>(sqlQuery).ToList();
                if (!string.IsNullOrEmpty(SearchAny))
                {
                    vList = vList.Where(d => d.VIN.Contains(SearchAny) || (d.Maker.Contains(SearchAny) || (d.PlateNumber.Contains(SearchAny)) || (d.AutoModelName.Contains(SearchAny)) || (d.VehicleTitle.Contains(SearchAny)) || (d.Odometer.Contains(SearchAny)) || (d.VehiclePrice.ToString().Contains(SearchAny)))).OrderByDescending(d => d.VehicleID).ToList();
                }

                foreach (var item in vList)
                {

                    var infoOpenSouq = db.PostingDetail.Include("PostingSiteUser").FirstOrDefault(x => x.VehicleWizardId == item.VehicleID && x.PostingSiteID == 1); // 1 is for OpenSouq
                    var infoOpenSouqDetail = (object)null;
                    if (infoOpenSouq != null)
                        infoOpenSouqDetail = db.PostingStatus.Where(x => x.PostingStatusID == infoOpenSouq.PostingStatusID).Select(y => y.StatusName).FirstOrDefault();
                    infoOpenSouqDetail = (infoOpenSouqDetail == null ? "" : infoOpenSouqDetail).ToString();
                    if (infoOpenSouq != null && infoOpenSouq.PostingSiteUser != null && infoOpenSouqDetail.Equals("Posted"))
                    {
                        item.OpenSouqID = infoOpenSouq.PostingSiteUser.Username;
                    }
                    var infoHaraj = db.PostingDetail.Include("PostingSiteUser").FirstOrDefault(x => x.VehicleWizardId == item.VehicleID && x.PostingSiteID == 2); // 2 is for HARAJ 
                    var infoHarajDetail = (object)null;
                    if (infoHaraj != null)
                        infoHarajDetail = db.PostingStatus.Where(x => x.PostingStatusID == infoHaraj.PostingStatusID).Select(y => y.StatusName).FirstOrDefault();
                    infoHarajDetail = (infoHarajDetail == null ? "" : infoHarajDetail).ToString();

                    if (infoHaraj != null && infoHaraj.PostingSiteUser != null && infoHarajDetail.Equals("Posted"))
                    {
                        item.HarajID = infoHaraj.PostingSiteUser.Username;
                    }

                }

                vList = this.ApplySortingToInventoryList(vList, sortingColumnName, isASC);
                return new ResultSetViewModel(vList);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
        public ResultSetViewModel GetInventoryDropDownList()
        {
            AutoMax.Models.DataModel.InventoryDDLs model = new AutoMax.Models.DataModel.InventoryDDLs();
            model.AutoAirBags = db.AutoAirBags.ToList();
            model.AutoEngines = db.AutoEngines.ToList();
            model.AutoDoor = db.AutoDoors.ToList();
            model.AutoTransmissions = db.AutoTransmissions.ToList();
            model.AutoModel = db.AutoModels.Select(d => new AutoMax.Models.DataModel.AutoModelVM
            {
                AutoModelID = d.AutoModelID,
                CreatedBy = d.CreatedBy,
                CreatedDate = d.CreatedDate,
                ModelName = d.ModelName,
                UpdatedBy = d.UpdatedBy,
                UpdatedDate = d.UpdatedDate,
                LanguageID = d.LanguageID
            }).ToList();
            model.SubModels = db.SubModels.Select(d => new AutoMax.Models.DataModel.SubModelVM
            {
                SubModelID = d.SubModelID,
                AutoModelID = d.AutoModelID,
                CreatedBy = d.CreatedBy,
                CreatedDate = d.CreatedDate,
                ModelName = d.ModelName,
                UpdatedBy = d.UpdatedBy,
                UpdatedDate = d.UpdatedDate,
                LanguageID = d.LanguageID
            }).ToList();
            model.AutoConditions = db.AutoConditions.ToList();
            model.AutoAirBags = db.AutoAirBags.ToList();
            model.AutoBodyStyles = db.AutoBodyStyles.ToList();
            model.AutoExteriorColors = db.AutoExteriorColors.ToList();
            model.AutoInteriorColors = db.AutoInteriorColors.ToList();
            model.AutoSteerings = db.AutoSteerings.ToList();
            model.DriveTypes = db.DriveTypes.ToList();
            model.EngineCapacities = db.EngineCapacities.ToList();
            model.FuelTypes = db.FuelTypes.ToList();
            model.Makers = db.Makers.Select(d =>
               new AutoMax.Models.DataModel.MakerVM
               {
                   MakerID = d.MakerID,
                   Name = d.Name,
                   CreatedBy = d.CreatedBy,
                   UpdatedBy = d.UpdatedBy,
                   CreatedDate = d.CreatedDate,
                   UpdatedDate = d.UpdatedDate,
                   LanguageID = d.LanguageID,
                   VehicleTypeID = d.VehicleTypeID
               }
               ).ToList() == null ? new List<AutoMax.Models.DataModel.MakerVM>() : db.Makers.Select(d =>
               new AutoMax.Models.DataModel.MakerVM
               {
                   MakerID = d.MakerID,
                   Name = d.Name,
                   CreatedBy = d.CreatedBy,
                   UpdatedBy = d.UpdatedBy,
                   CreatedDate = d.CreatedDate,
                   UpdatedDate = d.UpdatedDate,
                   LanguageID = d.LanguageID,
                   VehicleTypeID = d.VehicleTypeID
               }
               ).ToList();
            model.InventoryStatus = db.InventoryStatus.ToList();
            model.MediaPlayers = db.MediaPlayers.ToList();
            model.RoofTypes = db.RoofTypes.ToList();
            model.Upholsteries = db.Upholsteries.ToList();
            model.VehclieTitles = db.VehclieTitles.ToList();
            model.VehicleTypes = db.VehicleTypes.ToList();
            model.Years = db.Years.ToList();
            return new ResultSetViewModel(model);
        }
        public ResultSetViewModel GetVehicleTypes()
        {
            IQueryable<VehicleType> types = db.VehicleTypes;
            return new ResultSetViewModel(types);
        }
        public ResultSetViewModel GetVehicleTypeById(int? VehicleTypeID)
        {
            IQueryable<VehicleType> types = db.VehicleTypes;
            if (VehicleTypeID != null && VehicleTypeID.Value > 0)
            {
                types = types.Where(d => d.VehicleTypeID == VehicleTypeID);
                return new ResultSetViewModel(types);
            }
            return new ResultSetViewModel(null);
        }
        /// <summary>
        /// Sorting Inventory List
        /// </summary>
        public List<AutoMax.Models.DataModel.VehicleViewModel> ApplySortingToInventoryList(List<AutoMax.Models.DataModel.VehicleViewModel> source, string sortingColumn, bool isASC)
        {
            // default settings : show last created record on top
            if (String.IsNullOrEmpty(sortingColumn))
            {
                //Sort the cars by Status as follows 1. Pending 2. Inventory 3. Sold
                var lstPending = source.Where(a => a.InventoryStatus == AutoMax.Utility.Constants.INVENTORYSTATUS.PENDING).ToList();
                var lstInventory = source.Where(a => a.InventoryStatus == AutoMax.Utility.Constants.INVENTORYSTATUS.INVENTORY).ToList();
                var lstSold = source.Where(a => a.InventoryStatus == AutoMax.Utility.Constants.INVENTORYSTATUS.SOLD).ToList();

                var lst = new List<AutoMax.Models.DataModel.VehicleViewModel>();
                lst.AddRange(lstPending);
                lst.AddRange(lstInventory);
                lst.AddRange(lstSold);

                return lst;
            }

            switch (sortingColumn)
            {
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.VIN:
                    source = isASC ? source.OrderBy(x => x.VIN).ToList() : source.OrderByDescending(x => x.VIN).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.AutoModelName:
                    source = isASC ? source.OrderBy(x => x.AutoModelName).ToList() : source.OrderByDescending(x => x.AutoModelName).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.InventoryStatus:
                    source = isASC ? source.OrderBy(x => x.InventoryStatus).ToList() : source.OrderByDescending(x => x.InventoryStatus).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.Maker:
                    source = isASC ? source.OrderBy(x => x.Maker).ToList() : source.OrderByDescending(x => x.Maker).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.Odometer:
                    source = isASC ? source.OrderBy(x => x.Odometer).ToList() : source.OrderByDescending(x => x.Odometer).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.PlateNumber:
                    source = isASC ? source.OrderBy(x => x.PlateNumber).ToList() : source.OrderByDescending(x => x.PlateNumber).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.SubModelName:
                    source = isASC ? source.OrderBy(x => x.SubModelName).ToList() : source.OrderByDescending(x => x.SubModelName).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.VehiclePrice:
                    source = isASC ? source.OrderBy(x => x.VehiclePrice).ToList() : source.OrderByDescending(x => x.VehiclePrice).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.VehicleTitle:
                    source = isASC ? source.OrderBy(x => x.VehicleTitle).ToList() : source.OrderByDescending(x => x.VehicleTitle).ToList();
                    break;
                case AutoMax.Utility.Constants.INVENTORYSORTINGCOLUMNS.CreatedDate:
                    source = isASC ? source.OrderBy(x => x.CreatedDate).ToList() : source.OrderByDescending(x => x.CreatedDate).ToList();
                    break;
            }
            return source;
        }
    }
}