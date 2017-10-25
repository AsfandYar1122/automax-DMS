using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax.Models.DataModel
{
    public class DashboardViewModel
    {
        public string XAxis { get; set; }
        public string YAxis { get; set; }
        public int VehicleInStock { get; set; }
        public int WholeSaleCars { get; set; }
        public int RetailCars { get; set; }
        public int VIRCompleted { get; set; }
        public int VIRPending { get; set; }
        public List<PieChartData> PieChartResult { get; set; }
        public string PieChartDataString { get; set; }
        public int CurrentIndevntory { get;  set; }
        public int SoldVehicles { get;  set; }
    }
    public class PieChartData
    {
        public string UserName { get; set; }
        public int TotalCars { get; set; }
    }
    
}