using AutoMax.Models;
using AutoMax.Models.Entities;
//using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AutoMax.Controllers.Api
{
    public class VehicleModel
    {
        public int SNo { get; set; }
        public string Purchasedate { get; set; }
        public string SaleDate { get; set; }
        public string Branch { get; set; }
        public string Supplier { get; set; }
        public string VoucherNo { get; internal set; }
        public string Vehicle { get; internal set; }
        public string ChassisNumber { get; internal set; }
        public string PlateNumber { get; internal set; }
        public string Mileage { get; internal set; }
        public string Colour { get; internal set; }
        public string YearOfModel { get; internal set; }
        public string Quantity { get; internal set; }
        public string PurchaseNetAmount { get; internal set; }
        public string SalesGrossAmount { get; internal set; }
        public string ProfitAndLoss { get; internal set; }
        public string MarginPercentage { get; internal set; }
        public string SalesDiscount { get; internal set; }
        public string SalesCharges { get; internal set; }
        public string PurchaseVoucherNo { get; internal set; }
        public string PurchaseQuantity { get; internal set; }
        public string PartyAccount { get; internal set; }
    }

    public class VehicleVIRViewModel
    {
        public long VehicleID { get; set; }
        public VirViewModel VIR { get; set; }
        public double? EvaluatorExteriorRatting { get; set; }
        public double? EvaluatorInteriorRatting { get; set; }
        public double? EvaluatorMechanicsRatting { get; set; }
        public double? EvaluatorFrameRatting { get; set; }
        public double? ExteriorRatting { get; set; }
        public double? InteriorRatting { get; set; }
        public double? MechanicsRatting { get; set; }
        public double? FrameRatting { get; set; }
        public double? TotalRatting { get; set; }
    }

    public class HoleSaleVehicleViewModel
    {
        public long VehicleID { get; set; }
        public VirViewModel VIR { get; set; }
        public List<VehicleImage> Images { get; set; }
        public List<VehicleVideoViewModel> Videos { get; set; }
        public string UsedStatus { get; set; }
        public string Milages { get; set; }
        public string VehicleTrim { get; set; }
        public string MotorizedType { get; set; }
        public string VehicleAddress { get; set; }
        public string MediaPlayerName { get; set; }
        public string VehicleWheel { get; set; }
        public string VehicleTopStyle { get; set; }
        public string VehicleInteriorType { get; set; }
        public string VehicleAudio { get; set; }
        public string VehicleType { get; set; }
        public string VehclieTitle { get; set; }
        public string RoofType { get; set; }
        public string Upholsterie { get; set; }
        public string EngineCapacity { get; set; }
        public int? AutoAirBag { get; set; }
        public string DriveType { get; set; }
        public string FuelType { get; set; }
        public string AutoTransmission { get; set; }
        public string AutoEngine { get; set; }
        public string AutoDoor { get; set; }
        public string AutoSteering { get; set; }
        public string InteriorColor { get; set; }
        public string ExteriorColor { get; set; }
        public string AutoBodyStyle { get; set; }
        public string SubModelsName { get; set; }
        public string ModelName { get; set; }
        public string MakerName { get; set; }
        public string ArabicCondition { get; set; }
        public string YearName { get; set; }
        public string ArabicDescription { get; set; }
        public string ArabicFreeText { get; set; }
        public string ArabicWarantyText { get; set; }
        public string Branch { get; set; }
        public string VehicleDescription { get; set; }
        public double? EvaluatorExteriorRatting { get; set; }
        public double? EvaluatorInteriorRatting { get; set; }
        public double? EvaluatorMechanicsRatting { get; set; }
        public double? EvaluatorFrameRatting { get; set; }
        public double? ExteriorRatting { get; set; }
        public double? InteriorRatting { get; set; }
        public double? MechanicsRatting { get; set; }
        public double? FrameRatting { get; set; }
        public double? TotalRatting { get; set; }
        public string VehicleFreeText { get; set; }
        public string Location { get; set; }
        public Nullable<bool> Has360 { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        public Nullable<decimal> PurchasingCost { get; set; }
        public string MilageValue { get; set; }
        public string MMCode { get; set; }
        public string Odometer { get; set; }
        public string PlateNumber { get; set; }
        public string StockNumber { get; set; }
        public string VIN { get; set; }
        public string WarantyText { get; set; }
    }

    public class VehicleController : ApiController
    {
        private AutoMaxContext db = new AutoMaxContext();
        public ResultSetViewModel GetWholeSale(string email, string password, int pageNumber, int pageSize)
        {
            password = EncrypterDecrypter.Encrypt(password);
            User user = db.Users.Where(d => d.Email == email && d.Password == password).FirstOrDefault();
            if (user == null)
            {
                return new ResultSetViewModel(new Exception("Invalid credentials, please try again."));
            }

            try
            {
                var sqlQuery = string.Format(@"select 
AutoUsedStatus.UsedStatus,
Milages.[Value] as Milages,
VehicleTrims.[Trim] as VehicleTrim,
MotorizedTypes.Type as MotorizedType,
VehicleAddresses.Name as VehicleAddress,
MediaPlayers.PlayerName as MediaPlayerName,
VehicleWheels.Type as VehicleWheel,
VehicleTopStyles.Type as VehicleTopStyle,
VehicleInteriorTypes.Type as VehicleInteriorType,
VehicleAudios.Type as VehicleAudio,
VehicleTypes.Type as VehicleType,
VehclieTitles.Title as VehclieTitle,
RoofTypes.Type as RoofType,
Upholsteries.Name as Upholsterie,
EngineCapacities.Capacity as EngineCapacity,
AutoAirBags.[Value] as AutoAirBag,
DriveTypes.DriveTypeV as DriveType,
FuelTypes.Type as FuelType,
AutoTransmissions.Transmission as AutoTransmission,
AutoEngines.EngineName as AutoEngine,
AutoDoors.Doors as AutoDoor,
AutoSteerings.Steering as AutoSteering,
AutoInteriorColors.InteriorColor,
AutoExteriorColors.ExteriorColor,
AutoBodyStyles.BodyStyle as AutoBodyStyle,
SubModels.ModelName as SubModelsName,
AutoModels.ModelName, 
Makers.Name as MakerName, 
AutoConditions.ArabicCondition, 
Years.YearName, 
VehicleWizards.VehicleID,
VehicleWizards.ArabicDescription,
VehicleWizards.ArabicFreeText,
VehicleWizards.ArabicWarantyText,
VehicleWizards.Branch,
VehicleWizards.Description as VehicleDescription,
VehicleWizards.EvaluatorExteriorRatting,
VehicleWizards.EvaluatorFrameRatting,
VehicleWizards.EvaluatorInteriorRatting,
VehicleWizards.EvaluatorMechanicsRatting,
VehicleWizards.ExteriorRatting,
VehicleWizards.FrameRatting,
VehicleWizards.[FreeText] as VehicleFreeText,
VehicleWizards.Location,
VehicleWizards.InteriorRatting,
VehicleWizards.Has360,
VehicleWizards.IsFeatured,
VehicleWizards.MechanicsRatting,
VehicleWizards.MilageValue,
VehicleWizards.MMCode,
VehicleWizards.Odometer,
VehicleWizards.PlateNumber,
VehicleWizards.PurchasingCost,
VehicleWizards.StockNumber,
VehicleWizards.TotalRatting,
VehicleWizards.VIN,
VehicleWizards.WarantyText

from VehicleWizards
LEFT JOIN AutoConditions on AutoConditions.AutoConditionID = VehicleWizards.AutoConditionID
LEFT JOIN Years on Years.YearID = VehicleWizards.YearID
LEFT JOIN Makers on Makers.MakerID = VehicleWizards.MakerID
LEFT JOIN AutoModels on AutoModels.AutoModelID = VehicleWizards.AutoModelID
LEFT JOIN SubModels on SubModels.SubModelID = VehicleWizards.SubModelID
LEFT JOIN AutoBodyStyles on AutoBodyStyles.AutoBodyStyleID = VehicleWizards.AutoBodyStyleID
LEFT JOIN AutoInteriorColors on AutoInteriorColors.AutoInteriorColorID = VehicleWizards.AutoInteriorColorID
LEFT JOIN AutoExteriorColors on AutoExteriorColors.AutoExteriorColorID = VehicleWizards.AutoExteriorColorID
LEFT JOIN AutoUsedStatus on AutoUsedStatus.AutoUsedStatusID = VehicleWizards.AutoUsedStatusID
LEFT JOIN Milages on Milages.MilageID = VehicleWizards.Milage_MilageID
LEFT JOIN VehicleTrims on VehicleTrims.VehicleTrimID = VehicleWizards.VehicleTrim_VehicleTrimID
LEFT JOIN MotorizedTypes on MotorizedTypes.MotorizedTypeID = VehicleWizards.MotorizedType_MotorizedTypeID
LEFT JOIN VehicleAddresses on VehicleAddresses.Id = VehicleWizards.VehicleAddressId
LEFT JOIN MediaPlayers on MediaPlayers.MediaPlayerID = VehicleWizards.MediaPlayerID
LEFT JOIN VehicleWheels on VehicleWheels.WheelID = VehicleWizards.VehicleWheelID
LEFT JOIN VehicleTopStyles on VehicleTopStyles.TopStyleID = VehicleWizards.VehicleTopStyleID
LEFT JOIN VehicleInteriorTypes on VehicleInteriorTypes.InteriorTypeID = VehicleWizards.VehicleInteriorTypeID
LEFT JOIN VehicleAudios on VehicleAudios.AudioID = VehicleWizards.VehicleAudioID
LEFT JOIN VehicleTypes on VehicleTypes.VehicleTypeID = VehicleWizards.VehicleTypeID
LEFT JOIN VehclieTitles on VehclieTitles.VehicleTitleID = VehicleWizards.VehicleTitleID
LEFT JOIN RoofTypes on RoofTypes.RoofTypeID = VehicleWizards.RoofTypeID
LEFT JOIN Upholsteries on Upholsteries.UpholsteryID = VehicleWizards.UpholsteryID
LEFT JOIN EngineCapacities on EngineCapacities.EngineCapacityID = VehicleWizards.EngineCapacityID
LEFT JOIN AutoAirBags on AutoAirBags.AutoAirBagID = VehicleWizards.AutoAirBagID
LEFT JOIN DriveTypes on DriveTypes.DriveTypeID = VehicleWizards.DriveTypeID
LEFT JOIN FuelTypes on FuelTypes.FuelTypeID = VehicleWizards.FuelTypeID
LEFT JOIN AutoTransmissions on AutoTransmissions.AutoTransmissionID = VehicleWizards.AutoTransmissionID
LEFT JOIN AutoEngines on AutoEngines.AutoEngineID = VehicleWizards.AutoEngineID
LEFT JOIN AutoDoors on AutoDoors.AutoDoorsID = VehicleWizards.AutoDoorsID
LEFT JOIN AutoSteerings on AutoSteerings.AutoSteeringID = VehicleWizards.AutoSteeringID

where InventoryStatusID = 5
ORDER BY VehicleID
OFFSET {1} * ({0} - 1) ROWS
FETCH NEXT {1} ROWS ONLY;", pageNumber, pageSize);

                var lst = db.Database.SqlQuery<HoleSaleVehicleViewModel>(sqlQuery).ToList();
                var repository = new VIRRepository();
                foreach (var vehicle in lst)
                {
                    vehicle.Images = repository.LoadVehicleImages(vehicle.VehicleID, "VehicleAttachments/").Data as List<VehicleImage>;
                    vehicle.Images = (from data in vehicle.Images
                                      select new VehicleImage
                                      {
                                          VehicleImageID = data.VehicleImageID,
                                          ImagePath = data.ImagePath
                                      }).ToList();

                    vehicle.Videos = repository.LoadVehicleVideos(vehicle.VehicleID).Data as List<VehicleVideoViewModel>;
                    vehicle.Videos = (from data in vehicle.Videos
                                      select new VehicleVideoViewModel
                                      {
                                          VehicleVideoID = data.VehicleVideoID,
                                          VideoPath = data.VideoPath
                                      }).ToList();

                    var exteriorRatting = repository.GetVIR(vehicle.VehicleID, VIRPartType.EXTERIOR);
                    var interiorRatting = repository.GetVIR(vehicle.VehicleID, VIRPartType.INTERIOR);
                    var frameRatting = repository.GetVIR(vehicle.VehicleID, VIRPartType.FRAME);
                    var mechanicsRatting = repository.GetVIR(vehicle.VehicleID, VIRPartType.MECHANICS);
                    vehicle.VIR = new VirViewModel
                    {
                        Exterior = new ExteriorViewModel
                        {
                            FrontBumperId = exteriorRatting.Data.FrontBumperId,
                            FrontBumperData = exteriorRatting.Data.FrontBumperData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.FrontBumperData),
                            GrillId = exteriorRatting.Data.GrillId,
                            GrillData = exteriorRatting.Data.GrillData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.GrillData),
                            HeadlightId = exteriorRatting.Data.HeadLightId,
                            HeadlightData = exteriorRatting.Data.HeadLightData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.HeadLightData),
                            HoodId = exteriorRatting.Data.HoodId,
                            HoodData = exteriorRatting.Data.HoodData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.HoodData),
                            LeftFenderId = exteriorRatting.Data.LeftFenderId,
                            LeftFenderData = exteriorRatting.Data.LeftFenderData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LeftFenderData),
                            RightBedSideId = exteriorRatting.Data.RightBedSideId,
                            RightBedSideData = exteriorRatting.Data.RightBedSideData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightBedSideData),
                            LMUDGuardId = exteriorRatting.Data.LMUDGUARDId,
                            LMUDGuardData = exteriorRatting.Data.LMUDGUARDData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LMUDGUARDData),
                            RightFenderId = exteriorRatting.Data.RightFenderId,
                            RightFenderData = exteriorRatting.Data.RightFenderData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightFenderData),
                            RMudGuardId = exteriorRatting.Data.RMudGuardId,
                            RMudGuardData = exteriorRatting.Data.RMudGuardData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RMudGuardData),
                            WIPERSId = exteriorRatting.Data.WIPERSId,
                            WIPERSData = exteriorRatting.Data.WIPERSData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.WIPERSData),
                            WindshieldId = exteriorRatting.Data.RMudGuardId,
                            WindshieldData = exteriorRatting.Data.WindshieldData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.WindshieldData),
                            LeftMirrorId = exteriorRatting.Data.RMudGuardId,
                            LeftMirrorData = exteriorRatting.Data.WindshieldData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.WindshieldData),
                            RightMirrorId = exteriorRatting.Data.RMudGuardId,
                            RightMirrorData = exteriorRatting.Data.RightMirrorData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightMirrorData),
                            LFDoorId = exteriorRatting.Data.LFDoorId,
                            LFDoorData = exteriorRatting.Data.LFDoorData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LFDoorData),
                            RFDoorId = exteriorRatting.Data.LFDoorId,
                            RFDoorData = exteriorRatting.Data.RFDoorData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RFDoorData),
                            LRockerPanelId = exteriorRatting.Data.LRockerPanelId,
                            LRockerPanelData = exteriorRatting.Data.LRockerPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LRockerPanelData),
                            RoofId = exteriorRatting.Data.LRockerPanelId,
                            RoofData = exteriorRatting.Data.RoofData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RoofData),
                            RearWindowId = exteriorRatting.Data.LRockerPanelId,
                            RearWindowData = exteriorRatting.Data.RearWindowData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RearWindowData),
                            RRockerPanelId = exteriorRatting.Data.LRockerPanelId,
                            RRockerPanelData = exteriorRatting.Data.RRockerPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RRockerPanelData),
                            LRdoorId = exteriorRatting.Data.LRockerPanelId,
                            LRdoorData = exteriorRatting.Data.LRdoorData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LRdoorData),
                            RRDoorId = exteriorRatting.Data.LRockerPanelId,
                            RRDoorData = exteriorRatting.Data.RRDoorData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RRDoorData),
                            AnteenaId = exteriorRatting.Data.AnteenaId,
                            AnteenaData = exteriorRatting.Data.AnteenaData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.AnteenaData),
                            BackScreenId = exteriorRatting.Data.BackScreenId,
                            BackScreenData = exteriorRatting.Data.BackScreenData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.BackScreenData),
                            LeftQuarterPanelId = exteriorRatting.Data.LeftQuarterPanelId,
                            LeftQuarterPanelData = exteriorRatting.Data.LeftQuarterPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LeftQuarterPanelData),
                            TRUNKCARGOId = exteriorRatting.Data.TRUNKCARGOId,
                            TRUNKCARGOData = exteriorRatting.Data.TRUNKCARGOData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.TRUNKCARGOData),
                            RightQuarterPanelId = exteriorRatting.Data.RightQuarterPanelId,
                            RightQuarterPanelData = exteriorRatting.Data.RightQuarterPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightQuarterPanelData),
                            RREARLIGHTId = exteriorRatting.Data.RREARLIGHTId,
                            RREARLIGHTData = exteriorRatting.Data.RREARLIGHTData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RREARLIGHTData),
                            TAILERHITCHId = exteriorRatting.Data.TAILERHITCHId,
                            TAILERHITCHData = exteriorRatting.Data.TAILERHITCHData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.TAILERHITCHData),
                            REARBUMPERId = exteriorRatting.Data.REARBUMPERId,
                            REARBUMPERData = exteriorRatting.Data.REARBUMPERData == null ? new PartsDataViewModel(vehicle.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.REARBUMPERData),
                            Ratting = Convert.ToDouble(exteriorRatting.Data.Ratting),
                            EvaluatorRatting = exteriorRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(exteriorRatting.Data.EvaluatorRatting),
                        },
                        Interior = new InteriorViewModel
                        {
                            RearViewMirrorId = interiorRatting.Data.RearViewMirrorId,
                            RearViewMirrorData = interiorRatting.Data.RearViewMirrorData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RearViewMirrorData),
                            GaugesId = interiorRatting.Data.GaugesId,
                            GaugesData = interiorRatting.Data.GaugesData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.GaugesData),
                            AirBagId = interiorRatting.Data.AirBagId,
                            AirBagData = interiorRatting.Data.AirBagData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.AirBagData),
                            ShiftKnobId = interiorRatting.Data.ShiftKnobId,
                            ShiftKnobData = interiorRatting.Data.ShiftKnobData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ShiftKnobData),
                            LFDoorPanelId = interiorRatting.Data.LFDoorPanelId,
                            LFDoorPanelData = interiorRatting.Data.LFDoorPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LFDoorPanelData),
                            RHFRTSeatId = interiorRatting.Data.RHFRTSeatId,
                            RHFRTSeatData = interiorRatting.Data.RHFRTSeatData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RHFRTSeatData),
                            LHFRTSeatId = interiorRatting.Data.LHFRTSeatId,
                            LHFRTSeatData = interiorRatting.Data.LHFRTSeatData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LHFRTSeatData),
                            FrCarpetId = interiorRatting.Data.LHFRTSeatId,
                            FrCarpetData = interiorRatting.Data.LHFRTSeatData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LHFRTSeatData),
                            LRDoorPanelId = interiorRatting.Data.LRDoorPanelId,
                            LRDoorPanelData = interiorRatting.Data.LRDoorPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LRDoorPanelData),
                            RrSeatsId = interiorRatting.Data.RRSeatId,
                            RrSeatsData = interiorRatting.Data.RRSeatData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRSeatData),
                            HeadLinerId = interiorRatting.Data.HeadLinerId,
                            HeadLinerData = interiorRatting.Data.HeadLinerData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.HeadLinerData),
                            RRDoorPanelId = interiorRatting.Data.RRDoorPanelId,
                            RRDoorPanelData = interiorRatting.Data.RRDoorPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRDoorPanelData),
                            LampId = interiorRatting.Data.LampId,
                            LampData = interiorRatting.Data.LampData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LampData),
                            RFDoorPanelId = interiorRatting.Data.RFDoorPanelId,
                            RFDoorPanelData = interiorRatting.Data.RFDoorPanelData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RFDoorPanelData),
                            RadioId = interiorRatting.Data.RadioId,
                            RadioData = interiorRatting.Data.RadioData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RadioData),
                            ConsoleId = interiorRatting.Data.ConsoleId,
                            ConsoleData = interiorRatting.Data.ConsoleData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ConsoleData),
                            GloveBoxId = interiorRatting.Data.GloveBoxId,
                            GloveBoxData = interiorRatting.Data.GloveBoxData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.GloveBoxData),
                            DashId = interiorRatting.Data.DashId,
                            DashData = interiorRatting.Data.DashData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.DashData),
                            ManualsId = interiorRatting.Data.ManualsId,
                            ManualsData = interiorRatting.Data.ManualsData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ManualsData),
                            LRCarpetId = interiorRatting.Data.LRCarpetId,
                            LRCarpetData = interiorRatting.Data.LRCarpetData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LRCarpetData),
                            InteriorPartsId = interiorRatting.Data.InteriorPartsId,
                            InteriorPartsData = interiorRatting.Data.InteriorPartsData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.InteriorPartsData),
                            FeaturesId = interiorRatting.Data.FeaturesId,
                            FeaturesData = interiorRatting.Data.FeaturesData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.FeaturesData),
                            FourthRowSeatId = interiorRatting.Data.FourthRowSeatId,
                            FourthRowSeatData = interiorRatting.Data.FourthRowSeatData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.FourthRowSeatData),
                            OdorId = interiorRatting.Data.OdorId,
                            OdorData = interiorRatting.Data.OdorData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.OdorData),
                            RearArmrestId = interiorRatting.Data.RearArmrestId,
                            RearArmrestData = interiorRatting.Data.RearArmrestData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RearArmrestData),
                            RRCarpetId = interiorRatting.Data.RRCarpetId,
                            RRCarpetData = interiorRatting.Data.RRCarpetData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRCarpetData),
                            ThirdRowSeatId = interiorRatting.Data.ThirdRowSeatId,
                            ThirdRowSeatData = interiorRatting.Data.ThirdRowSeatData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ThirdRowSeatData),
                            RRSeatsLeftId = interiorRatting.Data.RRSeatsLeftId,
                            RRSeatsLeftData = interiorRatting.Data.RRSeatsLeftData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRSeatsLeftData),
                            RRSeatsRightId = interiorRatting.Data.RRSeatsRightId,
                            RRSeatsRightData = interiorRatting.Data.RRSeatsRightData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRSeatsRightData),
                            SteeringWheelId = interiorRatting.Data.SteeringWheelId,
                            SteeringWheelData = interiorRatting.Data.SteeringWheelData == null ? new PartsDataViewModel(vehicle.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.SteeringWheelData),
                            Ratting = Convert.ToDouble(interiorRatting.Data.Ratting),
                            EvaluatorRatting = interiorRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(interiorRatting.Data.EvaluatorRatting),
                        },
                        Mechanics = new MechanicsViewModel
                        {
                            PowerSteeringId = mechanicsRatting.Data.PowerSteeringId,
                            PowerSteeringData = mechanicsRatting.Data.PowerSteeringData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.PowerSteeringData),
                            ClimateControlId = mechanicsRatting.Data.ClimateControlId,
                            ClimateControlData = mechanicsRatting.Data.ClimateControlData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ClimateControlData),
                            FrontShockId = mechanicsRatting.Data.FrontShockId,
                            FrontShockData = mechanicsRatting.Data.FrontShockData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FrontShockData),
                            FrontAxleId = mechanicsRatting.Data.FrontAxleId,
                            FrontAxleData = mechanicsRatting.Data.FrontAxleData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FrontAxleData),
                            LFWheelId = mechanicsRatting.Data.LFWheelId,
                            LFWheelData = mechanicsRatting.Data.LFWheelData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LFWheelData),
                            TransmissionId = mechanicsRatting.Data.TransmissionId,
                            TransmissionData = mechanicsRatting.Data.TransmissionData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.TransmissionData),
                            BatteryId = mechanicsRatting.Data.BatteryId,
                            BatteryData = mechanicsRatting.Data.BatteryData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.BatteryData),
                            RearShocksId = mechanicsRatting.Data.RearShocksId,
                            RearShocksData = mechanicsRatting.Data.RearShocksData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RearShocksData),
                            RearAxleId = mechanicsRatting.Data.RearAxleId,
                            RearAxleData = mechanicsRatting.Data.RearAxleData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RearAxleData),
                            LRWheelId = mechanicsRatting.Data.LRWheelId,
                            LRWheelData = mechanicsRatting.Data.LRWheelData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LRWheelData),
                            ExhaustId = mechanicsRatting.Data.ExhaustId,
                            ExhaustData = mechanicsRatting.Data.ExhaustData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ExhaustData),
                            LRWinMechanicsId = mechanicsRatting.Data.LRWinMechanicsId,
                            LRWinMechanicsData = mechanicsRatting.Data.LRWinMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LRWinMechanicsData),
                            LFWinMechanicsId = mechanicsRatting.Data.LFWinMechanicsId,
                            LFWinMechanicsData = mechanicsRatting.Data.LFWinMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LFWinMechanicsData),
                            LFDoorMechanicsId = mechanicsRatting.Data.LFDoorMechanicsId,
                            LFDoorMechanicsData = mechanicsRatting.Data.LFDoorMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LFDoorMechanicsData),
                            LRDoorMechanicsId = mechanicsRatting.Data.LRDoorMechanicsId,
                            LRDoorMechanicsData = mechanicsRatting.Data.LRDoorMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LRDoorMechanicsData),
                            RRDoorMechanicsId = mechanicsRatting.Data.RRDoorMechanicsId,
                            RRDoorMechanicsData = mechanicsRatting.Data.RRDoorMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RRDoorMechanicsData),
                            RFDoorMechanicsId = mechanicsRatting.Data.RFDoorMechanicsId,
                            RFDoorMechanicsData = mechanicsRatting.Data.RFDoorMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RFDoorMechanicsData),

                            RFWinMechanicsId = mechanicsRatting.Data.RFWinMechanicsId,
                            RFWinMechanicsData = mechanicsRatting.Data.RFWinMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RFWinMechanicsData),
                            RRWinMechanicsId = mechanicsRatting.Data.RRWinMechanicsId,
                            RRWinMechanicsData = mechanicsRatting.Data.RRWinMechanicsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RRWinMechanicsData),
                            EmissionId = mechanicsRatting.Data.EmissionId,
                            EmissionData = mechanicsRatting.Data.EmissionData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.EmissionData),
                            RearBreakId = mechanicsRatting.Data.RearBreakId,
                            RearBreakData = mechanicsRatting.Data.RearBreakData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RearBreakData),
                            RRWheelId = mechanicsRatting.Data.RRWheelId,
                            RRWheelData = mechanicsRatting.Data.RRWheelData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RRWheelData),
                            ClutchId = mechanicsRatting.Data.ClutchId,
                            ClutchData = mechanicsRatting.Data.ClutchData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ClutchData),

                            FrontBreakId = mechanicsRatting.Data.FrontBreakId,
                            FrontBreakData = mechanicsRatting.Data.FrontBreakData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FrontBreakData),
                            RFWheelId = mechanicsRatting.Data.RFWheelId,
                            RFWheelData = mechanicsRatting.Data.RFWheelData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RFWheelData),
                            EngineId = mechanicsRatting.Data.EngineId,
                            EngineData = mechanicsRatting.Data.EngineData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.EngineData),
                            ElectricsId = mechanicsRatting.Data.ElectricsId,
                            ElectricsData = mechanicsRatting.Data.ElectricsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ElectricsData),
                            SpareTypeId = mechanicsRatting.Data.SpareTypeId,
                            SpareTypeData = mechanicsRatting.Data.SpareTypeData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.SpareTypeData),
                            FuelTankId = mechanicsRatting.Data.FuelTankId,
                            FuelTankData = mechanicsRatting.Data.FuelTankData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FuelTankData),

                            WarningLightsId = mechanicsRatting.Data.WarningLightsId,
                            WarningLightsData = mechanicsRatting.Data.WarningLightsData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.WarningLightsData),
                            ToolsJacksId = mechanicsRatting.Data.ToolsJacksId,
                            ToolsJacksData = mechanicsRatting.Data.ToolsJacksData == null ? new PartsDataViewModel(vehicle.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ToolsJacksData),
                            Ratting = Convert.ToDouble(mechanicsRatting.Data.Ratting),
                            EvaluatorRatting = mechanicsRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(mechanicsRatting.Data.EvaluatorRatting),
                        },
                        Frame = new FrameViewModel
                        {
                            Ratting = Convert.ToDouble(frameRatting.Data.Ratting),
                            CowlPanelFirewallData = frameRatting.Data.CowlPanelFirewallData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.CowlPanelFirewallData),
                            CowlPanelFirewallId = frameRatting.Data.CowlPanelFirewallId,
                            LeftAPillarData = frameRatting.Data.LeftAPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftAPillarData),
                            LeftAPillarId = frameRatting.Data.LeftAPillarId,
                            LeftApronData = frameRatting.Data.LeftApronData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftApronData),
                            LeftApronId = frameRatting.Data.LeftApronId,
                            LeftBPillarData = frameRatting.Data.LeftBPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftBPillarData),
                            LeftBPillarId = frameRatting.Data.LeftBPillarId,
                            LeftCPillarData = frameRatting.Data.LeftCPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftCPillarData),
                            LeftCPillarId = frameRatting.Data.LeftCPillarId,
                            LeftDPillarData = frameRatting.Data.LeftDPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftDPillarData),
                            LeftDPillarId = frameRatting.Data.LeftDPillarId,
                            LeftFrontRailData = frameRatting.Data.LeftFrontRailData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftFrontRailData),
                            LeftFrontRailId = frameRatting.Data.LeftFrontRailId,
                            LeftRearLockPillarData = frameRatting.Data.LeftRearLockPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftRearLockPillarData),
                            LeftRearLockPillarId = frameRatting.Data.LeftRearLockPillarId,
                            LeftRearRailData = frameRatting.Data.LeftRearRailData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftRearRailData),
                            LeftRearRailId = frameRatting.Data.LeftRearRailId,
                            LeftStrutTowerApronData = frameRatting.Data.LeftStrutTowerApronData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftStrutTowerApronData),
                            LeftStrutTowerApronId = frameRatting.Data.LeftStrutTowerApronId,
                            PerimeterFrameData = frameRatting.Data.PerimeterFrameData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.PerimeterFrameData),
                            PerimeterFrameId = frameRatting.Data.PerimeterFrameId,
                            RadiatorCoreSupportData = frameRatting.Data.RadiatorCoreSupportData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RadiatorCoreSupportData),
                            RadiatorCoreSupportId = frameRatting.Data.RadiatorCoreSupportId,
                            RightAPillarData = frameRatting.Data.RightAPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightAPillarData),
                            RightAPillarId = frameRatting.Data.RightAPillarId,
                            RightApronData = frameRatting.Data.RightApronData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightApronData),
                            RightApronId = frameRatting.Data.RightApronId,
                            RightBPillarData = frameRatting.Data.RightBPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightBPillarData),
                            RightBPillarId = frameRatting.Data.RightBPillarId,
                            RightCPillarData = frameRatting.Data.RightCPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightCPillarData),
                            RightCPillarId = frameRatting.Data.RightCPillarId,
                            RightDPillarData = frameRatting.Data.RightDPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightDPillarData),
                            RightDPillarId = frameRatting.Data.RightDPillarId,
                            RIGHTFRONTRAILData = frameRatting.Data.RIGHTFRONTRAILData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RIGHTFRONTRAILData),
                            RIGHTFRONTRAILId = frameRatting.Data.RIGHTFRONTRAILId,
                            RightRearLockPillarData = frameRatting.Data.RightRearLockPillarData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightRearLockPillarData),
                            RightRearLockPillarId = frameRatting.Data.RightRearLockPillarId,
                            RightRearRailData = frameRatting.Data.RightRearRailData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightRearRailData),
                            RightRearRailId = frameRatting.Data.RightRearRailId,
                            RSTRUTTWRAPRData = frameRatting.Data.RSTRUTTWRAPRData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RSTRUTTWRAPRData),
                            RSTRUTTWRAPRId = frameRatting.Data.RSTRUTTWRAPRId,
                            FloorPansData = frameRatting.Data.FloorPansData == null ? new PartsDataViewModel(vehicle.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.FloorPansData),
                            FloorPansId = frameRatting.Data.FloorPansId,
                            EvaluatorRatting = frameRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(frameRatting.Data.EvaluatorRatting),
                        },
                        Ratting = Convert.ToDouble(frameRatting.Data.TotalRatting)
                    };
                }

                return new ResultSetViewModel(lst);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
    }

    public class VehicleVIRController : ApiController
    {
        private AutoMaxContext db = new AutoMaxContext();

        public VehicleVIRViewModel GetVehiclesTaqeemByID(string email, string password, long vehicleId)
        {
            password = EncrypterDecrypter.Encrypt(password);
            User user = db.Users.Where(d => d.Email == email && d.Password == password).FirstOrDefault();
            if (user == null)
            {
                new Exception("Invalid credentials, please try again.");
            }

            var obj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == vehicleId);
            if (obj == null)
                new Exception("No vehicle found for this Id " + vehicleId);

            var repository = new VIRRepository();
            var newObj = new VehicleVIRViewModel();

            var exteriorRatting = repository.GetVIR(obj.VehicleID, VIRPartType.EXTERIOR);
            var interiorRatting = repository.GetVIR(obj.VehicleID, VIRPartType.INTERIOR);
            var frameRatting = repository.GetVIR(obj.VehicleID, VIRPartType.FRAME);
            var mechanicsRatting = repository.GetVIR(obj.VehicleID, VIRPartType.MECHANICS);

            newObj.EvaluatorExteriorRatting = obj.EvaluatorExteriorRatting;
            newObj.EvaluatorFrameRatting = obj.EvaluatorFrameRatting;
            newObj.EvaluatorInteriorRatting = obj.EvaluatorInteriorRatting;
            newObj.EvaluatorMechanicsRatting = obj.EvaluatorMechanicsRatting;

            newObj.ExteriorRatting = obj.ExteriorRatting;
            newObj.FrameRatting = obj.FrameRatting;
            newObj.InteriorRatting = obj.InteriorRatting;
            newObj.MechanicsRatting = obj.MechanicsRatting;

            newObj.TotalRatting = obj.TotalRatting;
            newObj.VehicleID = obj.VehicleID;

            newObj.VIR = new VirViewModel
            {
                Exterior = new ExteriorViewModel
                {
                    FrontBumperId = exteriorRatting.Data.FrontBumperId,
                    FrontBumperData = exteriorRatting.Data.FrontBumperData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.FrontBumperData),
                    GrillId = exteriorRatting.Data.GrillId,
                    GrillData = exteriorRatting.Data.GrillData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.GrillData),
                    HeadlightId = exteriorRatting.Data.HeadLightId,
                    HeadlightData = exteriorRatting.Data.HeadLightData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.HeadLightData),
                    HoodId = exteriorRatting.Data.HoodId,
                    HoodData = exteriorRatting.Data.HoodData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.HoodData),
                    LeftFenderId = exteriorRatting.Data.LeftFenderId,
                    LeftFenderData = exteriorRatting.Data.LeftFenderData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LeftFenderData),
                    RightBedSideId = exteriorRatting.Data.RightBedSideId,
                    RightBedSideData = exteriorRatting.Data.RightBedSideData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightBedSideData),
                    LMUDGuardId = exteriorRatting.Data.LMUDGUARDId,
                    LMUDGuardData = exteriorRatting.Data.LMUDGUARDData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LMUDGUARDData),
                    RightFenderId = exteriorRatting.Data.RightFenderId,
                    RightFenderData = exteriorRatting.Data.RightFenderData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightFenderData),
                    RMudGuardId = exteriorRatting.Data.RMudGuardId,
                    RMudGuardData = exteriorRatting.Data.RMudGuardData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RMudGuardData),
                    WIPERSId = exteriorRatting.Data.WIPERSId,
                    WIPERSData = exteriorRatting.Data.WIPERSData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.WIPERSData),
                    WindshieldId = exteriorRatting.Data.RMudGuardId,
                    WindshieldData = exteriorRatting.Data.WindshieldData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.WindshieldData),
                    LeftMirrorId = exteriorRatting.Data.RMudGuardId,
                    LeftMirrorData = exteriorRatting.Data.WindshieldData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.WindshieldData),
                    RightMirrorId = exteriorRatting.Data.RMudGuardId,
                    RightMirrorData = exteriorRatting.Data.RightMirrorData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightMirrorData),
                    LFDoorId = exteriorRatting.Data.LFDoorId,
                    LFDoorData = exteriorRatting.Data.LFDoorData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LFDoorData),
                    RFDoorId = exteriorRatting.Data.LFDoorId,
                    RFDoorData = exteriorRatting.Data.RFDoorData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RFDoorData),
                    LRockerPanelId = exteriorRatting.Data.LRockerPanelId,
                    LRockerPanelData = exteriorRatting.Data.LRockerPanelData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LRockerPanelData),
                    RoofId = exteriorRatting.Data.LRockerPanelId,
                    RoofData = exteriorRatting.Data.RoofData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RoofData),
                    RearWindowId = exteriorRatting.Data.LRockerPanelId,
                    RearWindowData = exteriorRatting.Data.RearWindowData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RearWindowData),
                    RRockerPanelId = exteriorRatting.Data.LRockerPanelId,
                    RRockerPanelData = exteriorRatting.Data.RRockerPanelData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RRockerPanelData),
                    LRdoorId = exteriorRatting.Data.LRockerPanelId,
                    LRdoorData = exteriorRatting.Data.LRdoorData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LRdoorData),
                    RRDoorId = exteriorRatting.Data.LRockerPanelId,
                    RRDoorData = exteriorRatting.Data.RRDoorData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RRDoorData),
                    AnteenaId = exteriorRatting.Data.AnteenaId,
                    AnteenaData = exteriorRatting.Data.AnteenaData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.AnteenaData),
                    BackScreenId = exteriorRatting.Data.BackScreenId,
                    BackScreenData = exteriorRatting.Data.BackScreenData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.BackScreenData),
                    LeftQuarterPanelId = exteriorRatting.Data.LeftQuarterPanelId,
                    LeftQuarterPanelData = exteriorRatting.Data.LeftQuarterPanelData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.LeftQuarterPanelData),
                    TRUNKCARGOId = exteriorRatting.Data.TRUNKCARGOId,
                    TRUNKCARGOData = exteriorRatting.Data.TRUNKCARGOData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.TRUNKCARGOData),
                    RightQuarterPanelId = exteriorRatting.Data.RightQuarterPanelId,
                    RightQuarterPanelData = exteriorRatting.Data.RightQuarterPanelData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RightQuarterPanelData),
                    RREARLIGHTId = exteriorRatting.Data.RREARLIGHTId,
                    RREARLIGHTData = exteriorRatting.Data.RREARLIGHTData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.RREARLIGHTData),
                    TAILERHITCHId = exteriorRatting.Data.TAILERHITCHId,
                    TAILERHITCHData = exteriorRatting.Data.TAILERHITCHData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.TAILERHITCHData),
                    REARBUMPERId = exteriorRatting.Data.REARBUMPERId,
                    REARBUMPERData = exteriorRatting.Data.REARBUMPERData == null ? new PartsDataViewModel(obj.EvaluatorExteriorRatting) : new PartsDataViewModel(exteriorRatting.Data.REARBUMPERData),
                    Ratting = Convert.ToDouble(exteriorRatting.Data.Ratting),
                    EvaluatorRatting = exteriorRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(exteriorRatting.Data.EvaluatorRatting),
                },
                Interior = new InteriorViewModel
                {
                    RearViewMirrorId = interiorRatting.Data.RearViewMirrorId,
                    RearViewMirrorData = interiorRatting.Data.RearViewMirrorData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RearViewMirrorData),
                    GaugesId = interiorRatting.Data.GaugesId,
                    GaugesData = interiorRatting.Data.GaugesData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.GaugesData),
                    AirBagId = interiorRatting.Data.AirBagId,
                    AirBagData = interiorRatting.Data.AirBagData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.AirBagData),
                    ShiftKnobId = interiorRatting.Data.ShiftKnobId,
                    ShiftKnobData = interiorRatting.Data.ShiftKnobData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ShiftKnobData),
                    LFDoorPanelId = interiorRatting.Data.LFDoorPanelId,
                    LFDoorPanelData = interiorRatting.Data.LFDoorPanelData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LFDoorPanelData),
                    RHFRTSeatId = interiorRatting.Data.RHFRTSeatId,
                    RHFRTSeatData = interiorRatting.Data.RHFRTSeatData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RHFRTSeatData),
                    LHFRTSeatId = interiorRatting.Data.LHFRTSeatId,
                    LHFRTSeatData = interiorRatting.Data.LHFRTSeatData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LHFRTSeatData),
                    FrCarpetId = interiorRatting.Data.LHFRTSeatId,
                    FrCarpetData = interiorRatting.Data.LHFRTSeatData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LHFRTSeatData),
                    LRDoorPanelId = interiorRatting.Data.LRDoorPanelId,
                    LRDoorPanelData = interiorRatting.Data.LRDoorPanelData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LRDoorPanelData),
                    RrSeatsId = interiorRatting.Data.RRSeatId,
                    RrSeatsData = interiorRatting.Data.RRSeatData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRSeatData),
                    HeadLinerId = interiorRatting.Data.HeadLinerId,
                    HeadLinerData = interiorRatting.Data.HeadLinerData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.HeadLinerData),
                    RRDoorPanelId = interiorRatting.Data.RRDoorPanelId,
                    RRDoorPanelData = interiorRatting.Data.RRDoorPanelData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRDoorPanelData),
                    LampId = interiorRatting.Data.LampId,
                    LampData = interiorRatting.Data.LampData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LampData),
                    RFDoorPanelId = interiorRatting.Data.RFDoorPanelId,
                    RFDoorPanelData = interiorRatting.Data.RFDoorPanelData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RFDoorPanelData),
                    RadioId = interiorRatting.Data.RadioId,
                    RadioData = interiorRatting.Data.RadioData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RadioData),
                    ConsoleId = interiorRatting.Data.ConsoleId,
                    ConsoleData = interiorRatting.Data.ConsoleData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ConsoleData),
                    GloveBoxId = interiorRatting.Data.GloveBoxId,
                    GloveBoxData = interiorRatting.Data.GloveBoxData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.GloveBoxData),
                    DashId = interiorRatting.Data.DashId,
                    DashData = interiorRatting.Data.DashData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.DashData),
                    ManualsId = interiorRatting.Data.ManualsId,
                    ManualsData = interiorRatting.Data.ManualsData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ManualsData),
                    LRCarpetId = interiorRatting.Data.LRCarpetId,
                    LRCarpetData = interiorRatting.Data.LRCarpetData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.LRCarpetData),
                    InteriorPartsId = interiorRatting.Data.InteriorPartsId,
                    InteriorPartsData = interiorRatting.Data.InteriorPartsData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.InteriorPartsData),
                    FeaturesId = interiorRatting.Data.FeaturesId,
                    FeaturesData = interiorRatting.Data.FeaturesData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.FeaturesData),
                    FourthRowSeatId = interiorRatting.Data.FourthRowSeatId,
                    FourthRowSeatData = interiorRatting.Data.FourthRowSeatData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.FourthRowSeatData),
                    OdorId = interiorRatting.Data.OdorId,
                    OdorData = interiorRatting.Data.OdorData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.OdorData),
                    RearArmrestId = interiorRatting.Data.RearArmrestId,
                    RearArmrestData = interiorRatting.Data.RearArmrestData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RearArmrestData),
                    RRCarpetId = interiorRatting.Data.RRCarpetId,
                    RRCarpetData = interiorRatting.Data.RRCarpetData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRCarpetData),
                    ThirdRowSeatId = interiorRatting.Data.ThirdRowSeatId,
                    ThirdRowSeatData = interiorRatting.Data.ThirdRowSeatData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.ThirdRowSeatData),
                    RRSeatsLeftId = interiorRatting.Data.RRSeatsLeftId,
                    RRSeatsLeftData = interiorRatting.Data.RRSeatsLeftData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRSeatsLeftData),
                    RRSeatsRightId = interiorRatting.Data.RRSeatsRightId,
                    RRSeatsRightData = interiorRatting.Data.RRSeatsRightData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.RRSeatsRightData),
                    SteeringWheelId = interiorRatting.Data.SteeringWheelId,
                    SteeringWheelData = interiorRatting.Data.SteeringWheelData == null ? new PartsDataViewModel(obj.EvaluatorInteriorRatting) : new PartsDataViewModel(interiorRatting.Data.SteeringWheelData),
                    Ratting = Convert.ToDouble(interiorRatting.Data.Ratting),
                    EvaluatorRatting = interiorRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(interiorRatting.Data.EvaluatorRatting),
                },
                Mechanics = new MechanicsViewModel
                {
                    PowerSteeringId = mechanicsRatting.Data.PowerSteeringId,
                    PowerSteeringData = mechanicsRatting.Data.PowerSteeringData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.PowerSteeringData),
                    ClimateControlId = mechanicsRatting.Data.ClimateControlId,
                    ClimateControlData = mechanicsRatting.Data.ClimateControlData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ClimateControlData),
                    FrontShockId = mechanicsRatting.Data.FrontShockId,
                    FrontShockData = mechanicsRatting.Data.FrontShockData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FrontShockData),
                    FrontAxleId = mechanicsRatting.Data.FrontAxleId,
                    FrontAxleData = mechanicsRatting.Data.FrontAxleData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FrontAxleData),
                    LFWheelId = mechanicsRatting.Data.LFWheelId,
                    LFWheelData = mechanicsRatting.Data.LFWheelData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LFWheelData),
                    TransmissionId = mechanicsRatting.Data.TransmissionId,
                    TransmissionData = mechanicsRatting.Data.TransmissionData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.TransmissionData),
                    BatteryId = mechanicsRatting.Data.BatteryId,
                    BatteryData = mechanicsRatting.Data.BatteryData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.BatteryData),
                    RearShocksId = mechanicsRatting.Data.RearShocksId,
                    RearShocksData = mechanicsRatting.Data.RearShocksData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RearShocksData),
                    RearAxleId = mechanicsRatting.Data.RearAxleId,
                    RearAxleData = mechanicsRatting.Data.RearAxleData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RearAxleData),
                    LRWheelId = mechanicsRatting.Data.LRWheelId,
                    LRWheelData = mechanicsRatting.Data.LRWheelData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LRWheelData),
                    ExhaustId = mechanicsRatting.Data.ExhaustId,
                    ExhaustData = mechanicsRatting.Data.ExhaustData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ExhaustData),
                    LRWinMechanicsId = mechanicsRatting.Data.LRWinMechanicsId,
                    LRWinMechanicsData = mechanicsRatting.Data.LRWinMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LRWinMechanicsData),
                    LFWinMechanicsId = mechanicsRatting.Data.LFWinMechanicsId,
                    LFWinMechanicsData = mechanicsRatting.Data.LFWinMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LFWinMechanicsData),
                    LFDoorMechanicsId = mechanicsRatting.Data.LFDoorMechanicsId,
                    LFDoorMechanicsData = mechanicsRatting.Data.LFDoorMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LFDoorMechanicsData),
                    LRDoorMechanicsId = mechanicsRatting.Data.LRDoorMechanicsId,
                    LRDoorMechanicsData = mechanicsRatting.Data.LRDoorMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.LRDoorMechanicsData),
                    RRDoorMechanicsId = mechanicsRatting.Data.RRDoorMechanicsId,
                    RRDoorMechanicsData = mechanicsRatting.Data.RRDoorMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RRDoorMechanicsData),
                    RFDoorMechanicsId = mechanicsRatting.Data.RFDoorMechanicsId,
                    RFDoorMechanicsData = mechanicsRatting.Data.RFDoorMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RFDoorMechanicsData),

                    RFWinMechanicsId = mechanicsRatting.Data.RFWinMechanicsId,
                    RFWinMechanicsData = mechanicsRatting.Data.RFWinMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RFWinMechanicsData),
                    RRWinMechanicsId = mechanicsRatting.Data.RRWinMechanicsId,
                    RRWinMechanicsData = mechanicsRatting.Data.RRWinMechanicsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RRWinMechanicsData),
                    EmissionId = mechanicsRatting.Data.EmissionId,
                    EmissionData = mechanicsRatting.Data.EmissionData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.EmissionData),
                    RearBreakId = mechanicsRatting.Data.RearBreakId,
                    RearBreakData = mechanicsRatting.Data.RearBreakData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RearBreakData),
                    RRWheelId = mechanicsRatting.Data.RRWheelId,
                    RRWheelData = mechanicsRatting.Data.RRWheelData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RRWheelData),
                    ClutchId = mechanicsRatting.Data.ClutchId,
                    ClutchData = mechanicsRatting.Data.ClutchData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ClutchData),

                    FrontBreakId = mechanicsRatting.Data.FrontBreakId,
                    FrontBreakData = mechanicsRatting.Data.FrontBreakData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FrontBreakData),
                    RFWheelId = mechanicsRatting.Data.RFWheelId,
                    RFWheelData = mechanicsRatting.Data.RFWheelData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.RFWheelData),
                    EngineId = mechanicsRatting.Data.EngineId,
                    EngineData = mechanicsRatting.Data.EngineData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.EngineData),
                    ElectricsId = mechanicsRatting.Data.ElectricsId,
                    ElectricsData = mechanicsRatting.Data.ElectricsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ElectricsData),
                    SpareTypeId = mechanicsRatting.Data.SpareTypeId,
                    SpareTypeData = mechanicsRatting.Data.SpareTypeData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.SpareTypeData),
                    FuelTankId = mechanicsRatting.Data.FuelTankId,
                    FuelTankData = mechanicsRatting.Data.FuelTankData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.FuelTankData),

                    WarningLightsId = mechanicsRatting.Data.WarningLightsId,
                    WarningLightsData = mechanicsRatting.Data.WarningLightsData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.WarningLightsData),
                    ToolsJacksId = mechanicsRatting.Data.ToolsJacksId,
                    ToolsJacksData = mechanicsRatting.Data.ToolsJacksData == null ? new PartsDataViewModel(obj.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsRatting.Data.ToolsJacksData),
                    Ratting = Convert.ToDouble(mechanicsRatting.Data.Ratting),
                    EvaluatorRatting = mechanicsRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(mechanicsRatting.Data.EvaluatorRatting),
                },
                Frame = new FrameViewModel
                {
                    Ratting = Convert.ToDouble(frameRatting.Data.Ratting),
                    CowlPanelFirewallData = frameRatting.Data.CowlPanelFirewallData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.CowlPanelFirewallData),
                    CowlPanelFirewallId = frameRatting.Data.CowlPanelFirewallId,
                    LeftAPillarData = frameRatting.Data.LeftAPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftAPillarData),
                    LeftAPillarId = frameRatting.Data.LeftAPillarId,
                    LeftApronData = frameRatting.Data.LeftApronData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftApronData),
                    LeftApronId = frameRatting.Data.LeftApronId,
                    LeftBPillarData = frameRatting.Data.LeftBPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftBPillarData),
                    LeftBPillarId = frameRatting.Data.LeftBPillarId,
                    LeftCPillarData = frameRatting.Data.LeftCPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftCPillarData),
                    LeftCPillarId = frameRatting.Data.LeftCPillarId,
                    LeftDPillarData = frameRatting.Data.LeftDPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftDPillarData),
                    LeftDPillarId = frameRatting.Data.LeftDPillarId,
                    LeftFrontRailData = frameRatting.Data.LeftFrontRailData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftFrontRailData),
                    LeftFrontRailId = frameRatting.Data.LeftFrontRailId,
                    LeftRearLockPillarData = frameRatting.Data.LeftRearLockPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftRearLockPillarData),
                    LeftRearLockPillarId = frameRatting.Data.LeftRearLockPillarId,
                    LeftRearRailData = frameRatting.Data.LeftRearRailData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftRearRailData),
                    LeftRearRailId = frameRatting.Data.LeftRearRailId,
                    LeftStrutTowerApronData = frameRatting.Data.LeftStrutTowerApronData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.LeftStrutTowerApronData),
                    LeftStrutTowerApronId = frameRatting.Data.LeftStrutTowerApronId,
                    PerimeterFrameData = frameRatting.Data.PerimeterFrameData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.PerimeterFrameData),
                    PerimeterFrameId = frameRatting.Data.PerimeterFrameId,
                    RadiatorCoreSupportData = frameRatting.Data.RadiatorCoreSupportData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RadiatorCoreSupportData),
                    RadiatorCoreSupportId = frameRatting.Data.RadiatorCoreSupportId,
                    RightAPillarData = frameRatting.Data.RightAPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightAPillarData),
                    RightAPillarId = frameRatting.Data.RightAPillarId,
                    RightApronData = frameRatting.Data.RightApronData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightApronData),
                    RightApronId = frameRatting.Data.RightApronId,
                    RightBPillarData = frameRatting.Data.RightBPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightBPillarData),
                    RightBPillarId = frameRatting.Data.RightBPillarId,
                    RightCPillarData = frameRatting.Data.RightCPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightCPillarData),
                    RightCPillarId = frameRatting.Data.RightCPillarId,
                    RightDPillarData = frameRatting.Data.RightDPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightDPillarData),
                    RightDPillarId = frameRatting.Data.RightDPillarId,
                    RIGHTFRONTRAILData = frameRatting.Data.RIGHTFRONTRAILData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RIGHTFRONTRAILData),
                    RIGHTFRONTRAILId = frameRatting.Data.RIGHTFRONTRAILId,
                    RightRearLockPillarData = frameRatting.Data.RightRearLockPillarData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightRearLockPillarData),
                    RightRearLockPillarId = frameRatting.Data.RightRearLockPillarId,
                    RightRearRailData = frameRatting.Data.RightRearRailData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RightRearRailData),
                    RightRearRailId = frameRatting.Data.RightRearRailId,
                    RSTRUTTWRAPRData = frameRatting.Data.RSTRUTTWRAPRData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.RSTRUTTWRAPRData),
                    RSTRUTTWRAPRId = frameRatting.Data.RSTRUTTWRAPRId,
                    FloorPansData = frameRatting.Data.FloorPansData == null ? new PartsDataViewModel(obj.EvaluatorFrameRatting) : new PartsDataViewModel(frameRatting.Data.FloorPansData),
                    FloorPansId = frameRatting.Data.FloorPansId,
                    EvaluatorRatting = frameRatting.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(frameRatting.Data.EvaluatorRatting),
                },
                Ratting = Convert.ToDouble(frameRatting.Data.TotalRatting)
            };

            return newObj;
        }

        public ResultSetViewModel GetVehiclesTaqeem(string email, string password, int pageNumber, int pageSize)
        {
            password = EncrypterDecrypter.Encrypt(password);
            User user = db.Users.Where(d => d.Email == email && d.Password == password).FirstOrDefault();
            if (user == null)
            {
                new Exception("Invalid credentials, please try again.");
            }

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var lst = (from data in db.VehicleWizards
                       select data.VehicleID).OrderBy(a => a).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var resultList = new List<VehicleVIRViewModel>();

            foreach (var id in lst)
            {
                resultList.Add(GetVehiclesTaqeemByID(email, password, id));
            }

            return new ResultSetViewModel(resultList);
        }

        public ResultSetViewModel GetTaqeemImages(string email, string password, int vehicleId, int vehiclePartId)
        {
            password = EncrypterDecrypter.Encrypt(password);
            User user = db.Users.Where(d => d.Email == email && d.Password == password).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Invalid credentials, please try again.");
            }

            if (vehicleId > 0 && vehiclePartId > 0)
            {
                var obj = new VIRRepository().LoadVehiclePartImages(vehicleId, vehiclePartId, "VehicleAttachments/VehicleParts/");
                return obj;
            }
            else
            {
                throw new Exception("Vehicle or Part Id is not valid");
            }
        }
    }

    public class MediaController : ApiController
    {
        public ResultSetViewModel AddUpdateVehicleVideo(VehicleVideoViewModel model)
        {
            return new VIRRepository().AddUpdateVehicleVideo(model);
        }

        public ResultSetViewModel RemoveVehicleVideo(int videoId)
        {
            return new VIRRepository().RemoveVehicleVideo(videoId);
        }

        public ResultSetViewModel LoadVehicleVideos(long vehicleId)
        {
            return new VIRRepository().LoadVehicleVideos(vehicleId);
        }

        public ResultSetViewModel RemoveVehicleImage(int imageId, bool isPartImage)
        {
            if (isPartImage)
            {
                return new VIRRepository().RemoveVehiclePartImage(imageId);
            }
            else
            {
                return new VIRRepository().RemoveVehicleImage(imageId);
            }
        }
    }

    public class ImageController : ApiController
    {
        public ResultSetViewModel RemoveVehicleImage(int imageId, bool isPartImage)
        {
            if (isPartImage)
            {
                return new VIRRepository().RemoveVehiclePartImage(imageId);
            }
            else
            {
                return new VIRRepository().RemoveVehicleImage(imageId);
            }
        }
    }

    public class VIRPartController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vir"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public ResultSetViewModel AddUpdateVIRPartInformation(VIR vir)
        {
            return new VIRRepository().AddUpdateVIRPartInformation(vir);
        }
    }

    public class EvaluatorController : ApiController
    {
        [System.Web.Http.HttpPost]
        public ResultSetViewModel UpdateEvaluatorRatting(EvaluatorRatting evaluatorRatting)
        {
            return new VIRRepository().UpdateEvaluatorRatting(evaluatorRatting.VehicleId, evaluatorRatting.VIRPartType, evaluatorRatting.Ratting);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VIRInformationController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vir"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public ResultSetViewModel SaveInformation(CarInfo carInfo)
        {
            return new VIRRepository().SaveInformation(carInfo);
        }
    }

    public class VIRController : ApiController
    {
        private AutoMaxContext db = new AutoMaxContext();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResultSetViewModel LoadVehicleAddress()
        {
            return new VIRRepository().LoadVehicleAddress(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResultSetViewModel LoadVIROptionProperties(int vehicleIdForOptionProperties)
        {
            return new VIRRepository().LoadVIROptionProperties(vehicleIdForOptionProperties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResultSetViewModel LoadVIRFlagProperties(int vehicleIdForFlagProperties)
        {
            return new VIRRepository().LoadVIRFlagProperties(vehicleIdForFlagProperties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public ResultSetViewModel AddVehicleAddress(VehicleAddressViewModel model)
        {
            return new VIRRepository().AddVehicleAddress(model);
        }

        /// <summary>
        /// Sample call: http://localhost/AutoMax/api/vir/LoadVIRPartConditionSeverityLevels?partid=-1
        /// </summary>
        /// <param name="partId"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResultSetViewModel LoadVIRPartConditionSeverityLevels(int partId)
        {
            //var test =  new VIRRepository().LoadVIROptionProperties(vehicleId);
            //test = new VIRRepository().LoadVIRFlagProperties(vehicleId);

            return new VIRRepository().LoadVIRPartConditionSeverityLevels(partId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="virPartType"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResultSetViewModel GetVIR(int vehicleId, VIRPartType virPartType)
        {
            return new VIRRepository().GetVIR(vehicleId, virPartType);
        }

        //[System.Web.Http.HttpPost]
        //[System.Web.Http.Route("MyTestUpload")]
        //public async Task<IHttpActionResult> MyTestUpload(long vehicleId)
        //{
        //    return null;
        //}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> UploadImage(long vehicleId)
        {
            try
            {
                var fileName = "MobileUpload-";
                var extention = ".png"; // retur
                var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                fileName = fileName + date;// + extention;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/VehicleAttachments/"));
                bool isExists = Directory.Exists(path);

                if (!isExists)
                    System.IO.Directory.CreateDirectory(path);

                var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
                rootUrl = Request.Headers.Host;

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new AutoMaxMultipartFormDataStreamProvider(path, fileName);
                    var result = await Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<List<FileDesc>>(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        var fileInfo = streamProvider.FileData.Select(i =>
                        {
                            var info = new FileInfo(i.LocalFileName);
                            return new FileDesc(info.FullName, fileName, "http://" + rootUrl + "/" + fileName, info.Length / 1024, info.Extension, 0);
                        }).ToList();
                        return fileInfo;
                    });

                    if (result != null && result.Count > 0)
                    {
                        extention = result[0].Ext;
                    }

                    fileName = fileName + extention;

                    VehicleImage img = new VehicleImage();
                    img.ImagePath = fileName;
                    img.VehicleID = vehicleId;
                    img.CreatedBy = 1;
                    img.UpdatedBy = 1;
                    img.DisplayOrder = db.VehicleImages.FirstOrDefault(a => a.VehicleID == vehicleId && a.DisplayOrder > 0) == null ? 1 : 0;
                    img.CreatedDate = DateTime.Now;
                    img.UpdatedDate = DateTime.Now;
                    db.VehicleImages.Add(img);
                    db.SaveChanges();
                    var ImagePath = Path.Combine("VehicleAttachments/", fileName);
                    return Ok(ImagePath);
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="vehiclePartId"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> UploadVehiclePartImage(long vehicleId, int vehiclePartId)
        {
            try
            {
                var fileName = "MobileUploadVehiclePart-";
                var extention = ".png"; // retur
                var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                fileName = fileName + date;// + extention;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/VehicleAttachments/VehicleParts/"));
                bool isExists = Directory.Exists(path);

                if (!isExists)
                    System.IO.Directory.CreateDirectory(path);

                var rootUrl = Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.AbsolutePath, String.Empty);
                rootUrl = Request.Headers.Host;
                var lstResult = new List<VehiclePartImage>();
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                if (Request.Content.IsMimeMultipartContent())
                {
                    var streamProvider = new AutoMaxMultipartFormDataStreamProvider(path, fileName);
                    var result = await Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<List<FileDesc>>(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        var fileInfo = streamProvider.FileData.Select(i =>
                        {
                            var info = new FileInfo(i.LocalFileName);
                            return new FileDesc(info.FullName, fileName, "http://" + rootUrl + "/" + fileName, info.Length / 1024, info.Extension, 0);
                        }).ToList();
                        return fileInfo;
                    });

                    if (result!=null && result.Count > 0)
                    {
                        extention = result[0].Ext;
                    }

                    fileName = fileName + extention;

                    var vir = db.VIR.FirstOrDefault(a => a.fkVehickeId == vehicleId && a.fkPartId == vehiclePartId);

                    if (vir != null)
                    {
                        VehiclePartImage img = new VehiclePartImage();
                        img.ImagePath = fileName;
                        img.VehicleID = vehicleId;
                        img.VIRID = vir.Id;
                        img.CreatedBy = 1;
                        img.UpdatedBy = 1;
                        img.CreatedDate = DateTime.Now;
                        img.UpdatedDate = DateTime.Now;
                        db.VehiclePartImage.Add(img);
                        db.SaveChanges();
                        lstResult.Add(img);
                    }
                    else
                    {
                        var newVir = new VIR();
                        newVir.fkPartId = vehiclePartId;
                        newVir.fkUserId = 1;
                        newVir.fkVehickeId = Convert.ToInt32(vehicleId);
                        newVir.Ratting = 0;

                        db.VIR.Add(newVir);
                        db.SaveChanges();

                        VehiclePartImage img = new VehiclePartImage();
                        img.ImagePath = fileName;
                        img.VehicleID = vehicleId;
                        img.VIRID = newVir.Id;
                        img.CreatedBy = 1;
                        img.UpdatedBy = 1;
                        img.CreatedDate = DateTime.Now;
                        img.UpdatedDate = DateTime.Now;
                        db.VehiclePartImage.Add(img);
                        db.SaveChanges();
                        lstResult.Add(img);
                    }

                    var ImagePath = Path.Combine("VehicleAttachments/VehicleParts/", fileName);
                    return Ok(ImagePath);
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                }
            }
            catch (Exception ex)
            {
                throw ex;// new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="vehiclePartId"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResultSetViewModel LoadVehiclePartImages(long vehicleId, int vehiclePartId)
        {
            var obj = new VIRRepository().LoadVehiclePartImages(vehicleId, vehiclePartId, "VehicleAttachments/VehicleParts/");
            return obj;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="vehiclePartId"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResultSetViewModel LoadVehicleImages(long vehicleIdForImages)
        {
            var obj = new VIRRepository().LoadVehicleImages(vehicleIdForImages, "VehicleAttachments/");
            return obj;
        }
        [System.Web.Http.HttpPost]
        public ResultSetViewModel SaveOptions(bool isFlag, VehicleOptionsSaveModel vehicleOptionsSaveModel)
        {
            if (isFlag)
            {
                return new VIRRepository().SaveVIRFlags(vehicleOptionsSaveModel);
            }
            else
            {
                return new VIRRepository().SaveVIROption(vehicleOptionsSaveModel);
            }
        }
    }


    public class FileDesc
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Ext { get; set; }
        public int ThumbTypeId { get; set; }
        public string FullName { get; set; }
        public FileDesc(string fullName, string name, string path, long size, string ext, int type)
        {
            FullName = fullName;
            Name = name;
            Path = path;
            Size = size;
            Ext = ext;
            ThumbTypeId = type;
        }
    }

    public class AutoMaxMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        string FileName;
        public AutoMaxMultipartFormDataStreamProvider(string path, string fileName)
            : base(path)
        {
            FileName = fileName;

        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string fileName;
            if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
            {
                string fname = headers.ContentDisposition.FileName;
                string[] file = fname.Split('.');
                string ext = file[1];
                fileName = @"\" + FileName + "." + ext;

                //fileName = headers.ContentDisposition.FileName;
            }
            else
            {
                fileName = FileName + ".data";


            }
            return fileName.Replace("\"", string.Empty);
        }
    }
}
