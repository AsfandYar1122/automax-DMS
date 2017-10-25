using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Sql;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMax.Models;
using System.IO;
using Newtonsoft.Json;
using AutoMax.Models.Entities;
using AutoMax.Common.Enums;
using AutoMax.Models.DataModel;
using System.Web.Configuration;
using AutoMax.Models.Common;
using System.Drawing;
using QRCoder;
//using iTextSharp.text;
//using iTextSharp.text.pdf;

namespace AutoMax.Controllers
{
    //[Authorize]
    public class VirController : BaseController
    {
        public string GetDropDownBindValue(string value)
        {
            if (SharedStorage.Instance.LastSelectedLanguage == Models.Common.Language.Arabic)
            {
                return "Arabic" + value;
            }

            return value;
        }

        
        public ActionResult Index(long id)
        {
            ViewBag.VehicleID = id;
            var obj1 = new VIRRepository().GetVIR(id, VIRPartType.EXTERIOR);
            var obj2 = new VIRRepository().GetVIR(id, VIRPartType.INTERIOR);
            var mechanicsData = new VIRRepository().GetVIR(id, VIRPartType.MECHANICS);
            var obj4 = new VIRRepository().GetVIR(id, VIRPartType.FRAME);
            var optonsList = new VIRRepository().LoadVIROptionProperties(id);
            var flagOptions = new VIRRepository().LoadVIRFlagProperties(id);
            
            VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == id);

            var userId = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();

            bool isMarketingUser = (userId != null && userId.Role == UserRolesConst.Marketing);

            if (vehicleWizard == null)
            {
                return HttpNotFound();
            }
            VirMainViewModel model = new VirMainViewModel();
            model.IsMarketingUser = isMarketingUser;
            model.Information = new CarInformationViewModel
            {
                //DealerID = vehicleWizard.DealerID,
                PlateNumber = vehicleWizard.PlateNumber,
                AutoUsedStatusID = new SelectList(db.AutoUsedStatus, "AutoUsedStatusID", SharedStorage.Instance.GetDropDownBindValue("UsedStatus"), vehicleWizard.AutoUsedStatusID),
               
               
                AutoDoorsID = new SelectList(db.AutoDoors, "AutoDoorsID", SharedStorage.Instance.GetDropDownBindValue("Doors"), vehicleWizard.AutoDoorsID),
                AutoEngineID = new SelectList(db.AutoEngines, "AutoEngineID", SharedStorage.Instance.GetDropDownBindValue("EngineName"), vehicleWizard.AutoEngineID),
                AutoExteriorColorID = new SelectList(db.AutoExteriorColors, "AutoExteriorColorID", SharedStorage.Instance.GetDropDownBindValue("ExteriorColor"), vehicleWizard.AutoExteriorColorID),
                AutoInteriorColorID = new SelectList(db.AutoInteriorColors, "AutoInteriorColorID", SharedStorage.Instance.GetDropDownBindValue("InteriorColor"), vehicleWizard.AutoInteriorColorID),
                AutoModelID = new SelectList(db.AutoModels.Where(a=>a.MakerID == vehicleWizard.MakerID && vehicleWizard.MakerID != null).ToList(), "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.AutoModelID),
                AutoSteeringID = new SelectList(db.AutoSteerings, "AutoSteeringID", SharedStorage.Instance.GetDropDownBindValue("Steering"), vehicleWizard.AutoSteeringID),
                AutoTransmissionID = new SelectList(db.AutoTransmissions, "AutoTransmissionID", SharedStorage.Instance.GetDropDownBindValue("Transmission"), vehicleWizard.AutoTransmissionID),
                DriveTypeID = new SelectList(db.DriveTypes, "DriveTypeID", SharedStorage.Instance.GetDropDownBindValue("DriveTypeV"), vehicleWizard.DriveTypeID),
                FuelTypeID = new SelectList(db.FuelTypes, "FuelTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.FuelTypeID),
                InventoryStatusID = new SelectList(db.InventoryStatus, "InventoryStatusID", SharedStorage.Instance.GetDropDownBindValue("Status"), vehicleWizard.InventoryStatusID),
                MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), vehicleWizard.MakerID),
                YearID = new SelectList(db.Years, "YearID", SharedStorage.Instance.GetDropDownBindValue("YearName"), vehicleWizard.YearID),
                AutoAirBagID = new SelectList(db.AutoAirBags, "AutoAirBagID", SharedStorage.Instance.GetDropDownBindValue("Value"), vehicleWizard.AutoAirBagID),
                RoofTypeID = new SelectList(db.RoofTypes, "RoofTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"),vehicleWizard.RoofTypeID),
                UpholsteryID = new SelectList(db.Upholsteries, "UpholsteryID", SharedStorage.Instance.GetDropDownBindValue("Name"),vehicleWizard.UpholsteryID),
                VehicleAudioID = new SelectList(db.VehicleAudio, "AudioID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.VehicleAudioID),
                VehicleInteriorTypeID = new SelectList(db.VehicleInteriorType, "InteriorTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.VehicleInteriorTypeID),
               
                VehicleTypeId= new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.VehicleTypeID),
                VIN = vehicleWizard.VIN,
                Odometer = vehicleWizard.Odometer,
                StockNumber = vehicleWizard.StockNumber,
                FreeText = vehicleWizard.FreeText,
                ArabicDescription = vehicleWizard.ArabicDescription,
                ArabicFreeText = vehicleWizard.ArabicFreeText,
                ArabicWarantyText = vehicleWizard.ArabicWarantyText,
                Price = vehicleWizard.VehiclePrice != null ? (decimal)vehicleWizard.VehiclePrice : 0,
                PurchasingCost = vehicleWizard.PurchasingCost != null ? (decimal)vehicleWizard.PurchasingCost : 0,
                Has360 = vehicleWizard.Has360!=null?(bool)vehicleWizard.Has360:false,
               
                SubModelID = new SelectList(db.SubModels, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.SubModelID)
        };
            
