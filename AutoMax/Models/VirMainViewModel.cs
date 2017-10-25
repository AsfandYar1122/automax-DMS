using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMax.Models.Entities;

namespace AutoMax.Models
{
    public class VirMainViewModel
    {
        public CarInformationViewModel Information { get; set; }
        public VirViewModel Vir { get; set; }
        public string VehicleImage { get; set; }

        public bool IsMarketingUser { get; set; }

    }
    public class VirViewModel
    {
        public ExteriorViewModel Exterior { get; set; }
        public InteriorViewModel Interior { get; set; }
        public double Ratting { get; set; }
        public MechanicsViewModel Mechanics { get; set; }
        public FrameViewModel Frame { get; set; }
        public List<VIRFlagPropertiesViewModel> Flag { get; set; }
        public string FlagMoreOption { get; set; }
        public List<VIROptionsPropertiesViewModelGroupData> Otions { get; set; }
        public string MoreOption { get; set; }
        public List<VehicleAddressViewModel> Locations { get; set; }

    }
    public class ExteriorViewModel
    {
        public double Ratting { get; set; }
        public double EvaluatorRatting { get; set; }
        public int HeadlightId { get; set; }
        public PartsDataViewModel HeadlightData { get; set; }
        public int GrillId { get; set; }
        public PartsDataViewModel GrillData { get; set; }
        public int HoodId { get; set; }
        public PartsDataViewModel HoodData { get; set; }
        public int LeftFenderId { get; set; }
        public PartsDataViewModel LeftFenderData { get; set; }
        public int LinerLFRFId { get; set; }
        public PartsDataViewModel LinerLFRFData { get; set; }
        public int WindshieldId { get; set; }
        public PartsDataViewModel WindshieldData { get; set; }
        public int LFDoorId { get; set; }
        public PartsDataViewModel LFDoorData { get; set; }
        public int LRockerPanelId { get; set; }
        public PartsDataViewModel LRockerPanelData { get; set; }
        public int LRdoorId { get; set; }
        public PartsDataViewModel LRdoorData { get; set; }
        public int LeftQuarterPanelId { get; set; }
        public PartsDataViewModel LeftQuarterPanelData { get; set; }
        public int RearWindowId { get; set; }
        public PartsDataViewModel RearWindowData { get; set; }
        public int LeftBedSideId { get; set; }
        public PartsDataViewModel LeftBedSideData { get; set; }
        public int ConvertibleTopId { get; set; }
        public PartsDataViewModel ConvertibleTopData { get; set; }
        public int TrailGateId { get; set; }
        public PartsDataViewModel TrailGateData { get; set; }
        public int RightBedSideId { get; set; }
        public PartsDataViewModel RightBedSideData { get; set; }
        public int TailLightId { get; set; }
        public PartsDataViewModel TailLightData { get; set; }
        public int DeckLidId { get; set; }
        public PartsDataViewModel DeckLidData { get; set; }
        public int RightQuarterPanelId { get; set; }
        public PartsDataViewModel RightQuarterPanelData { get; set; }
        public int RRockerPanelId { get; set; }
        public PartsDataViewModel RRockerPanelData { get; set; }
        public int RRDoorId { get; set; }
        public PartsDataViewModel RRDoorData { get; set; }
        public int RoofId { get; set; }
        public PartsDataViewModel RoofData { get; set; }
        public int RFDoorId { get; set; }
        public PartsDataViewModel RFDoorData { get; set; }
        public int FrontBumperId { get; set; }
        public PartsDataViewModel FrontBumperData { get; set; }
        public int BumperGrillId { get; set; }
        public PartsDataViewModel BumperGrillData { get; set; }
        public int LMUDGuardId { get; set; }
        public PartsDataViewModel LMUDGuardData { get; set; }
        public int RightFenderId { get; set; }
        public PartsDataViewModel RightFenderData { get; set; }
        public int RMudGuardId { get; set; }
        public PartsDataViewModel RMudGuardData { get; set; }
        public int WIPERSId { get; set; }
        public PartsDataViewModel WIPERSData { get; set; }

        public int LeftMirrorId { get; set; }
        public PartsDataViewModel LeftMirrorData { get; set; }
        public int RightMirrorId { get; set; }
        public PartsDataViewModel RightMirrorData { get; set; }
        public int AnteenaId { get; set; }
        public PartsDataViewModel AnteenaData { get; set; }
        public int BackScreenId { get; set; }
        public PartsDataViewModel BackScreenData { get; set; }
        public int TRUNKCARGOId { get; set; }
        public PartsDataViewModel TRUNKCARGOData { get; set; }
        public int RREARLIGHTId { get; set; }
        public PartsDataViewModel RREARLIGHTData { get; set; }
        public int TAILERHITCHId { get; set; }
        public PartsDataViewModel TAILERHITCHData { get; set; }
        public int REARBUMPERId { get; set; }
        public PartsDataViewModel REARBUMPERData { get; set; }
        public int SunRoofID { get; set; }
        public PartsDataViewModel SunRoofData { get; set; }

