using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMax.Models.Entities;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data;
using OfficeOpenXml;
using AutoMax.Models;
using System.Net;
using AutoMax.Common.Enums;
//using LinqToExcel;

namespace AutoMax.Controllers
{
    public class UploadVehicleInfoController : Controller
    {
        private AutoMaxContext db = new AutoMaxContext();


        // GET: UploadUtility
        public ActionResult Index()
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != UserRolesConst.ADMIN && user.Role != UserRolesConst.DataOP && user.Role != UserRolesConst.Marketing)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View();
        }
        public FileResult DownloadExcel()
        {
            string path = "/Doc/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }

        List<Maker> _makerList;
        List<AutoModel> _modelList;
        List<SubModel> _subModelList;
        List<AutoTransmission> _transmissionList;
        List<AutoExteriorColor> _colorList;
        List<Year> _yearList;
        List<VehclieTitle> _titlesList;
        List<VehicleAddress> _vehicleAddressList;

        int _vehicleStatusInventory;
        int _vehicleStatusPending;
        int _vehicleStatusSold;
        int _vehicleStatusWholeSale;
        int _vehicleStatusTaqeemDone;
        long _userId;

        public ActionResult UploadExcel(FormCollection formCollection)
        {
            if (Request != null)
            {
                _userId = 3;
                try
                {
                    var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
                    _userId = user.UserID;
                }
                catch (Exception ex)
                {

                }

                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    var vehicleList = new List<VehicleModel>();
                    try
                    {
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row - 3;
                            var lstMessages = new List<string>();

                            _makerList = db.Makers.ToList();
                            _modelList = db.AutoModels.ToList();
                            _subModelList = db.SubModels.ToList();
                            _transmissionList = db.AutoTransmissions.ToList();
                            _colorList = db.AutoExteriorColors.ToList();
                            _yearList = db.Years.ToList();
                            _titlesList = db.VehclieTitles.ToList();
                            _vehicleAddressList = db.VehicleAddress.ToList();
                            var lstStatus = db.InventoryStatus.ToList();

                            _vehicleStatusInventory = lstStatus.FirstOrDefault(a => a.Status.ToUpper() == "INVENTORY").InventoryStatusID;
                            _vehicleStatusPending = lstStatus.FirstOrDefault(a => a.Status.ToUpper() == "PENDING").InventoryStatusID;
                            _vehicleStatusSold = lstStatus.FirstOrDefault(a => a.Status.ToUpper() == "SOLD").InventoryStatusID;
                            _vehicleStatusWholeSale = lstStatus.FirstOrDefault(a => a.Status.ToUpper() == "WHOLESALE").InventoryStatusID;
                            _vehicleStatusTaqeemDone = lstStatus.FirstOrDefault(a => a.Status.ToUpper() == "TAQEEM DONE").InventoryStatusID;

                            // Getting indexes
                            int indexPrice = GetHeaderIndex(workSheet, "Price", noOfCol);
                            int indexStatus = GetHeaderIndex(workSheet, "Status", noOfCol);
                            int indexSNo = GetHeaderIndex(workSheet, "SNo", noOfCol);
                            int indexMake = GetHeaderIndex(workSheet, "Make", noOfCol);
                            int indexLocation = GetHeaderIndex(workSheet, "Location", noOfCol);
                            int indexBranch = GetHeaderIndex(workSheet, "Branch", noOfCol);
                            int indexBalance = GetHeaderIndex(workSheet, "Balance", noOfCol);
                            int indexYearOfModel = GetHeaderIndex(workSheet, "Year Of Model", noOfCol);
                            int indexColour = GetHeaderIndex(workSheet, "Colour", noOfCol);
                            int indexMileage = GetHeaderIndex(workSheet, "Mileage", noOfCol);
                            int indexPlateNo = GetHeaderIndex(workSheet, "Plate No", noOfCol);
                            int indexVehicle = GetHeaderIndex(workSheet, "Vehicle", noOfCol);
                            int indexVINNumber = GetHeaderIndex(workSheet, "VIN Number", noOfCol);
                            int indexTransmission = GetHeaderIndex(workSheet, "Transmission", noOfCol);
                            int indexSubModel = GetHeaderIndex(workSheet, "Sub Model", noOfCol);
                            int indexModel = GetHeaderIndex(workSheet, "Model", noOfCol);



                            for (int rowIterator = 5; rowIterator <= noOfRow; rowIterator++)
                            {
                                var fileVehicleObj = new VehicleModel();
                                if (indexSNo > 0)
                                    fileVehicleObj.SNo = Convert.ToInt32(workSheet.Cells[rowIterator, indexSNo].Value);
                                if (indexMake > 0)
                                    fileVehicleObj.Make = Convert.ToString(workSheet.Cells[rowIterator, indexMake].Value);
                                if (indexModel > 0)
                                    fileVehicleObj.Model = Convert.ToString(workSheet.Cells[rowIterator, indexModel].Value);
                                if (indexSubModel > 0)
                                    fileVehicleObj.SubModel = Convert.ToString(workSheet.Cells[rowIterator, indexSubModel].Value);
                                if (indexTransmission > 0)
                                    fileVehicleObj.Transmission = Convert.ToString(workSheet.Cells[rowIterator, indexTransmission].Value);
                                if (indexVINNumber > 0)
                                    fileVehicleObj.VINNumber = Convert.ToString(workSheet.Cells[rowIterator, indexVINNumber].Value);
                                if (indexVehicle > 0)
                                    fileVehicleObj.Vehicle = Convert.ToString(workSheet.Cells[rowIterator, indexVehicle].Value);
                                if (indexPlateNo > 0)
                                    fileVehicleObj.PlateNo = Convert.ToString(workSheet.Cells[rowIterator, indexPlateNo].Value);
                                if (indexMileage > 0)
                                    fileVehicleObj.Mileage = Convert.ToString(workSheet.Cells[rowIterator, indexMileage].Value);
                                if (indexColour > 0)
                                    fileVehicleObj.Colour = Convert.ToString(workSheet.Cells[rowIterator, indexColour].Value);
                                if (indexYearOfModel > 0)
                                    fileVehicleObj.YearOfModel = Convert.ToString(workSheet.Cells[rowIterator, indexYearOfModel].Value);
                                // Please ignore "Istemara Expiry" and "Balance" columns.
                                // fileVehicleObj.IstemaraExp = Convert.ToString(workSheet.Cells[rowIterator, ++columnNumber].Value);
                                if (indexBalance > 0)
                                    fileVehicleObj.Balance = Convert.ToString(workSheet.Cells[rowIterator, indexBalance].Value);
                                if (indexBranch > 0)
                                    fileVehicleObj.Branch = Convert.ToString(workSheet.Cells[rowIterator, indexBranch].Value);
                                if (indexLocation > 0)
                                    fileVehicleObj.Location = Convert.ToString(workSheet.Cells[rowIterator, indexLocation].Value);

                                // If we have Price
                                try
                                {
                                    if (indexPrice > 0)
                                        fileVehicleObj.Price = Convert.ToDecimal(workSheet.Cells[rowIterator, indexPrice].Value);
                                    else
                                        fileVehicleObj.Price = -1;
                                }
                                catch (Exception)
                                {
                                    fileVehicleObj.Price = -1;
                                }

                                try
                                {
                                    if (indexStatus > 0)
                                        fileVehicleObj.Status = (Convert.ToString(workSheet.Cells[rowIterator, indexStatus].Value)).ToUpper().Trim();
                                    else
                                        fileVehicleObj.Status = "";
                                }
                                catch (Exception)
                                {
                                    fileVehicleObj.Status = "";
                                }

                                if (string.IsNullOrEmpty(fileVehicleObj.VINNumber))
                                {
                                    continue;
                                }

                                // Check if there is any existing vehicle with that VIN
                                var existingVehicleObj = db.VehicleWizards.Where(a => a.VIN == fileVehicleObj.VINNumber && (a.IsDeleted == false || a.IsDeleted == null)).OrderByDescending(a => a.CreatedDate).FirstOrDefault();
                                if (existingVehicleObj == null)
                                {
                                    AddNewVehicle(fileVehicleObj);
                                }
                                else
                                {
                                    try
                                    {
                                        // If the status of existing vehicle in DMS with same VIN # is "INVENTORY" and the status provided in EXCEL file is "SOLD", 
                                        // THEN we will change the status of the vehicle in DMS to "SOLD".

                                        // Removing this case because the vehicles with sold status will not available in file
                                        //else if (fileVehicleObj.Status.ToUpper() == "SOLD" && existingVehicleObj.InventoryStatusID == _vehicleStatusInventory)
                                        //{
                                        //    // add status change history
                                        //    new UtilityRepository().AddInventoryStatusHistory(1, existingVehicleObj.VehicleID, existingVehicleObj.InventoryStatusID, _vehicleStatusSold);

                                        //    existingVehicleObj.InventoryStatusID = _vehicleStatusSold;
                                        //    existingVehicleObj.UpdateDate = DateTime.Now;
                                        //    existingVehicleObj.UserID = _userId;
                                        //    db.Entry<VehicleWizard>(existingVehicleObj).State = System.Data.Entity.EntityState.Modified;
                                        //    db.SaveChanges();
                                        //}
                                        //If the status of existing vehicle in DMS with same VIN # is "INVENTORY" and the status provided in EXCEL file is any value other than "SOLD" 
                                        //THEN our application should reject 
                                        //that record and print out a clear message saying that VIN # 123ABCXYZ already exists in the system with status INVENTORY.
                                        if (fileVehicleObj.Status.ToUpper() != "SOLD" && existingVehicleObj.InventoryStatusID == _vehicleStatusInventory)
                                        {
                                            lstMessages.Add(string.Format("VIN # {0} already exists in the system with status INVENTORY.", existingVehicleObj.VIN));
                                        }
                                        // If the status of existing vehicle in DMS with same VIN # is "SOLD"  and the status provided in EXCEL file is any value other than "SOLD", 
                                        // then we will add a new record for the vehicle while keeping the existing AS IS... This means, we will have two vehicles with same VIN number 
                                        // in the system now, 
                                        // with status of first one as SOLD, while the other one with status as provided in Excel.
                                        else if (fileVehicleObj.Status.ToUpper() != "SOLD" && existingVehicleObj.InventoryStatusID == _vehicleStatusSold)
                                        {
                                            fileVehicleObj.InventoryStatus = GetStatusIdFromString(fileVehicleObj.Status);
                                            AddNewVehicle(fileVehicleObj);
                                        }
                                        // If the status of existing vehicle in DMS with same VIN # is NOT "SOLD" AND NOT "INVENTORY", 
                                        // then we will just update the status of the existing vehicle to match the status provided in excel file.
                                        else if (existingVehicleObj.InventoryStatusID != _vehicleStatusInventory && existingVehicleObj.InventoryStatusID != _vehicleStatusSold)
                                        {
                                            if (existingVehicleObj.InventoryStatusID != _vehicleStatusWholeSale)
                                            {
                                                var newStatus = GetStatusIdFromString(fileVehicleObj.Status);
                                                // add status change history
                                                new UtilityRepository().AddInventoryStatusHistory(1, existingVehicleObj.VehicleID, existingVehicleObj.InventoryStatusID, newStatus);
                                                existingVehicleObj.InventoryStatusID = newStatus;
                                            }

                                            existingVehicleObj.UpdateDate = DateTime.Now;
                                            existingVehicleObj.UserID = _userId;


                                            var makerObj = _makerList.FirstOrDefault(a => a.Name == fileVehicleObj.Make);
                                            if (makerObj != null)
                                            {
                                                existingVehicleObj.MakerID = makerObj.MakerID;
                                            }
                                            else
                                            {
                                                existingVehicleObj.MakerID = AddNewMaker(fileVehicleObj.Make);
                                                _makerList = db.Makers.ToList();
                                            }

                                            var modelObj = _modelList.FirstOrDefault(a => a.ModelName == fileVehicleObj.Model && a.MakerID == existingVehicleObj.MakerID);
                                            if (modelObj != null)
                                            {
                                                existingVehicleObj.AutoModelID = modelObj.AutoModelID;
                                            }
                                            else
                                            {
                                                existingVehicleObj.AutoModelID = AddNewModel(fileVehicleObj.Model, existingVehicleObj.MakerID);
                                                _modelList = db.AutoModels.ToList();
                                            }

                                            var subModelObj = _subModelList.FirstOrDefault(a => a.ModelName == fileVehicleObj.SubModel && a.AutoModelID == existingVehicleObj.AutoModelID);
                                            if (subModelObj != null)
                                            {
                                                existingVehicleObj.SubModelID = subModelObj.SubModelID;
                                            }
                                            else
                                            {
                                                existingVehicleObj.SubModelID = GetSubModelID(fileVehicleObj.SubModel, existingVehicleObj.AutoModelID);
                                                _subModelList = db.SubModels.ToList();
                                            }

                                            db.Entry<VehicleWizard>(existingVehicleObj).State = System.Data.Entity.EntityState.Modified;

                                            db.SaveChanges();
                                        }
                                        else if (string.IsNullOrEmpty(fileVehicleObj.Status))
                                        {
                                            fileVehicleObj.InventoryStatus = -1;
                                            UpdateVehicle(fileVehicleObj, existingVehicleObj);
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                vehicleList.Add(fileVehicleObj);
                            }

                            db.SaveChanges();


                            UpdateSoldStatus(vehicleList, _vehicleStatusSold);
                            //Remove any extra vehicles
                            // This is a temporary call, we need to fix the root cause why vehicles get duplicated
                            RemoveExtraVehicles();
                            ViewBag.DisplayMessages = lstMessages;
                            ViewBag.Message = true;
                            return View("Index");
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = false;
                        return View("Index");
                    }
                }
            }

            return View("Index");
        }
        private void RemoveExtraVehicles()
        {
            try
            {
                var query = @"delete from VehicleWizards
where VehicleID in (
SELECT max(VehicleID)
FROM VehicleWizards 
WHERE (
        VIN IS NOT NULL
       AND Odometer IS NOT NULL
       AND AutoModelID IS NOT NULL
        AND MakerID IS NOT NULL
    ) AND ( IsDeleted = 0 OR IsDeleted IS NULL)
AND InventoryStatusID not in (4)
AND (USERID = NULL OR NULL IS NULL)
GROUP BY VIN
having COUNT(0) > 1)
";

                db.Database.ExecuteSqlCommand(query);
            }
            catch (Exception ex)
            {

            }
        }
        private int GetHeaderIndex(ExcelWorksheet workSheet, string title, int totalColumn)
        {
            int index = -1;
            try
            {
                for (int i = 1; i <= totalColumn; i++)
                {
                    if (Convert.ToString(workSheet.Cells[4, i].Value) == title)
                    {
                        index = i;
                        break;
                    }
                }
            }
            catch (Exception)
            {

            }

            return index;
        }

        /// <summary>
        /// This method will mark all vehicles as sold which are not available in this list
        /// </summary>
        /// <param name="vehicleList"></param>
        public void UpdateSoldStatus(List<VehicleModel> vehicleList, int soldStatus)
        {
            try
            {
                if (vehicleList != null && vehicleList.Count > 0)
                {
                    var vinList = vehicleList.Where(a => !string.IsNullOrEmpty(a.VINNumber)).Select(a => a.VINNumber).ToList();
                    var lstDMS = db.VehicleWizards.Where(a => !string.IsNullOrEmpty(a.VIN) && !vinList.Contains(a.VIN)).ToList();
                    foreach (var item in lstDMS)
                    {
                        item.InventoryStatusID = soldStatus;
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private int GetStatusIdFromString(string status)
        {
            if (status.ToUpper() == "INVENTORY")
            {
                return _vehicleStatusInventory;
            }
            if (status.ToUpper() == "PENDING")
            {
                return _vehicleStatusPending;
            }
            if (status.ToUpper() == "SOLD")
            {
                return _vehicleStatusSold;
            }
            if (status.ToUpper() == "WHOLESALE")
            {
                return _vehicleStatusWholeSale;
            }
            if (status.ToUpper() == "TAQEEM DONE")
            {
                return _vehicleStatusTaqeemDone;
            }

            return _vehicleStatusPending;
        }

        private void UpdateVehicle(VehicleModel fileVehicleObj, VehicleWizard existingVehicleObj)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileVehicleObj.Make))
                {
                    var makerObj = _makerList.FirstOrDefault(a => a.Name != null && a.Name.Trim().ToLower() == fileVehicleObj.Make.Trim().ToLower());
                    if (makerObj != null)
                    {
                        existingVehicleObj.MakerID = makerObj.MakerID;
                    }
                    else
                    {
                        existingVehicleObj.MakerID = AddNewMaker(fileVehicleObj.Make);
                        _makerList = db.Makers.ToList();
                    }
                }

                if (!string.IsNullOrEmpty(fileVehicleObj.Model))
                {
                    var modelObj = _modelList.FirstOrDefault(a => a.ModelName != null && a.ModelName.Trim().ToLower() == fileVehicleObj.Model.Trim().ToLower() && a.MakerID == existingVehicleObj.MakerID);
                    if (modelObj != null)
                    {
                        existingVehicleObj.AutoModelID = modelObj.AutoModelID;
                    }
                    else
                    {
                        existingVehicleObj.AutoModelID = AddNewModel(fileVehicleObj.Model, existingVehicleObj.MakerID);
                        _modelList = db.AutoModels.ToList();
                    }
                }

                if (!string.IsNullOrEmpty(fileVehicleObj.SubModel))
                {
                    var subModelObj = _subModelList.FirstOrDefault(a => a.ModelName != null && a.ModelName.Trim().ToLower() == fileVehicleObj.SubModel.Trim().ToLower() && a.AutoModelID == existingVehicleObj.AutoModelID);
                    if (subModelObj != null)
                    {
                        existingVehicleObj.SubModelID = subModelObj.SubModelID;
                    }
                    else
                    {
                        existingVehicleObj.SubModelID = GetSubModelID(fileVehicleObj.SubModel, existingVehicleObj.AutoModelID);
                        _subModelList = db.SubModels.ToList();
                    }
                }

                var transmissionObj = _transmissionList.FirstOrDefault(a => a.Transmission == fileVehicleObj.Transmission);
                if (transmissionObj != null)
                {
                    existingVehicleObj.AutoTransmissionID = transmissionObj.AutoTransmissionID;
                }
                else
                {
                    existingVehicleObj.AutoTransmissionID = GetAutoTransmissionID(fileVehicleObj.Transmission);
                    _transmissionList = db.AutoTransmissions.ToList();
                }

                existingVehicleObj.VIN = fileVehicleObj.VINNumber;
                existingVehicleObj.Odometer = fileVehicleObj.Mileage;
                existingVehicleObj.PlateNumber = fileVehicleObj.PlateNo;

                if (string.IsNullOrEmpty(fileVehicleObj.PlateNo) || fileVehicleObj.PlateNo == "VCC" || fileVehicleObj.PlateNo == "vcc")
                {
                    existingVehicleObj.AutoUsedStatusID = GetAutoUsedStatus("New");
                }
                else
                {
                    existingVehicleObj.AutoUsedStatusID = GetAutoUsedStatus("Used");
                }

                var titleObj = _titlesList.FirstOrDefault(a => a.Title == fileVehicleObj.Vehicle);
                if (titleObj != null)
                {
                    existingVehicleObj.VehicleTitleID = titleObj.VehicleTitleID;
                }
                else
                {
                    existingVehicleObj.VehicleTitleID = GetTitleID(fileVehicleObj.Vehicle);
                    _titlesList = db.VehclieTitles.ToList();
                }

                var colorObj = _colorList.FirstOrDefault(a => a.ExteriorColor == fileVehicleObj.Colour);
                if (colorObj != null)
                {
                    existingVehicleObj.AutoExteriorColorID = colorObj.AutoExteriorColorID;
                }
                else
                {
                    existingVehicleObj.AutoExteriorColorID = GetAutoExteriorColorID(fileVehicleObj.Colour);
                    _colorList = db.AutoExteriorColors.ToList();
                }

                var yearObj = _yearList.FirstOrDefault(a => a.YearName == fileVehicleObj.YearOfModel);
                if (yearObj != null)
                {
                    existingVehicleObj.YearID = yearObj.YearID;
                }
                else
                {
                    existingVehicleObj.YearID = GetYearID(fileVehicleObj.YearOfModel);
                    _yearList = db.Years.ToList();
                }

                existingVehicleObj.Branch = fileVehicleObj.Branch;
                existingVehicleObj.Location = fileVehicleObj.Location;



                if (fileVehicleObj.Price > 0)
                {
                    existingVehicleObj.VehiclePrice = fileVehicleObj.Price;
                }

                if (fileVehicleObj.InventoryStatus > 0)
                {
                    existingVehicleObj.InventoryStatusID = fileVehicleObj.InventoryStatus;
                }

                existingVehicleObj.UpdateDate = DateTime.Now;
                existingVehicleObj.UserID = _userId;
                db.Entry<VehicleWizard>(existingVehicleObj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileVehicleObj"></param>
        private void AddNewVehicle(VehicleModel fileVehicleObj)
        {
            try
            {
                var newVehicleObj = new VehicleWizard();

                if (!string.IsNullOrEmpty(fileVehicleObj.Make))
                {
                    var makerObj = _makerList.FirstOrDefault(a => a.Name != null && a.Name.Trim().ToLower() == fileVehicleObj.Make.Trim().ToLower());
                    if (makerObj != null)
                    {
                        newVehicleObj.MakerID = makerObj.MakerID;
                    }
                    else
                    {
                        newVehicleObj.MakerID = AddNewMaker(fileVehicleObj.Make);
                        _makerList = db.Makers.ToList();
                    }
                }

                if (!string.IsNullOrEmpty(fileVehicleObj.Model))
                {
                    var modelObj = _modelList.FirstOrDefault(a => a.ModelName != null && a.ModelName.Trim().ToLower() == fileVehicleObj.Model.Trim().ToLower() && a.MakerID == newVehicleObj.MakerID);
                    if (modelObj != null)
                    {
                        newVehicleObj.AutoModelID = modelObj.AutoModelID;
                    }
                    else
                    {
                        newVehicleObj.AutoModelID = AddNewModel(fileVehicleObj.Model, newVehicleObj.MakerID);
                        _modelList = db.AutoModels.ToList();
                    }
                }

                if (!string.IsNullOrEmpty(fileVehicleObj.SubModel))
                {
                    var subModelObj = _subModelList.FirstOrDefault(a => a.ModelName != null && a.ModelName.Trim().ToLower() == fileVehicleObj.SubModel.Trim().ToLower() && a.AutoModelID == newVehicleObj.AutoModelID);
                    if (subModelObj != null)
                    {
                        newVehicleObj.SubModelID = subModelObj.SubModelID;
                    }
                    else
                    {
                        newVehicleObj.SubModelID = GetSubModelID(fileVehicleObj.SubModel, newVehicleObj.AutoModelID);
                        _subModelList = db.SubModels.ToList();
                    }
                }

                var transmissionObj = _transmissionList.FirstOrDefault(a => a.Transmission == fileVehicleObj.Transmission);
                if (transmissionObj != null)
                {
                    newVehicleObj.AutoTransmissionID = transmissionObj.AutoTransmissionID;
                }
                else
                {
                    newVehicleObj.AutoTransmissionID = GetAutoTransmissionID(fileVehicleObj.Transmission);
                    _transmissionList = db.AutoTransmissions.ToList();
                }

                newVehicleObj.VIN = fileVehicleObj.VINNumber;
                newVehicleObj.Odometer = fileVehicleObj.Mileage;
                newVehicleObj.PlateNumber = fileVehicleObj.PlateNo;
                newVehicleObj.InventoryStatusID = 2; // Pending status
                var titleObj = _titlesList.FirstOrDefault(a => a.Title == fileVehicleObj.Vehicle);
                if (titleObj != null)
                {
                    newVehicleObj.VehicleTitleID = titleObj.VehicleTitleID;
                }
                else
                {
                    newVehicleObj.VehicleTitleID = GetTitleID(fileVehicleObj.Vehicle);
                    _titlesList = db.VehclieTitles.ToList();
                }

                var colorObj = _colorList.FirstOrDefault(a => a.ExteriorColor == fileVehicleObj.Colour);
                if (colorObj != null)
                {
                    newVehicleObj.AutoExteriorColorID = colorObj.AutoExteriorColorID;
                }
                else
                {
                    newVehicleObj.AutoExteriorColorID = GetAutoExteriorColorID(fileVehicleObj.Colour);
                    _colorList = db.AutoExteriorColors.ToList();
                }

                var yearObj = _yearList.FirstOrDefault(a => a.YearName == fileVehicleObj.YearOfModel);
                if (yearObj != null)
                {
                    newVehicleObj.YearID = yearObj.YearID;
                }
                else
                {
                    newVehicleObj.YearID = GetYearID(fileVehicleObj.YearOfModel);
                    _yearList = db.Years.ToList();
                }

                newVehicleObj.Branch = fileVehicleObj.Branch;
                newVehicleObj.Location = fileVehicleObj.Location;

                var locationObj = _vehicleAddressList.FirstOrDefault(a => a.Name == fileVehicleObj.Location);
                if (locationObj != null)
                {
                    newVehicleObj.VehicleAddressId = locationObj.Id;
                }
                else
                {
                    newVehicleObj.VehicleAddressId = GetAddressID(fileVehicleObj.Location);
                    _vehicleAddressList = db.VehicleAddress.ToList();
                }



                if (fileVehicleObj.Price > 0)
                {
                    newVehicleObj.VehiclePrice = fileVehicleObj.Price;
                }

                if (string.IsNullOrEmpty(fileVehicleObj.PlateNo) || fileVehicleObj.PlateNo == "VCC" || fileVehicleObj.PlateNo == "vcc")
                {
                    newVehicleObj.AutoUsedStatusID = GetAutoUsedStatus("New");
                }
                else
                {
                    newVehicleObj.AutoUsedStatusID = GetAutoUsedStatus("Used");
                }

                if (fileVehicleObj.InventoryStatus > 0)
                {
                    newVehicleObj.InventoryStatusID = fileVehicleObj.InventoryStatus;
                }

                newVehicleObj.Has360 = true;
                newVehicleObj.CreatedDate = DateTime.Now;
                newVehicleObj.UpdateDate = DateTime.Now;
                newVehicleObj.UserID = _userId;
                db.VehicleWizards.Add(newVehicleObj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private int GetAutoUsedStatus(string status)
        {
            try
            {
                var obj = db.AutoUsedStatus.FirstOrDefault(a => a.UsedStatus != null && a.UsedStatus.ToLower().Equals(status.ToLower()));
                if (obj != null)
                {
                    return Convert.ToInt32(obj.AutoUsedStatusID);
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }

        private int? GetAddressID(string location)
        {
            try
            {
                var obj = new VehicleAddress();
                obj.GoogleAddress = location;
                obj.Name = location;
                obj.PhysicalAddress = location;

                db.VehicleAddress.Add(obj);
                db.SaveChanges();
                return obj.Id;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transmission"></param>
        /// <returns></returns>
        private long? GetAutoTransmissionID(string transmission)
        {
            try
            {
                var obj = new AutoTransmission();
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;
                obj.UpdatedBy = 1;
                obj.UpdatedDate = DateTime.Now;
                obj.Transmission = transmission;
                db.AutoTransmissions.Add(obj);
                db.SaveChanges();
                return obj.AutoTransmissionID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private int? GetYearID(string yearOfModel)
        {
            try
            {
                var obj = new Year();
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;
                obj.UpdatedBy = 1;
                obj.UpdatedDate = DateTime.Now;
                obj.YearName = yearOfModel;
                db.Years.Add(obj);
                db.SaveChanges();
                return obj.YearID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private long? GetAutoExteriorColorID(string colour)
        {
            try
            {
                var obj = new AutoExteriorColor();
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;
                obj.UpdatedBy = 1;
                obj.UpdatedDate = DateTime.Now;
                obj.ExteriorColor = colour;
                db.AutoExteriorColors.Add(obj);
                db.SaveChanges();
                return obj.AutoExteriorColorID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private int? GetTitleID(string vehicle)
        {
            try
            {
                var obj = new VehclieTitle();
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;
                obj.UpdatedBy = 1;
                obj.UpdatedDate = DateTime.Now;
                obj.Title = vehicle;
                db.VehclieTitles.Add(obj);
                db.SaveChanges();
                return obj.VehicleTitleID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private int? GetSubModelID(string subModel, int? autoModelId)
        {
            try
            {
                var obj = new SubModel();
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;
                obj.UpdatedBy = 1;
                obj.UpdatedDate = DateTime.Now;
                obj.ModelName = subModel;
                obj.AutoModelID = autoModelId;
                db.SubModels.Add(obj);
                db.SaveChanges();
                return obj.SubModelID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private int? AddNewModel(string model, int? makerId)
        {
            try
            {
                var obj = new AutoModel();
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;
                obj.UpdatedBy = 1;
                obj.UpdatedDate = DateTime.Now;
                obj.ModelName = model;
                obj.MakerID = makerId;
                db.AutoModels.Add(obj);
                db.SaveChanges();
                return obj.AutoModelID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        private int? AddNewMaker(string make)
        {
            try
            {
                var obj = new Maker();
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;
                obj.UpdatedBy = 1;
                obj.UpdatedDate = DateTime.Now;
                obj.Name = make;
                db.Makers.Add(obj);
                db.SaveChanges();
                return obj.MakerID;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
    }



    public class VehicleModel
    {
        public VehicleModel()
        {

        }

        public VehicleModel(string vehicleVIN)
        {
            this.VINNumber = vehicleVIN;
        }

        public decimal Price { get; set; }
        public string Status { get; set; }
        public int SNo { get; set; }
        public string Make { get; set; }
        public string Location { get; set; }
        public string Branch { get; set; }
        public string Balance { get; set; }
        public string IstemaraExp { get; set; }
        public string YearOfModel { get; set; }
        public string Colour { get; set; }
        public string Mileage { get; set; }
        public string PlateNo { get; set; }
        public string Vehicle { get; set; }
        public string VINNumber { get; set; }
        public string Transmission { get; set; }
        public string SubModel { get; set; }
        public string Model { get; set; }
        public int InventoryStatus { get; set; }
    }
}
