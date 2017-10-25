using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class VehicleWizard
    {
        [Key]
        public long VehicleID { get; set; }
        public Nullable<int> InventoryStatusID { get; set; }
        [ForeignKey("InventoryStatusID")]
        public InventoryStatus InventoryStatus { get; set; }
        public string StockNumber { get; set; }
        public string MMCode { get; set; }
        public string PlateNumber { get; set; }
        public Nullable<int> AutoConditionID { get; set; }
        [ForeignKey("AutoConditionID")]
        public AutoCondition AutoCondition { get; set; }
        public string VIN { get; set; }
        public Nullable<int> YearID { get; set; }
        [ForeignKey("YearID")]
        public Year Year { get; set; }
        public Nullable<int> MakerID { get; set; }
        [ForeignKey("MakerID")]
        public Maker Maker { get; set; }
        public Nullable<int> AutoModelID { get; set; }
        [ForeignKey("AutoModelID")]
        public AutoModel AutoModel { get; set; }
        public Nullable<int> SubModelID { get; set; }
        [ForeignKey("SubModelID")]
        public SubModel SubModel { get; set; }
        public string FreeText { get; set; }
        public Nullable<int> AutoBodyStyleID { get; set; }
        [ForeignKey("AutoBodyStyleID")]
        public AutoBodyStyle AutoBodyStyle { get; set; }
        public string Odometer { get; set; }
        public Nullable<long> AutoExteriorColorID { get; set; }
        [ForeignKey("AutoExteriorColorID")]
        public AutoExteriorColor AutoExteriorColor { get; set; }
        public Nullable<long> AutoInteriorColorID { get; set; }
        [ForeignKey("AutoInteriorColorID")]
        public AutoInteriorColor AutoInteriorColor { get; set; }
        public Nullable<long> AutoSteeringID { get; set; }
        [ForeignKey("AutoSteeringID")]
        public AutoSteering AutoSteering { get; set; }
        public Nullable<long> AutoDoorsID { get; set; }
        [ForeignKey("AutoDoorsID")]
        public AutoDoor AutoDoor { get; set; }
        public Nullable<long> AutoEngineID { get; set; }
        [ForeignKey("AutoEngineID")]
        public AutoEngine AutoEngine { get; set; }
        public Nullable<long> AutoTransmissionID { get; set; }
        [ForeignKey("AutoTransmissionID")]
        public AutoTransmission AutoTransmission { get; set; }
        public Nullable<long> FuelTypeID { get; set; }
        [ForeignKey("FuelTypeID")]
        public FuelType FuelType { get; set; }
        public Nullable<long> DriveTypeID { get; set; }
        [ForeignKey("DriveTypeID")]
        public DriveType DriveType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Nullable<decimal> VehiclePrice { get; set; }
        public string WarantyText { get; set; }
        public string Description { get; set; }
        public long UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        public Nullable<int> AutoAirBagID { get; set; }
        [ForeignKey("AutoAirBagID")]
        public AutoAirBag AutoAirBag { get; set; }
        public Nullable<int> EngineCapacityID { get; set; }
        [ForeignKey("EngineCapacityID")]
        public EngineCapacity EngineCapacity { get; set; }
        public Nullable<int> UpholsteryID { get; set; }
        [ForeignKey("UpholsteryID")]
        public Upholstery Upholstery { get; set; }
        public Nullable<int> RoofTypeID { get; set; }
        [ForeignKey("RoofTypeID")]
        public RoofType RoofType { get; set; }
        public Nullable<int> VehicleTitleID { get; set; }
        [ForeignKey("VehicleTitleID")]
        public VehclieTitle VehclieTitle { get; set; }
        public List<VehicleImage> VehicleImages { get; set; }
        public Nullable<long> VehicleTypeID { get; set; }
        [ForeignKey("VehicleTypeID")]
        public VehicleType VehicleType { get; set; }
        public Nullable<int> VehicleAudioID { get; set; }
        [ForeignKey("VehicleAudioID")]
        public VehicleAudio VehicleAudio { get; set; }
        public Nullable<int> VehicleInteriorTypeID { get; set; }
        [ForeignKey("VehicleInteriorTypeID")]
        public VehicleInteriorType VehicleInteriorType { get; set; }
        public Nullable<int> VehicleTopStyleID { get; set; }
        [ForeignKey("VehicleTopStyleID")]
        public VehicleTopStyle VehicleTopStyle { get; set; }
        public Nullable<int> VehicleWheelID { get; set; }
        [ForeignKey("VehicleWheelID")]
        public VehicleWheel VehicleWheel { get; set; }
        public Nullable<long> MediaPlayerID { get; set; }
        [ForeignKey("MediaPlayerID")]
        public MediaPlayer MediaPlayer { get; set; }
        public string VehicleOptions { get; set; }
        public string VehicleMoreOptions { get; set; }
        public string VehicleFlags { get; set; }
        public string VehiclemoreFlags { get; set; }
        public Nullable<int> VehicleAddressId { get; set; }
        [ForeignKey("VehicleAddressId")]
        public VehicleAddress VehicleAddress { get; set; }
        public double? ExteriorRatting { get; set; }
        public double? InteriorRatting { get; set; }
        public double? MechanicsRatting { get; set; }
        public double? FrameRatting { get; set; }
        public double? TotalRatting { get; set; }
        public double? VIRCompletenessPercentage { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public Nullable<bool> IsFeatured { get; set; }

      public Nullable<bool> IsFacebook { get; set; }
        public Nullable<decimal> PurchasingCost { get; set; }
        public Nullable<bool> Has360 { get; set; }
        //public Nullable<int> MilageID { get; set; }
        //[ForeignKey("MilageID")]
        //public Milage Milage { get; set; }
        public string MilageValue { get; set; }
        public string Branch { get; set; }
        public string Location { get; set; }

        public Nullable<long> AutoUsedStatusID { get; set; }
        [ForeignKey("AutoUsedStatusID")]
        public AutoUsedStatus AutoUsedStatus { get; set; }
        //public string DealerID { get; set; }


        public string ArabicWarantyText { get; set; }
        public string ArabicDescription { get; set; }
        public string ArabicFreeText { get; set; }

        public string ArabicVehicleMoreOptions { get; set; }
        public string ArabicVehicleMoreFlags { get; set; }


        public double? EvaluatorExteriorRatting { get; set; }
        public double? EvaluatorInteriorRatting { get; set; }
        public double? EvaluatorMechanicsRatting { get; set; }
        public double? EvaluatorFrameRatting { get; set; }
        public double? EvaluatorTotalRatting { get; set; }
        public bool HasDealerImages { get; set; }
    }

    public class AutoInventoryStatusHistory
    {
        [Key]
        public int ID { get; set; }
        public long VehicleId { get; set; }
        public int FromInventoryStatusID { get; set; }
        public int ToInventoryStatusID { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