        public int RightDoorID { get; set; }
        public PartsDataViewModel RightDoorData { get; set; }
        public int LeftDoorID { get;  set; }
        public PartsDataViewModel LeftDoorData { get;  set; }
    }
    public class InteriorViewModel
    {
        public double EvaluatorRatting { get; set; }
        public double Ratting { get; set; }
        public int RearViewMirrorId { get; set; }
        public PartsDataViewModel RearViewMirrorData { get; set; }
        public int GaugesId { get; set; }
        public PartsDataViewModel GaugesData { get; set; }

        public int AirBagId { get; set; }
        public PartsDataViewModel AirBagData { get; set; }
        public int ShiftKnobId { get; set; }
        public PartsDataViewModel ShiftKnobData { get; set; }

        public int LFDoorPanelId { get; set; }
        public PartsDataViewModel LFDoorPanelData { get; set; }
        public int RHFRTSeatId { get; set; }
        public PartsDataViewModel RHFRTSeatData { get; set; }

        public int LHFRTSeatId { get; set; }
        public PartsDataViewModel LHFRTSeatData { get; set; }

        public int FrCarpetId { get; set; }
        public PartsDataViewModel FrCarpetData { get; set; }

        public int LRDoorPanelId { get; set; }
        public PartsDataViewModel LRDoorPanelData { get; set; }

        public int RRSeatsLeftId { get; set; }
        public PartsDataViewModel RRSeatsLeftData { get; set; }
        public int RRSeatsRightId { get; set; }
        public PartsDataViewModel RRSeatsRightData { get; set; }
        public int HeadLinerId { get; set; }
        public PartsDataViewModel HeadLinerData { get; set; }
        public int RFDoorPanelId { get; set; }
        public PartsDataViewModel RFDoorPanelData { get; set; }
        public int RRDoorPanelId { get; set; }
        public PartsDataViewModel RRDoorPanelData { get; set; }
        public int LampId { get; set; }
        public PartsDataViewModel LampData { get; set; }
        public int RadioId { get; set; }
        public PartsDataViewModel RadioData { get; set; }

        public int ConsoleId { get; set; }
        public PartsDataViewModel ConsoleData { get; set; }
        public int GloveBoxId { get; set; }
        public PartsDataViewModel GloveBoxData { get; set; }
        public int ThirdRowSeatId { get; set; }
        public PartsDataViewModel ThirdRowSeatData { get; set; }
        public int OdorId { get; set; }
        public PartsDataViewModel OdorData { get; set; }
        public int ManualsId { get; set; }
        public PartsDataViewModel ManualsData { get; set; }
        public int FeaturesId { get; set; }
        public PartsDataViewModel FeaturesData { get; set; }
        public int InteriorPartsId { get; set; }
        public PartsDataViewModel InteriorPartsData { get; set; }
        public int SteeringWheelId { get; set; }
        public PartsDataViewModel SteeringWheelData { get; set; }
        public int FourthRowSeatId { get; set; }
        public PartsDataViewModel FourthRowSeatData { get; set; }

        public int RearArmrestId { get; set; }
        public PartsDataViewModel RearArmrestData { get; set; }
        public int LRCarpetId { get; set; }
        public PartsDataViewModel LRCarpetData { get; set; }

        public int RRCarpetId { get; set; }
        public PartsDataViewModel RRCarpetData { get; set; }

