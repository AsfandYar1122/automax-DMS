using AutoMax.LangResources;
using AutoMax.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMax.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        AutoMaxContext db = new AutoMaxContext();
        // GET: Dashboard
        //[OutputCache(Duration = int.MaxValue, VaryByParam = "none")]
        public ActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();

            var sqlQueryPie = @"SELECT

    COUNT(*) AS TotalCars,
   concat(USERS.FirstName, ' ', Users.LastName) as UserName
FROM

    VehicleWizards
INNER JOIN USERS ON USERS.UserID = VehicleWizards.UserID
WHERE
    (
        VIN IS NOT NULL

        AND Odometer IS NOT NULL

        AND AutoModelID IS NOT NULL

        AND MakerID IS NOT NULL
    )
AND(
    IsDeleted = 0

    OR IsDeleted IS NULL
) ";
            var userId = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            string UserID = "NULL";

            if (userId == null)
            {
                UserID = "NULL";
            }
            else if (userId != null && (userId.Role == "Admin" || userId.Role == "Marketing" || userId.Role == "Data OP" || userId.Role == "Finance"))
            {
                UserID = "NULL";
            }
            else if (userId != null && userId.Role != "Admin" && userId.Role != "Marketing" && userId.Role != "Data OP" && userId.Role != "Finance")
            {
                UserID = userId.UserID.ToString();
            }
            sqlQueryPie += " AND (VehicleWizards.UserID =" + UserID + " OR " + UserID + "  IS NULL) GROUP BY concat(USERS.FirstName, ' ', Users.LastName)";
            var listPie = db.Database.SqlQuery<PieChartData>(sqlQueryPie).ToList();
            var pieStr = "";
            foreach (var item in listPie)
            {
                if (!string.IsNullOrEmpty(item.UserName))
                {
                    item.UserName = item.UserName.Trim();
                }

                item.UserName = string.IsNullOrEmpty(item.UserName) ? "ERP" : item.UserName;

                if (string.IsNullOrEmpty(pieStr))
                {
                    pieStr += "[\"" + item.UserName + "\"," + item.TotalCars + "]";
                }
                else
                {
                    pieStr += ",[\"" + item.UserName + "\"," + item.TotalCars + "]";
                }
            }
            model.PieChartDataString = pieStr;
            //var sqlQueryInventoryVIR = "SELECT COUNT(*) FROM VehicleWizards as Total WHERE (VIN IS NOT NULL AND PlateNumber IS NOT NULL AND VehicleTitleID IS NOT NULL AND Odometer IS NOT NULL AND  AutoModelID IS NOT NULL AND MakerID IS NOT NULL) AND ( IsDeleted = 0 OR IsDeleted IS NULL ) AND  USERID =" + UserID + " OR " + UserID + "  IS NULL";
            var sqlQueryInventoryVIR = @"SELECT COUNT(*) FROM VehicleWizards as Total WHERE  (
        VIN IS NOT NULL

        AND Odometer IS NOT NULL

        AND AutoModelID IS NOT NULL

        AND MakerID IS NOT NULL
    ) AND ( IsDeleted = 0 OR IsDeleted IS NULL) AND  (USERID =" + UserID + " OR " + UserID + "  IS NULL)";
            var countInventory = db.Database.SqlQuery<int>(sqlQueryInventoryVIR).FirstOrDefault();
            model.VehicleInStock = countInventory;
            model.WholeSaleCars = model.VehicleInStock;
            model.RetailCars = model.VehicleInStock;
            //var sqlQueryVIRDone = "SELECT COUNT(*) from VIRs Inner JOIN VehicleWizards on VIRs.fkVehickeId = VehicleWizards.VehicleID WHERE (VIN IS NOT NULL AND PlateNumber IS NOT NULL AND VehicleTitleID IS NOT NULL AND Odometer IS NOT NULL AND  AutoModelID IS NOT NULL AND MakerID IS NOT NULL)AND ( IsDeleted = 0 OR IsDeleted IS NULL ) AND VIRCompletenessPercentage >0 AND USERID =" + UserID + " OR " + UserID + "  IS NULL ";

            var sqlQueryVIRCompleted = string.Format(@"SELECT 
	COUNT (*)
FROM VehicleWizards 
WHERE (
        VIN IS NOT NULL

        AND Odometer IS NOT NULL

        AND AutoModelID IS NOT NULL

        AND MakerID IS NOT NULL
    ) AND 
	(
		VIRCompletenessPercentage > 0
	)
AND 
	(
		IsDeleted = 0
		OR IsDeleted IS NULL
	)
 AND InventoryStatusID not in (4)
AND (USERID = {0} OR {0} IS NULL);", UserID);

            model.VIRCompleted = db.Database.SqlQuery<int>(sqlQueryVIRCompleted).FirstOrDefault();

            var sqlQueryVIRPending = string.Format(@"SELECT 
	COUNT (*)
FROM VehicleWizards 
WHERE (
        VIN IS NOT NULL

        AND Odometer IS NOT NULL

        AND AutoModelID IS NOT NULL

        AND MakerID IS NOT NULL
    ) AND 
	(
		VIRCompletenessPercentage is null
        or VIRCompletenessPercentage < 0
        or VIRCompletenessPercentage = 0
	)
AND 
	(
		IsDeleted = 0
		OR IsDeleted IS NULL
	)
 AND InventoryStatusID not in (4)
AND (USERID = {0} OR {0} IS NULL);", UserID);

            model.VIRPending = db.Database.SqlQuery<int>(sqlQueryVIRPending).FirstOrDefault();

            var sqlQueryCurrentIndevntory = string.Format(@"SELECT 
	COUNT (*)
FROM VehicleWizards 
WHERE (
        VIN IS NOT NULL

        AND Odometer IS NOT NULL

        AND AutoModelID IS NOT NULL

        AND MakerID IS NOT NULL
    ) AND 
	(
		IsDeleted = 0
		OR IsDeleted IS NULL
	)
AND InventoryStatusID not in (4)
AND (USERID = {0} OR {0} IS NULL);", UserID);

            model.CurrentIndevntory = db.Database.SqlQuery<int>(sqlQueryCurrentIndevntory).FirstOrDefault(); 
            // 4 is status of sold
            var sqlQuerySoldVehicles = string.Format(@"SELECT
	COUNT (*)
FROM VehicleWizards 
WHERE (
        VIN IS NOT NULL

        AND Odometer IS NOT NULL

        AND AutoModelID IS NOT NULL

        AND MakerID IS NOT NULL
    ) AND 
	(
		InventoryStatusID = 4
	)
AND (
	IsDeleted = 0
	OR IsDeleted IS NULL
)
AND (USERID = {0} OR {0} IS NULL);", UserID);


            model.SoldVehicles = db.Database.SqlQuery<int>(sqlQuerySoldVehicles).FirstOrDefault();
            // 
            var sqlLineChartQuery = string.Format(@"select PostingDetails.PostingSiteID, DATENAME(mm, PostingDetails.UpdatedDate) as Month, count(0) as Count  from PostingDetails
INNER JOIN VehicleWizards on VehicleWizards.VehicleID = PostingDetails.VehicleWizardId
where DATENAME(yyyy, PostingDetails.UpdatedDate) = DATENAME(yyyy, GETDATE()) 
AND (VehicleWizards.UserID = {0} OR {0} IS NULL)
GROUP BY PostingSiteID, DATENAME(mm, PostingDetails.UpdatedDate);", UserID);

            /*
             select PostingDetails.PostingSiteID, DATENAME(mm, PostingDetails.UpdatedDate) as Month, count(0) as Count  from PostingDetails
where DATENAME(yyyy, PostingDetails.UpdatedDate) = DATENAME(yyyy, GETDATE())
GROUP BY PostingSiteID, DATENAME(mm, PostingDetails.UpdatedDate)

             */


            var list = db.Database.SqlQuery<AutoMax.Models.LineCharTData>(sqlLineChartQuery).ToList();

            var lst = (from data in list
                       group data by data.Month into groupedData
                       select new AutoMax.Models.DisplayLineChart()
                       {
                           category = groupedData.Key,
                           FBColumn = groupedData.FirstOrDefault(a => a.PostingSiteID == 3) == null ? 0 : groupedData.FirstOrDefault(a => a.PostingSiteID == 3).Count,
                           HRJColumn = groupedData.FirstOrDefault(a => a.PostingSiteID == 2) == null ? 0 : groupedData.FirstOrDefault(a => a.PostingSiteID == 2).Count,
                           OSColumn = groupedData.FirstOrDefault(a => a.PostingSiteID == 1) == null ? 0 : groupedData.FirstOrDefault(a => a.PostingSiteID == 1).Count,
                       }).ToList();

            //var lineChartData = "";
            //List<AutoMax.Models.DisplayLineChart> disList = new List<Models.DisplayLineChart>();
            //for (int m = 1; m <= DateTime.Today.Month; m++)
            //{
            //    var item = list.Where(d => d.MonthNumber == m).FirstOrDefault();
            //    if (item != null)
            //    {
            //        disList.Add(new Models.DisplayLineChart { category = GetMonthName(m), FBColumn = item.TotalCars, HRJColumn = item.TotalCars, OSColumn = 3 });
            //    }
            //    else
            //    {
            //        disList.Add(new Models.DisplayLineChart { category = GetMonthName(m), FBColumn = 1, HRJColumn = 2, OSColumn = 3 });
            //    }
            //}
            ViewBag.DisplayLineChart = lst;
            return View(model);
        }
        public string GetMonthName(int number)
        {
            string month = "Jan";
            switch (number)
            {
                case 1:
                    month = "Jan";
                    break;
                    break;
                case 2:
                    month = "Feb";
                    break;
                case 3:
                    month = "Mar";
                    break;
                case 4:
                    month = "Apr";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "Jun";
                    break;
                case 7:
                    month = "Jul";
                    break;
                case 8:
                    month = "Aug";
                    break;
                case 9:
                    month = "Sep";
                    break;
                case 10:
                    month = "Oct";
                    break;
                case 11:
                    month = "Nov";
                    break;
                case 12:
                    month = "Dec";
                    break;
                default:
                    month = "Jan";
                    break;
            }
            return month;
        }
        public List<AutoMax.Models.TextValue> Months
        {
            get
            {
                List<AutoMax.Models.TextValue> list = new List<AutoMax.Models.TextValue>();
                var dateTime = DateTime.UtcNow;
                var dateFrom = DateTime.UtcNow;
                var dateTo = DateTime.UtcNow;
                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                var Dateform = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0);
                for (int m = 1; m <= DateTime.Today.Month; m++)
                {
                    //list.Add(new TextValue(Dateform.AddMonths(0).ToString("MMM yyyy"), ""));
                    list.Add(new AutoMax.Models.TextValue(mfi.GetMonthName(m) + " " + DateTime.Today.Year, m.ToString()));
                }
                return list;
            }
        }
    }
}