using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{
    public class VehiclePrice
    {
        [Key]
        public int VehiclePriceID { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal ByNowWholeSalePrice { get; set; }
        public decimal ConsignedPrice { get; set; }
        public decimal SaleCost { get; set; }
        public decimal MSRP { get; set; }
        public decimal BookValue { get; set; }
        public decimal InternetPrice { get; set; }
        public decimal AlternativePrice1 { get; set; }
        public decimal AlternativePrice2 { get; set; }
        public decimal AlternativePrice3 { get; set; }
        public long PriceVehicleID { get; set; }
        public virtual VehicleWizard VehicleWizard { get; set; }
        public int VehicleID { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
    }
}