        public int RrSeatsId { get; set; }
        public PartsDataViewModel RrSeatsData { get; set; }
        public int DashId { get; set; }
        public PartsDataViewModel DashData { get; set; }

    }
    public class MechanicsViewModel
    {
        public double EvaluatorRatting { get; set; }
        public int PowerSteeringId { get; set; }
        public PartsDataViewModel PowerSteeringData { get; set; }
        public int ClimateControlId { get; set; }
        public PartsDataViewModel ClimateControlData { get; set; }
        public int FrontShockId { get; set; }
        public PartsDataViewModel FrontShockData { get; set; }
        public int FrontAxleId { get; set; }
        public PartsDataViewModel FrontAxleData { get; set; }
        public int LFWheelId { get; set; }
        public PartsDataViewModel LFWheelData { get; set; }
        public int TransmissionId { get; set; }
        public PartsDataViewModel TransmissionData { get; set; }
        public int BatteryId { get; set; }
        public PartsDataViewModel BatteryData { get; set; }
        public int RearShocksId { get; set; }
        public PartsDataViewModel RearShocksData { get; set; }
        public int RearAxleId { get; set; }
        public PartsDataViewModel RearAxleData { get; set; }
        public int LRWheelId { get; set; }
        public PartsDataViewModel LRWheelData { get; set; }
        public int ExhaustId { get; set; }
        public PartsDataViewModel ExhaustData { get; set; }
        public int LRWinMechanicsId { get; set; }
        public PartsDataViewModel LRWinMechanicsData { get; set; }
        public int LFWinMechanicsId { get; set; }
        public PartsDataViewModel LFWinMechanicsData { get; set; }
        public int LFDoorMechanicsId { get; set; }
        public PartsDataViewModel LFDoorMechanicsData { get; set; }
        public int LRDoorMechanicsId { get; set; }
        public PartsDataViewModel LRDoorMechanicsData { get; set; }
        public int RRDoorMechanicsId { get; set; }
        public PartsDataViewModel RRDoorMechanicsData { get; set; }
        public int RFDoorMechanicsId { get; set; }
        public PartsDataViewModel RFDoorMechanicsData { get; set; }
        public int RFWinMechanicsId { get; set; }
        public PartsDataViewModel RFWinMechanicsData { get; set; }
        public int RRWinMechanicsId { get; set; }
        public PartsDataViewModel RRWinMechanicsData { get; set; }
        public int EmissionId { get; set; }
        public PartsDataViewModel EmissionData { get; set; }
        public int RearBreakId { get; set; }
        public PartsDataViewModel RearBreakData { get; set; }
        public int RRWheelId { get; set; }
        public PartsDataViewModel RRWheelData { get; set; }
        public int ClutchId { get; set; }
        public PartsDataViewModel ClutchData { get; set; }
        public int FrontBreakId { get; set; }
        public PartsDataViewModel FrontBreakData { get; set; }
        public int RFWheelId { get; set; }
        public PartsDataViewModel RFWheelData { get; set; }
        public int EngineId { get; set; }
        public PartsDataViewModel EngineData { get; set; }
        public int ElectricsId { get; set; }
        public PartsDataViewModel ElectricsData { get; set; }
        public int SpareTypeId { get; set; }
        public PartsDataViewModel SpareTypeData { get; set; }
        public int FuelTankId { get; set; }
        public PartsDataViewModel FuelTankData { get; set; }
        public int WarningLightsId { get; set; }
        public PartsDataViewModel WarningLightsData { get; set; }
        public int ToolsJacksId { get; set; }
        public PartsDataViewModel ToolsJacksData { get; set; }
        public double Ratting { get; set; }
    }
        public class PartsDataViewModel
    {


        public PartsDataViewModel(double? ratting)
        {
            if (ratting != null && ratting != 0 && ratting !=0.0)
            {
                Ratting = Convert.ToDouble(ratting);
            }
            else
            {
                Ratting = 4;
            }
        }
        public PartsDataViewModel(dynamic data)
        {
            Condition = data.Condition;
            CostOfRepair = data.CostOfRepair;
            CostOfReplacement = data.CostOfReplacement;
            Description = data.Description;
            EstimatedRepairCost = data.EstimatedRepairCost;
            fkPartId = data.fkPartId;
            fkUserId = data.fkUserId;
            fkVehickeId = data.fkVehickeId;
            Part = data.Part;
            Id = data.Id;
            Ratting = data.Ratting;
            Severity = data.Severity;
            ImagePath = data.ImagePath;
            ArabicCondition = data.ArabicCondition;
        }