            var obj = new VIRRepository().LoadVehicleImages(id, "VehicleAttachments/");
            ViewBag.Gallery = obj.Data;
            var vehicleVideos = new VIRRepository().LoadVehicleVideos(id);
            ViewBag.VideoGallery = vehicleVideos.Data;
            //var obj = new VIRRepository().LoadVehiclePartImages(id, vehiclePartImages, "VehicleAttachments/VehicleParts/");
            //var jserialized = JsonConvert.SerializeObject(obj);

            model.Vir = new VirViewModel
            {
                Exterior = new ExteriorViewModel
                {
                    FrontBumperId = obj1.Data.FrontBumperId,
                    FrontBumperData = obj1.Data.FrontBumperData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.FrontBumperData),
                    GrillId = obj1.Data.GrillId,
                    GrillData = obj1.Data.GrillData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.GrillData),
                    HeadlightId = obj1.Data.HeadLightId,
                    HeadlightData = obj1.Data.HeadLightData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.HeadLightData),
                    HoodId = obj1.Data.HoodId,
                    HoodData = obj1.Data.HoodData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.HoodData),
                    LeftFenderId = obj1.Data.LeftFenderId,
                    LeftFenderData = obj1.Data.LeftFenderData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.LeftFenderData),
                    RightBedSideId = obj1.Data.RightBedSideId,
                    RightBedSideData = obj1.Data.RightBedSideData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RightBedSideData),
                    LMUDGuardId = obj1.Data.LMUDGUARDId,
                    LMUDGuardData = obj1.Data.LMUDGUARDData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.LMUDGUARDData),
                    RightFenderId = obj1.Data.RightFenderId,
                    RightFenderData = obj1.Data.RightFenderData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RightFenderData),
                    RMudGuardId = obj1.Data.RMudGuardId,
                    RMudGuardData = obj1.Data.RMudGuardData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RMudGuardData),
                    WIPERSId = obj1.Data.WIPERSId,
                    WIPERSData = obj1.Data.WIPERSData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.WIPERSData),
                    WindshieldId = obj1.Data.WindshieldId,
                    WindshieldData = obj1.Data.WindshieldData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.WindshieldData),
                    LeftMirrorId = obj1.Data.LeftMirrorId,
                    LeftMirrorData = obj1.Data.LeftMirrorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.LeftMirrorData),
                    RightMirrorId = obj1.Data.RightMirrorId,
                    RightMirrorData = obj1.Data.RightMirrorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RightMirrorData),
                    LFDoorId = obj1.Data.LFDoorId,
                    LFDoorData = obj1.Data.LFDoorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.LFDoorData),
                    RFDoorId = obj1.Data.RFDoorId,
                    RFDoorData = obj1.Data.RFDoorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RFDoorData),
                    LRockerPanelId = obj1.Data.LRockerPanelId,
                    LRockerPanelData = obj1.Data.LRockerPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.LRockerPanelData),
                    RoofId = obj1.Data.RoofId,
                    RoofData = obj1.Data.RoofData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RoofData),
                    RearWindowId = obj1.Data.RearWindowId,
                    RearWindowData = obj1.Data.RearWindowData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RearWindowData),
                    RRockerPanelId = obj1.Data.RRockerPanelId,
                    RRockerPanelData = obj1.Data.RRockerPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RRockerPanelData),
                    LRdoorId = obj1.Data.LRdoorId,
                    LRdoorData = obj1.Data.LRdoorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.LRdoorData),
                    RRDoorId = obj1.Data.RRDoorId,
                    RRDoorData = obj1.Data.RRDoorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RRDoorData),
                    AnteenaId = obj1.Data.AnteenaId,
                    AnteenaData = obj1.Data.AnteenaData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.AnteenaData),
                    BackScreenId = obj1.Data.BackScreenId,
                    BackScreenData = obj1.Data.BackScreenData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.BackScreenData),
                    LeftQuarterPanelId = obj1.Data.LeftQuarterPanelId,
                    LeftQuarterPanelData = obj1.Data.LeftQuarterPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.LeftQuarterPanelData),
                    TRUNKCARGOId = obj1.Data.TRUNKCARGOId,
                    TRUNKCARGOData = obj1.Data.TRUNKCARGOData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.TRUNKCARGOData),
                    RightQuarterPanelId = obj1.Data.RightQuarterPanelId,
                    RightQuarterPanelData = obj1.Data.RightQuarterPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RightQuarterPanelData),
                    RREARLIGHTId = obj1.Data.RREARLIGHTId,
                    RREARLIGHTData = obj1.Data.RREARLIGHTData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.RREARLIGHTData),
                    TAILERHITCHId = obj1.Data.TAILERHITCHId,
                    TAILERHITCHData = obj1.Data.TAILERHITCHData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.TAILERHITCHData),
                    REARBUMPERId = obj1.Data.REARBUMPERId,
                    REARBUMPERData = obj1.Data.REARBUMPERData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorExteriorRatting) : new PartsDataViewModel(obj1.Data.REARBUMPERData),
                    Ratting= Convert.ToDouble(obj1.Data.Ratting),
                    EvaluatorRatting = obj1.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(obj1.Data.EvaluatorRatting),
                    SunRoofID = obj1.Data.SunRoofId,
                    SunRoofData = obj1.Data.SunRoofData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj1.Data.SunRoofData),
                    RightDoorID = obj1.Data.RightDoorId,
                    RightDoorData = obj1.Data.RightDoorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj1.Data.RightDoorData),
                    LeftDoorID = obj1.Data.LeftDoorId,
                    LeftDoorData = obj1.Data.LeftDoorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj1.Data.LeftDoorData),
                },
                Interior = new InteriorViewModel
                {
                    RearViewMirrorId = obj2.Data.RearViewMirrorId,
                    RearViewMirrorData = obj2.Data.RearViewMirrorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RearViewMirrorData),
                    GaugesId = obj2.Data.GaugesId,
                    GaugesData = obj2.Data.GaugesData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.GaugesData),
                    AirBagId = obj2.Data.AirBagId,
                    AirBagData = obj2.Data.AirBagData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.AirBagData),
                    ShiftKnobId = obj2.Data.ShiftKnobId,
                    ShiftKnobData = obj2.Data.ShiftKnobData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.ShiftKnobData),
                    LFDoorPanelId = obj2.Data.LFDoorPanelId,
                    LFDoorPanelData = obj2.Data.LFDoorPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.LFDoorPanelData),
                    RHFRTSeatId = obj2.Data.RHFRTSeatId,
                    RHFRTSeatData = obj2.Data.RHFRTSeatData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RHFRTSeatData),
                    LHFRTSeatId = obj2.Data.LHFRTSeatId,
                    LHFRTSeatData = obj2.Data.LHFRTSeatData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.LHFRTSeatData),
                    FrCarpetId = obj2.Data.FrCarpetId,
                    FrCarpetData = obj2.Data.FrCarpetData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.FrCarpetData),
                    LRDoorPanelId = obj2.Data.LRDoorPanelId,
                    LRDoorPanelData = obj2.Data.LRDoorPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.LRDoorPanelData),
                    RrSeatsId = obj2.Data.RRSeatId,
                    RrSeatsData = obj2.Data.RRSeatData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RRSeatData),
                    HeadLinerId = obj2.Data.HeadLinerId,
                    HeadLinerData = obj2.Data.HeadLinerData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.HeadLinerData),
                    RRDoorPanelId = obj2.Data.RRDoorPanelId,
                    RRDoorPanelData = obj2.Data.RRDoorPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RRDoorPanelData),
                    LampId = obj2.Data.LampId,
                    LampData = obj2.Data.LampData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.LampData),
                    RFDoorPanelId = obj2.Data.RFDoorPanelId,
                    RFDoorPanelData = obj2.Data.RFDoorPanelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RFDoorPanelData),
                    RadioId = obj2.Data.RadioId,
                    RadioData = obj2.Data.RadioData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RadioData),
                    ConsoleId = obj2.Data.ConsoleId,
                    ConsoleData = obj2.Data.ConsoleData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.ConsoleData),
                    GloveBoxId = obj2.Data.GloveBoxId,
                    GloveBoxData = obj2.Data.GloveBoxData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.GloveBoxData),
                    DashId= obj2.Data.DashId,
                    DashData = obj2.Data.DashData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.DashData),
                    ManualsId= obj2.Data.ManualsId,
                    ManualsData = obj2.Data.ManualsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.ManualsData),
                    LRCarpetId= obj2.Data.LRCarpetId,
                    LRCarpetData= obj2.Data.LRCarpetData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.LRCarpetData),
                    InteriorPartsId= obj2.Data.InteriorPartsId,
                    InteriorPartsData = obj2.Data.InteriorPartsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.InteriorPartsData),
                    FeaturesId= obj2.Data.FeaturesId,
                    FeaturesData= obj2.Data.FeaturesData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.FeaturesData),
                    FourthRowSeatId= obj2.Data.FourthRowSeatId,
                    FourthRowSeatData = obj2.Data.FourthRowSeatData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.FourthRowSeatData),
                    OdorId= obj2.Data.OdorId,
                    OdorData = obj2.Data.OdorData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.OdorData),
                    RearArmrestId= obj2.Data.RearArmrestId,
                    RearArmrestData= obj2.Data.RearArmrestData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RearArmrestData),
                    RRCarpetId= obj2.Data.RRCarpetId,
                    RRCarpetData= obj2.Data.RRCarpetData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RRCarpetData),
                    ThirdRowSeatId= obj2.Data.ThirdRowSeatId,
                    ThirdRowSeatData= obj2.Data.ThirdRowSeatData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.ThirdRowSeatData),
                    RRSeatsLeftId = obj2.Data.RRSeatsLeftId,
                    RRSeatsLeftData= obj2.Data.RRSeatsLeftData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RRSeatsLeftData),
                    RRSeatsRightId= obj2.Data.RRSeatsRightId,
                    RRSeatsRightData= obj2.Data.RRSeatsRightData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.RRSeatsRightData),
                    SteeringWheelId= obj2.Data.SteeringWheelId,
                    SteeringWheelData= obj2.Data.SteeringWheelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorInteriorRatting) : new PartsDataViewModel(obj2.Data.SteeringWheelData),
                    Ratting = Convert.ToDouble(obj2.Data.Ratting),
                    EvaluatorRatting = obj2.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(obj2.Data.EvaluatorRatting),
                },
                Mechanics = new MechanicsViewModel
                {
                    PowerSteeringId = mechanicsData.Data.PowerSteeringId,
                    PowerSteeringData = mechanicsData.Data.PowerSteeringData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.PowerSteeringData),
                    ClimateControlId = mechanicsData.Data.ClimateControlId,
                    ClimateControlData  = mechanicsData.Data.ClimateControlData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.ClimateControlData),
                    FrontShockId = mechanicsData.Data.FrontShockId,
                    FrontShockData = mechanicsData.Data.FrontShockData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.FrontShockData),
                    FrontAxleId = mechanicsData.Data.FrontAxleId,
                    FrontAxleData = mechanicsData.Data.FrontAxleData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.FrontAxleData),
                    LFWheelId = mechanicsData.Data.LFWheelId,
                    LFWheelData = mechanicsData.Data.LFWheelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.LFWheelData),
                    TransmissionId = mechanicsData.Data.TransmissionId,
                    TransmissionData = mechanicsData.Data.TransmissionData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.TransmissionData),
                    BatteryId = mechanicsData.Data.BatteryId,
                    BatteryData = mechanicsData.Data.BatteryData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.BatteryData),
                    RearShocksId = mechanicsData.Data.RearShocksId,
                    RearShocksData = mechanicsData.Data.RearShocksData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RearShocksData),
                    RearAxleId = mechanicsData.Data.RearAxleId,
                    RearAxleData = mechanicsData.Data.RearAxleData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RearAxleData),
                    LRWheelId = mechanicsData.Data.LRWheelId,
                    LRWheelData = mechanicsData.Data.LRWheelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.LRWheelData),
                    ExhaustId = mechanicsData.Data.ExhaustId,
                    ExhaustData = mechanicsData.Data.ExhaustData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.ExhaustData),
                    LRWinMechanicsId = mechanicsData.Data.LRWinMechanicsId,
                    LRWinMechanicsData = mechanicsData.Data.LRWinMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.LRWinMechanicsData),
                    LFWinMechanicsId = mechanicsData.Data.LFWinMechanicsId,
                    LFWinMechanicsData = mechanicsData.Data.LFWinMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.LFWinMechanicsData),
                    LFDoorMechanicsId = mechanicsData.Data.LFDoorMechanicsId,
                    LFDoorMechanicsData = mechanicsData.Data.LFDoorMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.LFDoorMechanicsData),
                    LRDoorMechanicsId = mechanicsData.Data.LRDoorMechanicsId,
                    LRDoorMechanicsData = mechanicsData.Data.LRDoorMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.LRDoorMechanicsData),
                    RRDoorMechanicsId = mechanicsData.Data.RRDoorMechanicsId,
                    RRDoorMechanicsData = mechanicsData.Data.RRDoorMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RRDoorMechanicsData),
                    RFDoorMechanicsId = mechanicsData.Data.RFDoorMechanicsId,
                    RFDoorMechanicsData = mechanicsData.Data.RFDoorMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RFDoorMechanicsData),

                    RFWinMechanicsId = mechanicsData.Data.RFWinMechanicsId,
                    RFWinMechanicsData = mechanicsData.Data.RFWinMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RFWinMechanicsData),
                    RRWinMechanicsId = mechanicsData.Data.RRWinMechanicsId,
                    RRWinMechanicsData = mechanicsData.Data.RRWinMechanicsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RRWinMechanicsData),
                    EmissionId = mechanicsData.Data.EmissionId,
                    EmissionData = mechanicsData.Data.EmissionData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.EmissionData),
                    RearBreakId = mechanicsData.Data.RearBreakId,
                    RearBreakData = mechanicsData.Data.RearBreakData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RearBreakData),
                    RRWheelId = mechanicsData.Data.RRWheelId,
                    RRWheelData = mechanicsData.Data.RRWheelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RRWheelData),
                    ClutchId = mechanicsData.Data.ClutchId,
                    ClutchData = mechanicsData.Data.ClutchData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.ClutchData),

                    FrontBreakId = mechanicsData.Data.FrontBreakId,
                    FrontBreakData = mechanicsData.Data.FrontBreakData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.FrontBreakData),
                    RFWheelId = mechanicsData.Data.RFWheelId,
                    RFWheelData = mechanicsData.Data.RFWheelData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.RFWheelData),
                    EngineId = mechanicsData.Data.EngineId,
                    EngineData = mechanicsData.Data.EngineData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.EngineData),
                    ElectricsId = mechanicsData.Data.ElectricsId,
                    ElectricsData = mechanicsData.Data.ElectricsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.ElectricsData),
                    SpareTypeId = mechanicsData.Data.SpareTypeId,
                    SpareTypeData = mechanicsData.Data.SpareTypeData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.SpareTypeData),
                    FuelTankId = mechanicsData.Data.FuelTankId,
                    FuelTankData = mechanicsData.Data.FuelTankData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.FuelTankData),

                    WarningLightsId = mechanicsData.Data.WarningLightsId,
                    WarningLightsData = mechanicsData.Data.WarningLightsData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.WarningLightsData),
                    ToolsJacksId = mechanicsData.Data.ToolsJacksId,
                    ToolsJacksData = mechanicsData.Data.ToolsJacksData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorMechanicsRatting) : new PartsDataViewModel(mechanicsData.Data.ToolsJacksData),
                    Ratting = Convert.ToDouble(mechanicsData.Data.Ratting),
                    EvaluatorRatting = mechanicsData.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(mechanicsData.Data.EvaluatorRatting),
                },
                Frame = new FrameViewModel
                {
                    Ratting = Convert.ToDouble(obj4.Data.Ratting),
                    CowlPanelFirewallData = obj4.Data.CowlPanelFirewallData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.CowlPanelFirewallData),
                    CowlPanelFirewallId = obj4.Data.CowlPanelFirewallId,
                    LeftAPillarData = obj4.Data.LeftAPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftAPillarData),
                    LeftAPillarId = obj4.Data.LeftAPillarId,
                    LeftApronData = obj4.Data.LeftApronData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftApronData),
                    LeftApronId = obj4.Data.LeftApronId,
                    LeftBPillarData = obj4.Data.LeftBPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftBPillarData),
                    LeftBPillarId = obj4.Data.LeftBPillarId,
                    LeftCPillarData = obj4.Data.LeftCPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftCPillarData),
                    LeftCPillarId = obj4.Data.LeftCPillarId,
                    LeftDPillarData = obj4.Data.LeftDPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftDPillarData),
                    LeftDPillarId = obj4.Data.LeftDPillarId,
                    LeftFrontRailData = obj4.Data.LeftFrontRailData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftFrontRailData),
                    LeftFrontRailId = obj4.Data.LeftFrontRailId,
                    LeftRearLockPillarData = obj4.Data.LeftRearLockPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftRearLockPillarData),
                    LeftRearLockPillarId = obj4.Data.LeftRearLockPillarId,
                    LeftRearRailData = obj4.Data.LeftRearRailData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftRearRailData),
                    LeftRearRailId = obj4.Data.LeftRearRailId,
                    LeftStrutTowerApronData = obj4.Data.LeftStrutTowerApronData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.LeftStrutTowerApronData),
                    LeftStrutTowerApronId = obj4.Data.LeftStrutTowerApronId,
                    PerimeterFrameData = obj4.Data.PerimeterFrameData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.PerimeterFrameData),
                    PerimeterFrameId = obj4.Data.PerimeterFrameId,
                    RadiatorCoreSupportData = obj4.Data.RadiatorCoreSupportData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RadiatorCoreSupportData),
                    RadiatorCoreSupportId = obj4.Data.RadiatorCoreSupportId,
                    RightAPillarData = obj4.Data.RightAPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RightAPillarData),
                    RightAPillarId = obj4.Data.RightAPillarId,
                    RightApronData = obj4.Data.RightApronData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RightApronData),
                    RightApronId = obj4.Data.RightApronId,
                    RightBPillarData = obj4.Data.RightBPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RightBPillarData),
                    RightBPillarId = obj4.Data.RightBPillarId,
                    RightCPillarData = obj4.Data.RightCPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RightCPillarData),
                    RightCPillarId = obj4.Data.RightCPillarId,
                    RightDPillarData = obj4.Data.RightDPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RightDPillarData),
                    RightDPillarId = obj4.Data.RightDPillarId,
                    RIGHTFRONTRAILData = obj4.Data.RIGHTFRONTRAILData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RIGHTFRONTRAILData),
                    RIGHTFRONTRAILId = obj4.Data.RIGHTFRONTRAILId,
                    RightRearLockPillarData = obj4.Data.RightRearLockPillarData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RightRearLockPillarData),
                    RightRearLockPillarId = obj4.Data.RightRearLockPillarId,
                    RightRearRailData = obj4.Data.RightRearRailData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RightRearRailData),
                    RightRearRailId = obj4.Data.RightRearRailId,
                    RSTRUTTWRAPRData = obj4.Data.RSTRUTTWRAPRData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.RSTRUTTWRAPRData),
                    RSTRUTTWRAPRId = obj4.Data.RSTRUTTWRAPRId,
                    FloorPansData = obj4.Data.FloorPansData == null ? new PartsDataViewModel(vehicleWizard.EvaluatorFrameRatting) : new PartsDataViewModel(obj4.Data.FloorPansData),
                    FloorPansId = obj4.Data.FloorPansId,
                    EvaluatorRatting = obj4.Data.EvaluatorRatting == null ? 0.0 : Convert.ToDouble(obj4.Data.EvaluatorRatting),
                },
                Flag = flagOptions.Data.List,
                Otions=optonsList.Data.List,
                MoreOption= optonsList.Data.MoreOptions,
                FlagMoreOption= flagOptions.Data.MoreFlags,
                Locations=new VIRRepository().LoadVehicleAddress(id).Data,
                Ratting= Convert.ToDouble(obj4.Data.TotalRatting),
              

        };
           
            return View(model);

        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname = "";

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            if (file != null)
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                            }
                        }
                        else
                        {
                            if (file != null) fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/VehicleAttachments/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public JsonResult AddUpdateVehicleVideo(VehicleVideoViewModel model)
        {
            try
            {
                var result = new VIRRepository().AddUpdateVehicleVideo(model);
                return (Json(new { Success = result.Result, Message = result.Message, data=result.Data, VideoId = result.RecordID }, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving Video. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public JsonResult RemoveVehicleVideo(int videoId) 
        {
            try
            {
                var result = new VIRRepository().RemoveVehicleVideo(videoId);
                return (Json(new { Success = result.Result, Message = result.Message }, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in removing Video. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public JsonResult UpdateEvaluatorRatting(long vehicleId, VIRPartType virPartType, double ratting)
        {
            try
            {
                var result = new VIRRepository().UpdateEvaluatorRatting(vehicleId, virPartType, ratting);
                return (Json(new { Success = result.Result, Message = result.Message }, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in updating ratting. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }


        [HttpPost]
        public JsonResult UploadImagesForVehicle()
        {
            try
            {
                var id = Convert.ToInt32(Request.Form["id"]);
                if (Request.Files.Count > 0)
                {
                    var lstResult = new List<VehicleImage>();
                    var isFileSaved = true;
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            var extention = Path.GetExtension(file.FileName); // retur
                            var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                         DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                            fileName = fileName + date + extention;
                            var path = Path.Combine(Server.MapPath("~/VehicleAttachments/"), fileName);
                            file.SaveAs(path);

                            VehicleImage img = new VehicleImage();
                            img.ImagePath = fileName;
                            img.VehicleID = id;
                            img.CreatedBy = 1;
                            img.DisplayOrder = db.VehicleImages.FirstOrDefault(a => a.VehicleID == id && a.DisplayOrder > 0) == null ? 1 : 0;
                            img.UpdatedBy = 1;
                            img.CreatedDate = DateTime.Now;
                            img.UpdatedDate = DateTime.Now;
                            db.VehicleImages.Add(img);
                            db.SaveChanges();
                            lstResult.Add(img);
                        }
                    }

                    lstResult.ForEach(a => a.ImagePath = Path.Combine("VehicleAttachments/", a.ImagePath));

                    return Json(new { Success = true, Message = "File Saved", data = lstResult }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
                }
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public JsonResult SaveFlag(VehicleOptionsSaveModel model)
        {
            try
            {

                new VIRRepository().SaveVIRFlags(model);
                return (Json(new { Success = true, Message = "Flag information Saved" }, JsonRequestBehavior.AllowGet));

            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }
        public JsonResult SaveOptions(VehicleOptionsSaveModel model)
        {
            try
            {

                new VIRRepository().SaveVIROption(model);
                return (Json(new { Success = true, Message = "Option Save" }, JsonRequestBehavior.AllowGet));

            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }
        [HttpPost]
        public JsonResult SaveInfo(CarInfo model)
        {
            try
            {
                VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == model.VehcileId);
                if (vehicleWizard != null)
                {
                    if (string.IsNullOrEmpty(model.PlateNumber) && model.AutoUsedStatusID == 4) // 4 is the status of used
                    {
                        throw new Exception("Empty plate number can not be in USED status.");
                    }

                    if (!string.IsNullOrEmpty(model.PlateNumber) && model.PlateNumber.Trim().ToLower().Equals("vcc") && model.AutoUsedStatusID == 4) // 4 is the status of used
                    {
                        throw new Exception("Plate number with VCC can not be in USED status.");
                    }

                    if (!string.IsNullOrEmpty(model.PlateNumber) && !model.PlateNumber.Trim().ToLower().Equals("vcc") && model.AutoUsedStatusID == 3) // 4 is the status of used
                    {
                        throw new Exception("Vehicle with plate number can not be in NEW status.");
                    }

                    vehicleWizard.PlateNumber = model.PlateNumber;
                    
                    if (model.DoorsId > 0)
                        vehicleWizard.AutoDoorsID = model.DoorsId;
                    if (model.EngineId > 0)
                        vehicleWizard.AutoEngineID = model.EngineId;
                    if (model.ExteriorColorId > 0)
                        vehicleWizard.AutoExteriorColorID = model.ExteriorColorId;
                    if (model.InteriorColorId > 0)
                        vehicleWizard.AutoInteriorColorID = model.InteriorColorId;
                    if (model.ModelId > 0)
                        vehicleWizard.AutoModelID = model.ModelId;
                    if (model.SteeringId > 0)
                        vehicleWizard.AutoSteeringID = model.SteeringId;
                    if (model.TransmissionId > 0)
                        vehicleWizard.AutoTransmissionID = model.TransmissionId;
                    if (model.DriveTypeId > 0)
                        vehicleWizard.DriveTypeID = model.DriveTypeId;
                    if (model.FuelTypeId > 0)
                        vehicleWizard.FuelTypeID = model.FuelTypeId;
                    
                    if (model.MakerId > 0)
                        vehicleWizard.MakerID = model.MakerId;
                    if (model.YearId > 0)
                        vehicleWizard.YearID = model.YearId;
                    if (model.AutoAirBagId > 0)
                        vehicleWizard.AutoAirBagID = model.AutoAirBagId;
                    if (model.AudioId > 0)
                        vehicleWizard.VehicleAudioID = model.AudioId;
                    
                    
                    if (model.RoofTypeID > 0)
                        vehicleWizard.RoofTypeID = model.RoofTypeID;
                    if (model.SubModelID > 0)
                        vehicleWizard.SubModelID = model.SubModelID;
                    if (model.UpholsteryID > 0)
                        vehicleWizard.UpholsteryID = model.UpholsteryID;
                    vehicleWizard.Odometer = model.Odometer;
                    vehicleWizard.VIN = model.VIN;
                    vehicleWizard.StockNumber = model.StockNumber;
                    vehicleWizard.FreeText = model.FreeText;
                    vehicleWizard.ArabicFreeText = model.ArabicFreeText;
                    vehicleWizard.Has360 = model.Has360;
                    if (model.InventoryStatusId > 0)
                    {
                        long userId = 1;
                        try
                        {
                            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
                            userId = user.UserID;
                        }
                        catch (Exception ex)
                        {

                        }

                        // add status change history
                        new UtilityRepository().AddInventoryStatusHistory(userId, vehicleWizard.VehicleID, vehicleWizard.InventoryStatusID, model.InventoryStatusId);
                        vehicleWizard.InventoryStatusID = model.InventoryStatusId;
                    }
                    if (model.VehicleTypeId > 0)
                        vehicleWizard.VehicleTypeID = model.VehicleTypeId;
                    if (model.AutoUsedStatusID > 0)
                        vehicleWizard.AutoUsedStatusID = model.AutoUsedStatusID;
                    if (model.Price > 0)
                        vehicleWizard.VehiclePrice = model.Price;
                    else
                        vehicleWizard.VehiclePrice = 0;
                    if (model.PurchasingCost > 0)
                        vehicleWizard.PurchasingCost = model.PurchasingCost;
                    else
                        vehicleWizard.PurchasingCost = 0;

                    //if (!string.IsNullOrEmpty(model.DealerID))
                    //    vehicleWizard.DealerID = model.DealerID;

                    db.SaveChanges();
                }
                else
                {
                    return (Json(new { Success = false, Message = "No vehicle found for id = " + model.VehcileId }, JsonRequestBehavior.AllowGet));
                }

                return (Json(new { Success = true, Message = "File Saved" }, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet));
            }
        }

        [HttpPost]
        public JsonResult UploadImagesForVehiclePart()
        {
            try
            {
                var vehiclePartId = Convert.ToInt32(Request.Form["part_id"]);
                var vehicleId = Convert.ToInt32(Request.Form["vehicleId"]);
                if (Request.Files.Count > 0)
                {
                    var lstResult = new List<VehiclePartImage>();
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            var extention = Path.GetExtension(file.FileName); // retur
                            var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                            DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                            fileName = fileName + date + extention;
                            var path = Path.Combine(Server.MapPath("~/VehicleAttachments/VehicleParts/"), fileName);
                            file.SaveAs(path);


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

                            //lstResult.Add(img);
                        }
                    }

                    lstResult.ForEach(a => a.ImagePath = Path.Combine("VehicleAttachments/VehicleParts/", a.ImagePath));

                    return Json(new { Success = true, Message = "File Saved", data = lstResult }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
                }
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }
        public JsonResult LoadPargImages(long vehicleId, int vehiclePartId)
        {
            try
            {


                var obj = new VIRRepository().LoadVehiclePartImages(vehicleId, vehiclePartId, "VehicleAttachments/VehicleParts/");
                var drop = new VIRRepository().LoadVIRPartConditionSeverityLevels(vehiclePartId);
                return Json(new { Success = true, data = new { images = obj.Data, Conditions = drop.Data } }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }

        public JsonResult SavePartInfo(VehicleParts model)
        {
            if (model == null)
            {
                return (Json(new { Success = false, Message = "Error in Saving Record. Try Again" }, JsonRequestBehavior.AllowGet));
            }

            try
            {
                var obj = new VIR();
               
                obj.Condition = model.Condition;
                obj.Description = model.Description;
                obj.fkPartId = model.fkPartId;
                //obj.fkUserId = model.fkUserId;
                obj.fkVehickeId = model.fkVehickeId;
                //obj.Part = model.Part;
                obj.Id = model.Id;
                //obj.Ratting = model.Ratting;
                obj.Severity = model.Severity;

                var result = new VIRRepository().AddUpdateVIRPartInformation(obj);
                if (result.Result == true)
                {
                    return (Json(new { Success = true, Message = "Saved successfully.", data= result }, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    return (Json(new { Success = false, Message = "Error in Saving File. Try Again", data = result }, JsonRequestBehavior.AllowGet));
                }
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again"}, JsonRequestBehavior.AllowGet));
            }
        }
        public JsonResult SaveVehicleAddress(VehicleAddressViewModel model)
        {
            try
            {

               var result= new VIRRepository().AddVehicleAddress(model);
               return Json(new { Success = result.Result, Message= result.Message, data = result }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in Saving File. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }

        public JsonResult RemoveVehicleImage(int imageId)
        {
            try
            {
                var result = new VIRRepository().RemoveVehicleImage(imageId);
                if (result.Result)
                {
                    return Json(new { Success = true, data = result }, JsonRequestBehavior.AllowGet);
                }
                else
                    throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in removing image. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }

        public JsonResult RemoveVehiclePartImage(int imageId)
        {
            try
            { 
                var result = new VIRRepository().RemoveVehiclePartImage(imageId);
                if (result.Result)
                {
                    return Json(new { Success = true, data = result }, JsonRequestBehavior.AllowGet);
                }
                else
                    throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "Error in removing image. Try Again" }, JsonRequestBehavior.AllowGet));
            }
        }
        [HttpGet]
        public JsonResult LoadModel(int MakerId)
        {
            var t = db.Makers.Where(x => x.MakerID == MakerId).FirstOrDefault();
            var data = from a in db.AutoModels.Where(x => x.MakerID == t.MakerID)
                       select new
                       {
                           Name = a.ModelName,
                           Id = a.AutoModelID
                       };
            return (Json(new { Success = true, data = data }, JsonRequestBehavior.AllowGet));

        }

        public ActionResult Print(int vehicleId)
        {
            InventoryRespository rep = new InventoryRespository();
            var veh = rep.GetInventoryViewModelDetail(vehicleId).Data as VehicleViewModel;
            ViewBag.Url = WebConfigurationManager.AppSettings["websiteUrl"];

            string code =ViewBag.Url + vehicleId;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            QRCode qrCode = new QRCode(qrCodeData);

            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                ViewBag.QRCode = imgBarCode.ImageUrl;
            }
           
            return View(veh);
        }
        public JsonResult GetImageURLFromFTP()
        {
            try
            {
                var path = Path.Combine(Server.MapPath("~/VehicleAttachments/"));
                var lst = new UtilityRepository().GetImageURLFromFTP(path);
                return Json(new { Success =true, Message = "", data = lst }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return (Json(new { Success = false, Message = "" }, JsonRequestBehavior.AllowGet));
            }
        }
    }

}