        public int Id { get; set; }
        public int fkVehickeId { get; set; }
        public int fkUserId { get; set; }
        public int fkPartId { get; set; }
        public string Condition { get; set; }
        public string Part { get; set; }
        public double Severity { get; set; }
        public string Description { get; set; }
        public string CostOfRepair { get; set; }
        public string CostOfReplacement { get; set; }
        public string EstimatedRepairCost { get; set; }
        public double Ratting { get; set; }
        public string ImagePath { get; set; }
        public dynamic ArabicCondition { get; set; }
    }
    public class FrameViewModel
    {
        public double Ratting { get; set; }
        public double EvaluatorRatting { get; set; }
        public int PerimeterFrameId { get; set; }
        public int RightRearRailId { get; set; }
        public int RadiatorCoreSupportId { get; set; }
        public int LeftFrontRailId { get; set; }
        public int LeftApronId { get; set; }
        public int LeftStrutTowerApronId { get; set; }
        public int CowlPanelFirewallId { get; set; }
        public int LeftAPillarId { get; set; }
        public int LeftBPillarId { get; set; }
        public int LeftCPillarId { get; set; }
        public int LeftDPillarId { get; set; }
        public int RightAPillarId { get; set; }
        public int RightBPillarId { get; set; }
        public int RightCPillarId { get; set; }
        public int RightDPillarId { get; set; }
        public int LeftRearRailId { get; set; }
        public int LeftRearLockPillarId { get; set; }
        public int RightRearLockPillarId { get; set; }
        public int RIGHTFRONTRAILId { get; set; }
        public int RightApronId { get; set; }
        public int RSTRUTTWRAPRId { get; set; }
        public int FloorPansId { get; set; }
        
        public PartsDataViewModel PerimeterFrameData { get; set; }
        public PartsDataViewModel RightRearRailData { get; set; }
        public PartsDataViewModel RadiatorCoreSupportData { get; set; }
        public PartsDataViewModel LeftFrontRailData { get; set; }
        public PartsDataViewModel LeftApronData { get; set; }
        public PartsDataViewModel LeftStrutTowerApronData { get; set; }
        public PartsDataViewModel CowlPanelFirewallData { get; set; }
        public PartsDataViewModel LeftAPillarData { get; set; }
        public PartsDataViewModel LeftBPillarData { get; set; }
        public PartsDataViewModel LeftCPillarData { get; set; }
        public PartsDataViewModel LeftDPillarData { get; set; }
        public PartsDataViewModel RightAPillarData { get; set; }
        public PartsDataViewModel RightBPillarData { get; set; }
        public PartsDataViewModel RightCPillarData { get; set; }
        public PartsDataViewModel RightDPillarData { get; set; }
        public PartsDataViewModel LeftRearRailData { get; set; }
        public PartsDataViewModel LeftRearLockPillarData { get; set; }
        public PartsDataViewModel RightRearLockPillarData { get; set; }
        public PartsDataViewModel RIGHTFRONTRAILData { get; set; }
        public PartsDataViewModel RightApronData { get; set; }
        public PartsDataViewModel RSTRUTTWRAPRData { get; set; }
        public PartsDataViewModel FloorPansData { get; set; }

        
    }
    public class CarInformationViewModel
    {
        public SelectList AutoBodyStyleID { get; set; }
        public SelectList RoofTypeID { get; set; }
        public SelectList UpholsteryID { get; set; }
        public SelectList AutoConditionID { get; set; }

        public SelectList AutoDoorsID { get; set; }

        public SelectList AutoEngineID { get; set; }

        public SelectList AutoExteriorColorID { get; set; }

        public SelectList AutoInteriorColorID { get; set; }

        public SelectList AutoModelID { get; set; }

        public SelectList AutoSteeringID { get; set; }

        public SelectList AutoTransmissionID { get; set; }

        public SelectList DriveTypeID { get; set; }

        public SelectList FuelTypeID { get; set; }

        public SelectList InventoryStatusID { get; set; }

        public SelectList MakerID { get; set; }
        
        public SelectList YearID { get; set; }
        
        public SelectList AutoAirBagID { get; set; }
        public SelectList SubModelID { get; set; }
        
        public SelectList EngineCapacityID { get; set; }
        public SelectList VehicleWheelID { get; set; }
        public SelectList WheelId { get; set; }
        public SelectList VehicleAudioID { get; set; }
       
        public SelectList VehicleInteriorTypeID { get; set; }
      
        public SelectList VehicleTopStyleID { get; set; }
        public SelectList VehicleTypeId { get; set; }

        public string Odometer { get; set; }
        public string VIN { get; set; }
        public string StockNumber { get; set; }
        public string FreeText { get; set; }
        public bool Has360 { get; set; }
        public SelectList AutoUsedStatusID { get; set; }
        public string PlateNumber { get; set; }
        public decimal Price { get; set; }
        public string Mileage { get; set; }
        public decimal PurchasingCost { get; set; }
        public string DealerID { get; set; }

        public string ArabicWarantyText { get; set; }
        public string ArabicDescription { get; set; }
        public string ArabicFreeText { get; set; }
    }

    public class VehicleParts
    {
        public int Id { get; set; }
        public int fkVehickeId { get; set; }
        public int fkPartId { get; set; }
        public string Condition { get; set; }
        public double Severity { get; set; }
        public string Description { get; set; }
        
    }
    
}