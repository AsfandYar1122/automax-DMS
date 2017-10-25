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
using PagedList.Mvc;
using PagedList;
using AutoMax.Models.DataModel;
using System.Web.Caching;
using Facebook;
using System.Dynamic;
using System.Text;
using AutoMax.Models.Common;
using System.Web.Configuration;
using AutoMax.PostingLibrary.WebsitePosting;

namespace AutoMax.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();
        //[OutputCache(Duration = 300, VaryByParam = "*")]
        // GET: VehicleWizards
        public ActionResult Index(int? page, int? VehicleTypeID = null, int? VehicleTitleID = null, int? MakerID = null, string VIN = null, string SearchAny = null,
            int? AutoModelID = null, int? SubModelID = null, int? InventoryStatusID = null, int? IsFeatured = null, int? HasDealerImages = null, int pageSize = 10, string successMessage = "", string sortingColumnName = "", bool isASC = true)
        {
            try
            {
                InventoryRespository rep = new InventoryRespository();
                var userId = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
                long? UserID = null;
                if (userId == null)
                {
                    UserID = null;
                }
                else if (userId != null && (userId.Role == "Admin" || userId.Role == "Marketing" || userId.Role == "Data OP" || userId.Role == "Finance"))
                {
                    UserID = null;
                }
                else if (userId != null && userId.Role != "Admin" && userId.Role == "Marketing" || userId.Role == "Data OP" || userId.Role == "Finance")
                {
                    UserID = userId.UserID;
                }
                var vList = rep.GetInventoryViewModelList(VehicleTypeID, VehicleTitleID, MakerID, VIN, SearchAny, AutoModelID, SubModelID, UserID, InventoryStatusID, IsFeatured, HasDealerImages, sortingColumnName: sortingColumnName, isASC: isASC).Data as List<VehicleViewModel>;
                ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), VehicleTypeID);
                ViewBag.VehicleTitleID = new SelectList(db.VehclieTitles, "VehicleTitleID", SharedStorage.Instance.GetDropDownBindValue("Title"), VehicleTitleID);
                ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), MakerID);
                ViewBag.VIN = VIN;
                TempData["IsFeatured"] = IsFeatured;
                TempData["HasDealerImages"] = HasDealerImages;
                ViewBag.SearchAny = SearchAny;
                ViewBag.CountTotal = vList.Count;
                ViewBag.sortingColumnName = sortingColumnName;
                if (MakerID != null)
                {
                    ViewBag.AutoModelID = new SelectList((from p in db.AutoModels where p.MakerID == MakerID orderby p.ModelName ascending select p), "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), AutoModelID);
                }
                else
                {
                    List<AutoModel> automodel = new List<AutoModel>();
                    ViewBag.AutoModelID = new SelectList(automodel, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
                    //db.AutoModels.OrderBy(z => z.ModelName), "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), AutoModelID);
                }
                if (AutoModelID != null)
                {
                    ViewBag.SubModelID = new SelectList((from p in db.SubModels where p.AutoModelID == AutoModelID orderby p.ModelName ascending select p), "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), SubModelID);
                }
                else
                {
                    List<SubModel> submodel = new List<SubModel>();
                    ViewBag.SubModelID = new SelectList(submodel, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
                    //db.SubModels, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), SubModelID);
                }

                ViewBag.InventoryStatusID = new SelectList(db.InventoryStatus, "InventoryStatusID", SharedStorage.Instance.GetDropDownBindValue("Status"), InventoryStatusID);
                int pgSz = pageSize;
                int pageNumber = (page ?? 1);
                ViewBag.SuccessMessage = successMessage;
                ViewBag.SortingOrder = isASC ? "DESC" : "ASC";
                return View(vList.ToPagedList(pageNumber, pgSz));
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        public ActionResult SaveUploadedFile(long VehicleID)
        {
            try
            {
                bool isSavedSuccessfully = true;
                string fName = "";
                long ImageID = 0;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    VehicleImage img = new VehicleImage();
                    HttpPostedFileBase file = Request.Files[i];
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var imageExists = db.VehicleImages.Where(d => d.VehicleID == VehicleID).OrderByDescending(d => d.VehicleImageID).FirstOrDefault();
                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        var extention = Path.GetExtension(file.FileName); // retur
                        var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                        DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                        fileName = fileName + date + extention;
                        var path = Path.Combine(Server.MapPath("~/VehicleAttachments/"), fileName);
                        file.SaveAs(path);
                        var displayOrder = imageExists == null ? i + 1 : imageExists.DisplayOrder == null ? 0 + 1 : imageExists.DisplayOrder + 1;
                        img.ImagePath = fileName;
                        img.VehicleID = VehicleID;
                        img.CreatedBy = 1;
                        img.UpdatedBy = 1;
                        img.CreatedDate = DateTime.Now;
                        img.UpdatedDate = DateTime.Now;
                        img.DisplayOrder = displayOrder;
                        db.VehicleImages.Add(img);
                    }
                    db.SaveChanges();
                    isSavedSuccessfully = true;
                    ImageID = img.VehicleImageID;
                }
                if (isSavedSuccessfully)
                {
                    return Json(new { Message = fName, ImageID = ImageID }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Message = "Error in saving file", ImageID = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        // GET: VehicleWizards/Details/5
        //[HttpPost]
        //public JsonResult GetVIN(string Prefix)
        //{
        //    var vins = (from c in db.VehicleWizards
        //                where c.VIN.StartsWith(Prefix)
        //                select new { c.VIN, c.VehicleID });
        //    return Json(vins, JsonRequestBehavior.AllowGet);
        //}

        // GET: VehicleWizards/Details/5
        [HttpPost]
        public JsonResult GetVIN(string Prefix)
        {
            var vins = (from d in db.VehicleWizards
                        where (d.IsDeleted == null || d.IsDeleted == false) && (d.VIN == Prefix || (d.VIN != null && d.VIN.Substring(d.VIN.Length - 6).Contains(Prefix)))
                        select new { d.VIN, d.VehicleID }).ToList();
            return Json(vins, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult GetSubModelWizard(int AutoModelID)
        {
            try
            {
                ViewBag.SubModelID = new SelectList(db.SubModels.Where(d => d.AutoModelID == AutoModelID), "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
                return PartialView("_PartialSubModelWizard");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult GetSubModelInventory(int AutoModelID)
        {
            try
            {
                ViewBag.SubModelID = new SelectList(db.SubModels.Where(d => d.AutoModelID == AutoModelID).OrderBy(z => z.ModelName), "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
                return PartialView("_PartialSubModelInventory");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult GetAllSubModelInventory()
        {
            ViewBag.SubModelID = new SelectList(db.SubModels.OrderBy(z => z.ModelName), "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
            return PartialView("_PartialSubModelInventory");
        }
        [HttpPost]
        public ActionResult GetAllModelInventory()
        {
            ViewBag.AutoModelID = new SelectList(db.AutoModels.OrderBy(z => z.ModelName), "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
            return PartialView("_PartialModelInventory");
        }

        [HttpPost]
        public ActionResult GetModelWizard(int MakerID)
        {
            ViewBag.AutoModelID = new SelectList(db.AutoModels.Where(d => d.MakerID == MakerID), "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
            return PartialView("_PartialModelWizard");
        }

        [HttpPost]
        public ActionResult GetModelInventory(int MakerID)
        {
            ViewBag.AutoModelID = new SelectList(db.AutoModels.Where(d => d.MakerID == MakerID).OrderBy(z => z.ModelName), "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
            return PartialView("_PartialModelInventory");
        }
        [HttpPost]
        public ActionResult GetMakeWizard(int VehicleTypeID)
        {
            ViewBag.MakerID = new SelectList(db.Makers.Where(d => d.VehicleTypeID == VehicleTypeID), "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"));
            return PartialView("_PartialMakeWizard");
        }
        [HttpPost]
        public ActionResult GetMakeInventory(int VehicleTypeID)
        {
            ViewBag.MakerID = new SelectList(db.Makers.Where(d => d.VehicleTypeID == VehicleTypeID).OrderBy(z => z.Name), "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"));
            return PartialView("_PartialMakeInventory");
        }
        // GET: VehicleWizards/Create
        public ActionResult Wizard()
        {
            try
            {
                var objFuel = db.FuelTypes.Where(d => d.Type == "Petrol / Gas").FirstOrDefault();
                long fuelTypeID = objFuel == null ? 0 : objFuel.FuelTypeID;


                ViewBag.AutoDoorsID = new SelectList(db.AutoDoors, "AutoDoorsID", SharedStorage.Instance.GetDropDownBindValue("Doors"));
                ViewBag.AutoEngineID = new SelectList(db.AutoEngines, "AutoEngineID", SharedStorage.Instance.GetDropDownBindValue("EngineName"));
                ViewBag.AutoExteriorColorID = new SelectList(db.AutoExteriorColors, "AutoExteriorColorID", SharedStorage.Instance.GetDropDownBindValue("ExteriorColor"));
                ViewBag.AutoInteriorColorID = new SelectList(db.AutoInteriorColors, "AutoInteriorColorID", SharedStorage.Instance.GetDropDownBindValue("InteriorColor"));
                ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
                ViewBag.AutoSteeringID = new SelectList(db.AutoSteerings, "AutoSteeringID", SharedStorage.Instance.GetDropDownBindValue("Steering"));
                ViewBag.AutoTransmissionID = new SelectList(db.AutoTransmissions, "AutoTransmissionID", SharedStorage.Instance.GetDropDownBindValue("Transmission"));
                ViewBag.DriveTypeID = new SelectList(db.DriveTypes, "DriveTypeID", SharedStorage.Instance.GetDropDownBindValue("DriveTypeV"));
                ViewBag.AutoUsedStatusID = new SelectList(db.AutoUsedStatus, "AutoUsedStatusID", SharedStorage.Instance.GetDropDownBindValue("UsedStatus"));
                if (fuelTypeID > 0)
                {
                    ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "FuelTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), fuelTypeID);
                }
                else
                {
                    ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "FuelTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"));
                }
                ViewBag.InventoryStatusID = new SelectList(db.InventoryStatus, "InventoryStatusID", SharedStorage.Instance.GetDropDownBindValue("Status"));
                ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"));
                ViewBag.SubModelID = new SelectList(db.SubModels, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
                ViewBag.YearID = new SelectList(db.Years, "YearID", SharedStorage.Instance.GetDropDownBindValue("YearName"));
                ViewBag.AutoAirBagID = new SelectList(db.AutoAirBags, "AutoAirBagID", SharedStorage.Instance.GetDropDownBindValue("Value"));


                ViewBag.VehicleTitleID = new SelectList(db.VehclieTitles, "VehicleTitleID", SharedStorage.Instance.GetDropDownBindValue("Title"));
                ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"));
                ViewBag.MediaPlayerID = new SelectList(db.MediaPlayers, "MediaPlayerID", SharedStorage.Instance.GetDropDownBindValue("PlayerName"));
                ViewBag.RoofTypeID = new SelectList(db.RoofTypes, "RoofTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"));
                ViewBag.UpholsteryID = new SelectList(db.Upholsteries, "UpholsteryID", SharedStorage.Instance.GetDropDownBindValue("Name"));



                //ViewBag.MilageID = new SelectList(db.Milages, "MilageID", "Value");
                var wizard = new VehicleWizard();
                var userId = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => d.UserID).FirstOrDefault();
                wizard.CreatedDate = DateTime.Now;
                wizard.UpdateDate = DateTime.Now;
                wizard.UserID = userId;
                db.VehicleWizards.Add(wizard);
                db.SaveChanges();
                return View(wizard);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        // POST: VehicleWizards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Wizard(VehicleWizard vehicleWizard)
        {
            try
            {
                var userId = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => d.UserID).FirstOrDefault();

                vehicleWizard.CreatedDate = DateTime.Now;
                vehicleWizard.UpdateDate = DateTime.Now;
                vehicleWizard.UserID = userId;
                vehicleWizard.InventoryStatusID = 2; // Pending status
                vehicleWizard.IsDeleted = false;
                if (vehicleWizard.VehicleID == 0)
                {
                    vehicleWizard.Has360 = true;
                    db.VehicleWizards.Add(vehicleWizard);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { successMessage = "Congrats! Inventory created" });
                }
                else
                {
                    var wizard = db.VehicleWizards.Where(d => d.VehicleID == vehicleWizard.VehicleID).FirstOrDefault();

                    // add status change history
                    new UtilityRepository().AddInventoryStatusHistory(userId, wizard.VehicleID, wizard.InventoryStatusID, vehicleWizard.InventoryStatusID);

                    wizard.InventoryStatusID = vehicleWizard.InventoryStatusID;
                    wizard.StockNumber = vehicleWizard.StockNumber;
                    wizard.MMCode = vehicleWizard.MMCode;
                    wizard.PlateNumber = vehicleWizard.PlateNumber;


                    wizard.VIN = vehicleWizard.VIN;
                    wizard.YearID = vehicleWizard.YearID;
                    wizard.MakerID = vehicleWizard.MakerID;
                    wizard.AutoModelID = vehicleWizard.AutoModelID;
                    wizard.SubModelID = vehicleWizard.SubModelID;
                    wizard.FreeText = vehicleWizard.FreeText;

                    wizard.Odometer = vehicleWizard.Odometer;
                    wizard.AutoInteriorColorID = vehicleWizard.AutoInteriorColorID;
                    wizard.AutoSteeringID = vehicleWizard.AutoSteeringID;
                    wizard.AutoDoorsID = vehicleWizard.AutoDoorsID;
                    wizard.AutoEngineID = vehicleWizard.AutoEngineID;
                    wizard.AutoTransmissionID = vehicleWizard.AutoTransmissionID;
                    wizard.FuelTypeID = vehicleWizard.FuelTypeID;
                    wizard.DriveTypeID = vehicleWizard.DriveTypeID;
                    wizard.CreatedDate = vehicleWizard.CreatedDate;
                    wizard.UpdateDate = vehicleWizard.UpdateDate;
                    wizard.WarantyText = vehicleWizard.WarantyText;
                    wizard.Description = vehicleWizard.Description;
                    wizard.UserID = vehicleWizard.UserID;
                    wizard.AutoAirBagID = vehicleWizard.AutoAirBagID;

                    wizard.UpholsteryID = vehicleWizard.UpholsteryID;
                    wizard.RoofTypeID = vehicleWizard.RoofTypeID;
                    wizard.VehicleTitleID = vehicleWizard.VehicleTitleID;
                    wizard.VehicleTypeID = vehicleWizard.VehicleTypeID;
                    wizard.VehicleAudioID = vehicleWizard.VehicleAudioID;
                    wizard.VehicleInteriorTypeID = vehicleWizard.VehicleInteriorTypeID;


                    wizard.MediaPlayerID = vehicleWizard.MediaPlayerID;
                    wizard.VehicleOptions = vehicleWizard.VehicleOptions;
                    wizard.VehicleMoreOptions = vehicleWizard.VehicleMoreOptions;
                    wizard.ArabicVehicleMoreOptions = vehicleWizard.ArabicVehicleMoreOptions;
                    wizard.VehicleFlags = vehicleWizard.VehicleFlags;
                    wizard.VehiclemoreFlags = vehicleWizard.VehiclemoreFlags;
                    wizard.ArabicVehicleMoreFlags = vehicleWizard.ArabicVehicleMoreFlags;
                    wizard.VehicleAddressId = vehicleWizard.VehicleAddressId;
                    wizard.ExteriorRatting = vehicleWizard.ExteriorRatting;
                    wizard.InteriorRatting = vehicleWizard.InteriorRatting;
                    wizard.MechanicsRatting = vehicleWizard.MechanicsRatting;
                    wizard.FrameRatting = vehicleWizard.FrameRatting;
                    wizard.TotalRatting = vehicleWizard.TotalRatting;
                    wizard.VIRCompletenessPercentage = vehicleWizard.VIRCompletenessPercentage;
                    wizard.VehiclePrice = vehicleWizard.VehiclePrice;
                    wizard.PurchasingCost = vehicleWizard.PurchasingCost;
                    wizard.IsDeleted = false;
                    wizard.LanguageID = vehicleWizard.LanguageID;
                    wizard.IsFeatured = vehicleWizard.IsFeatured;
                    wizard.AutoUsedStatusID = vehicleWizard.AutoUsedStatusID;

                    db.SaveChanges();
                    return RedirectToAction("Index", new { successMessage = "Congrats! Inventory created" });
                }




                ViewBag.AutoDoorsID = new SelectList(db.AutoDoors, "AutoDoorsID", SharedStorage.Instance.GetDropDownBindValue("Doors"), vehicleWizard.AutoDoorsID);
                ViewBag.AutoEngineID = new SelectList(db.AutoEngines, "AutoEngineID", SharedStorage.Instance.GetDropDownBindValue("EngineName"), vehicleWizard.AutoEngineID);
                ViewBag.AutoExteriorColorID = new SelectList(db.AutoExteriorColors, "AutoExteriorColorID", SharedStorage.Instance.GetDropDownBindValue("ExteriorColor"), vehicleWizard.AutoExteriorColorID);
                ViewBag.AutoInteriorColorID = new SelectList(db.AutoInteriorColors, "AutoInteriorColorID", SharedStorage.Instance.GetDropDownBindValue("InteriorColor"), vehicleWizard.AutoInteriorColorID);
                ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.AutoModelID);
                ViewBag.AutoSteeringID = new SelectList(db.AutoSteerings, "AutoSteeringID", SharedStorage.Instance.GetDropDownBindValue("Steering"), vehicleWizard.AutoSteeringID);
                ViewBag.AutoTransmissionID = new SelectList(db.AutoTransmissions, "AutoTransmissionID", SharedStorage.Instance.GetDropDownBindValue("Transmission"), vehicleWizard.AutoTransmissionID);
                ViewBag.DriveTypeID = new SelectList(db.DriveTypes, "DriveTypeID", SharedStorage.Instance.GetDropDownBindValue("DriveTypeV"), vehicleWizard.DriveTypeID);
                ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "FuelTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.FuelTypeID);
                ViewBag.InventoryStatusID = new SelectList(db.InventoryStatus, "InventoryStatusID", SharedStorage.Instance.GetDropDownBindValue("Status"), vehicleWizard.InventoryStatusID);
                ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), vehicleWizard.MakerID);
                ViewBag.SubModelID = new SelectList(db.SubModels, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.SubModelID);
                ViewBag.YearID = new SelectList(db.Years, "YearID", SharedStorage.Instance.GetDropDownBindValue("YearName"), vehicleWizard.YearID);
                ViewBag.AutoAirBagID = new SelectList(db.AutoAirBags, "AutoAirBagID", SharedStorage.Instance.GetDropDownBindValue("Value"), vehicleWizard.AutoAirBagID);


                ViewBag.VehicleTitleID = new SelectList(db.VehclieTitles, "VehicleTitleID", SharedStorage.Instance.GetDropDownBindValue("Title"), vehicleWizard.VehicleTitleID);
                ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.VehicleTypeID);
                ViewBag.MediaPlayerID = new SelectList(db.MediaPlayers, "MediaPlayerID", SharedStorage.Instance.GetDropDownBindValue("PlayerName"), vehicleWizard.MediaPlayerID);
                ViewBag.RoofTypeID = new SelectList(db.RoofTypes, "RoofTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.RoofTypeID);
                ViewBag.UpholsteryID = new SelectList(db.Upholsteries, "UpholsteryID", SharedStorage.Instance.GetDropDownBindValue("Name"), vehicleWizard.UpholsteryID);



                //ViewBag.MilageID = new SelectList(db.Milages, "MilageID", "Value",vehicleWizard.MilageID);

                return View(vehicleWizard);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        // GET: VehicleWizards/Edit/5
        public ActionResult Edit(long? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                AutoMax.Models.DataModel.VehicleWizardViewModel vehicleWizard = db.VehicleWizards.Where(d => d.VehicleID == id).Select(d => new
                AutoMax.Models.DataModel.VehicleWizardViewModel
                {
                    VehicleID = d.VehicleID,
                    InventoryStatusID = d.InventoryStatusID,
                    StockNumber = d.StockNumber,
                    MMCode = d.MMCode,
                    PlateNumber = d.PlateNumber,
                    VIN = d.VIN,
                    YearID = d.YearID,
                    MakerID = d.MakerID,
                    AutoModelID = d.AutoModelID,
                    SubModelID = d.SubModelID != null ? d.SubModelID.Value : 0,
                    FreeText = d.FreeText,

                    Odometer = d.Odometer,
                    AutoExteriorColorID = d.AutoExteriorColorID.Value,
                    AutoInteriorColorID = d.AutoInteriorColorID.Value,
                    AutoSteeringID = d.AutoSteeringID.Value,
                    AutoDoorsID = d.AutoDoorsID.Value,
                    AutoEngineID = d.AutoEngineID.Value,
                    AutoTransmissionID = d.AutoTransmissionID.Value,
                    FuelTypeID = d.FuelTypeID.Value,
                    DriveTypeID = d.DriveTypeID.Value,
                    CreatedDate = d.CreatedDate,


                    UpdateDate = d.UpdateDate,
                    VehiclePriceValue = d.VehiclePrice.Value,
                    WarantyText = d.WarantyText,
                    Description = d.Description,
                    UserID = d.UserID,
                    AutoAirBagID = d.AutoAirBagID.Value,



                }
                ).FirstOrDefault();

                if (vehicleWizard == null)
                {
                    return HttpNotFound();
                }



                ViewBag.AutoDoorsID = new SelectList(db.AutoDoors, "AutoDoorsID", SharedStorage.Instance.GetDropDownBindValue("Doors"), vehicleWizard.AutoDoorsID);
                ViewBag.AutoEngineID = new SelectList(db.AutoEngines, "AutoEngineID", SharedStorage.Instance.GetDropDownBindValue("EngineName"), vehicleWizard.AutoEngineID);
                ViewBag.AutoExteriorColorID = new SelectList(db.AutoExteriorColors, "AutoExteriorColorID", SharedStorage.Instance.GetDropDownBindValue("ExteriorColor"), vehicleWizard.AutoExteriorColorID);
                ViewBag.AutoInteriorColorID = new SelectList(db.AutoInteriorColors, "AutoInteriorColorID", SharedStorage.Instance.GetDropDownBindValue("InteriorColor"), vehicleWizard.AutoInteriorColorID);
                ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.AutoModelID);
                ViewBag.AutoSteeringID = new SelectList(db.AutoSteerings, "AutoSteeringID", SharedStorage.Instance.GetDropDownBindValue("Steering"), vehicleWizard.AutoSteeringID);
                ViewBag.AutoTransmissionID = new SelectList(db.AutoTransmissions, "AutoTransmissionID", SharedStorage.Instance.GetDropDownBindValue("Transmission"), vehicleWizard.AutoTransmissionID);
                ViewBag.DriveTypeID = new SelectList(db.DriveTypes, "DriveTypeID", SharedStorage.Instance.GetDropDownBindValue("DriveTypeV"), vehicleWizard.DriveTypeID);
                ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "FuelTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.FuelTypeID);
                ViewBag.InventoryStatusID = new SelectList(db.InventoryStatus, "InventoryStatusID", SharedStorage.Instance.GetDropDownBindValue("Status"), vehicleWizard.InventoryStatusID);
                ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), vehicleWizard.MakerID);
                ViewBag.SubModelID = new SelectList(db.SubModels, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.SubModelID);
                ViewBag.YearID = new SelectList(db.Years, "YearID", SharedStorage.Instance.GetDropDownBindValue("YearName"), vehicleWizard.YearID);
                ViewBag.AutoAirBagID = new SelectList(db.AutoAirBags, "AutoAirBagID", SharedStorage.Instance.GetDropDownBindValue("Value"), vehicleWizard.AutoAirBagID);


                ViewBag.VehicleTitleID = new SelectList(db.VehclieTitles, "VehicleTitleID", SharedStorage.Instance.GetDropDownBindValue("Title"), vehicleWizard.VehicleTitleID);

                return View(vehicleWizard);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        // POST: VehicleWizards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleWizard vehicleWizard)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(vehicleWizard).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }



                ViewBag.AutoDoorsID = new SelectList(db.AutoDoors, "AutoDoorsID", SharedStorage.Instance.GetDropDownBindValue("Doors"), vehicleWizard.AutoDoorsID);
                ViewBag.AutoEngineID = new SelectList(db.AutoEngines, "AutoEngineID", SharedStorage.Instance.GetDropDownBindValue("EngineName"), vehicleWizard.AutoEngineID);
                ViewBag.AutoExteriorColorID = new SelectList(db.AutoExteriorColors, "AutoExteriorColorID", SharedStorage.Instance.GetDropDownBindValue("ExteriorColor"), vehicleWizard.AutoExteriorColorID);
                ViewBag.AutoInteriorColorID = new SelectList(db.AutoInteriorColors, "AutoInteriorColorID", SharedStorage.Instance.GetDropDownBindValue("InteriorColor"), vehicleWizard.AutoInteriorColorID);
                ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.AutoModelID);
                ViewBag.AutoSteeringID = new SelectList(db.AutoSteerings, "AutoSteeringID", SharedStorage.Instance.GetDropDownBindValue("Steering"), vehicleWizard.AutoSteeringID);
                ViewBag.AutoTransmissionID = new SelectList(db.AutoTransmissions, "AutoTransmissionID", SharedStorage.Instance.GetDropDownBindValue("Transmission"), vehicleWizard.AutoTransmissionID);
                ViewBag.DriveTypeID = new SelectList(db.DriveTypes, "DriveTypeID", SharedStorage.Instance.GetDropDownBindValue("DriveTypeV"), vehicleWizard.DriveTypeID);
                ViewBag.FuelTypeID = new SelectList(db.FuelTypes, "FuelTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), vehicleWizard.FuelTypeID);
                ViewBag.InventoryStatusID = new SelectList(db.InventoryStatus, "InventoryStatusID", SharedStorage.Instance.GetDropDownBindValue("Status"), vehicleWizard.InventoryStatusID);
                ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), vehicleWizard.MakerID);
                ViewBag.SubModelID = new SelectList(db.SubModels, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.SubModelID);
                ViewBag.YearID = new SelectList(db.Years, "YearID", SharedStorage.Instance.GetDropDownBindValue("YearName"), vehicleWizard.YearID);
                ViewBag.SubModelID = new SelectList(db.SubModels, "SubModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), vehicleWizard.SubModelID);
                ViewBag.YearID = new SelectList(db.Years, "YearID", SharedStorage.Instance.GetDropDownBindValue("YearName"), vehicleWizard.YearID);
                ViewBag.AutoAirBagID = new SelectList(db.AutoAirBags, "AutoAirBagID", SharedStorage.Instance.GetDropDownBindValue("Value"), vehicleWizard.AutoAirBagID);


                ViewBag.VehicleTitleID = new SelectList(db.VehclieTitles, "VehicleTitleID", SharedStorage.Instance.GetDropDownBindValue("Title"), vehicleWizard.VehicleTitleID);

                return View(vehicleWizard);
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult UpdateFeaturedImages(int[] ImageIDs)
        {
            try
            {
                for (var i = 0; i < ImageIDs.Length; i++)
                {
                    var imgId = ImageIDs[i];
                    var image = db.VehicleImages.Where(d => d.VehicleImageID == imgId).FirstOrDefault();
                    image.DisplayOrder = i + 1;
                    db.SaveChanges();
                }
                return Json(new { OrderUpdated = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { OrderUpdated = false }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: VehicleWizards/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == id);
            if (vehicleWizard == null)
            {
                return HttpNotFound();
            }
            return View(vehicleWizard);
        }

        // POST: VehicleWizards/Delete/5
        [HttpPost]
        public ActionResult DeleteInventory(long VehicleID)
        {
            try
            {
                VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == VehicleID);
                vehicleWizard.IsDeleted = true;
                db.SaveChanges();
                return Json(new { InventoryDeleted = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { InventoryDeleted = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteAllInventory(List<string> VehicleID)
        {
            try
            {
                VehicleWizard vehicleWizard;
                long id;
                foreach (var vID in VehicleID)
                {
                    id = long.Parse(vID);
                    vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == id);
                    if (vehicleWizard != default(VehicleWizard))
                        vehicleWizard.IsDeleted = true;
                }
                db.SaveChanges();
                return Json(new { InventoryDeleted = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { InventoryDeleted = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PostToOpensooq(int PublishVehicleIdOpensooq, string TitleOpensooq, string DescriptionOpensooq
            , bool PublishPriceOpensooq = false, bool NegotiableOpensooq = false)
        {
            ActionResult result = PostToWebsite(PublishVehicleIdOpensooq, TitleOpensooq, DescriptionOpensooq, "Opensooq", PublishPriceOpensooq, NegotiableOpensooq);
            if (result != null)
            {
                TempData["message"] = "1";
                return result;
            }
            else
            {
                TempData["message"] = "0";
                return RedirectToAction("Index");
            }
        }
        public ActionResult PostToHaraj(int PublishVehicleIdHaraj, string TitleHaraj, string DescriptionHaraj, bool PublishPriceHaraj = false, bool NegotiableHaraj = false)
        {
            ActionResult result = PostToWebsite(PublishVehicleIdHaraj, TitleHaraj, DescriptionHaraj, "Haraj", PublishPriceHaraj, NegotiableHaraj);
            if (result != null)
            {
                TempData["message"] = "1";
                return result;
            }
            else
            {
                TempData["message"] = "0";
                return RedirectToAction("Index");
            }
        }
        private ActionResult PostToWebsite(int PublishVehicleId, string Title, string Description, string PostingSite, bool PublishPrice = false, bool Negotiable = false, string postingStatus = "Pending")
        {
            if (string.IsNullOrEmpty(Title.Trim()) == false && string.IsNullOrEmpty(Description.Trim()) == false)
            {
                Description = Description.Replace("\t", "");
                VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == PublishVehicleId);
                PostingDetail pd = db.PostingDetail.FirstOrDefault(d => d.VehicleWizard.VehicleID == PublishVehicleId && d.PostingSite.PostingSiteName == PostingSite);

                if (pd == null)
                {
                    pd = new PostingDetail
                    {
                        VehicleWizard = vehicleWizard
                        ,
                        PostingTitle = Title
                        ,
                        PostingDescription = Description
                        ,
                        PublishPrice = PublishPrice
                        ,
                        Negotiable = Negotiable
                        ,
                        VehicleWizardId = vehicleWizard.VehicleID
                        ,
                        PostingStatus = db.PostingStatus.FirstOrDefault(p => p.StatusName == postingStatus)
                        ,
                        PostingSite = db.PostingSite.FirstOrDefault(p => p.PostingSiteName == PostingSite)
                        ,
                        RetryCount = 0
                        ,
                        Retries = int.Parse(PostingLibrary.Library.GetPostingConfiguration("PostingRetries", "4"))
                        ,
                        CreatedDate = DateTime.Now
                        ,
                        UpdatedDate = DateTime.Now
                    };
                    db.PostingDetail.Add(pd);
                }
                else
                {
                    pd.PostingTitle = Title;
                    pd.PostingDescription = Description;
                    pd.PublishPrice = PublishPrice;
                    pd.Negotiable = Negotiable;
                    pd.PostingStatus = db.PostingStatus.FirstOrDefault(p => p.StatusName == postingStatus);
                    pd.Retries = int.Parse(PostingLibrary.Library.GetPostingConfiguration("PostingRetries", "4"));
                    pd.RetryCount = 0;
                    pd.UpdatedDate = DateTime.Now;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult GetPostingFields(int PublishVehicleId, string PostingWebsite, string language)
        {
            try
            {
                PostingDetail pd = db.PostingDetail.Include("PostingStatus").FirstOrDefault(d => d.VehicleWizard.VehicleID == PublishVehicleId && d.PostingSite.PostingSiteName == PostingWebsite);
                if (pd == null)
                {
                    var postingDetailsGeneration = PostingDetailsGeneratorFactory.Instance.GetPostingDetailsGenerator(language);
                    postingDetailsGeneration.Initialize(db, PublishVehicleId, PostingWebsite);
                    postingDetailsGeneration.Generate();

                    var fields = new
                    {
                        Success = true
                        ,
                        Title = postingDetailsGeneration.Title
                        ,
                        Description = postingDetailsGeneration.Description
                        ,
                        PostingStatus = "N/A"
                        ,
                        PostingError = "N/A"
                    };
                    return Json(fields, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var fields = new
                    {
                        Success = true
                        ,
                        Title = pd.PostingTitle
                        ,
                        Description = pd.PostingDescription
                        ,
                        PostingStatus = pd.PostingStatus.StatusName
                        ,
                        PostingError = pd.PostingError == null ? "N/A" : pd.PostingError
                    };
                    return Json(fields, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var fields = new { Success = false, Error = ex.ToString() };
                return Json(fields, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult MakeFeaturedVehilce(long VehicleID, bool IsFeatured)
        {
            try
            {
                var invenObj = db.VehicleWizards.Find(VehicleID);
                invenObj.IsFeatured = IsFeatured;
                db.SaveChanges();
                return Json(new { Featured = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Featured = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public void FaceBook(string id = null, string code = null)
        {
            try
            {
                string app_id = WebConfigurationManager.AppSettings["app_id"];
                string app_secret = WebConfigurationManager.AppSettings["app_secret"];
                string scope = WebConfigurationManager.AppSettings["scope"];

                if (Request["code"] == null)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        Session["VehPostId"] = id;
                        string url = string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}", app_id, Request.Url.AbsoluteUri, scope);
                        Response.Redirect(url, false);
                    }
                }
                else
                {
                    string message = "";
                    string title = "";
                    int Id = Convert.ToInt32(Session["VehPostId"].ToString());
                    Session["VehPostId"] = null;
                    InventoryRespository rep = new InventoryRespository();
                    var veh = rep.GetInventoryViewModelDetail(Id).Data as VehicleViewModel;
                    List<AutoMax.Models.Entities.VehicleVideoViewModel> vehicleVideos = new VIRRepository().LoadVehicleVideos(Id).Data as List<AutoMax.Models.Entities.VehicleVideoViewModel>;

                    Dictionary<string, string> tokens = new Dictionary<string, string>();

                    //string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                        app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);
                    HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string vals = reader.ReadToEnd();
                        foreach (string token in vals.Split('&'))
                        {
                            tokens.Add(token.Substring(0, token.IndexOf("=")),
                                token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                        }
                    }

                    string access_token = tokens["access_token"];

                    var client = new FacebookClient(access_token);

                    string pageAccessToken = "";
                    JsonObject jsonResponse = client.Get("me/accounts") as JsonObject;
                    foreach (var account in (JsonArray)jsonResponse["data"])
                    {
                        string accountName = (string)(((JsonObject)account)["name"]);

                        if (accountName == WebConfigurationManager.AppSettings["facebookName"])
                        {
                            pageAccessToken = (string)(((JsonObject)account)["access_token"]);
                            break;
                        }
                    }

                    client = new FacebookClient(pageAccessToken);
                    dynamic parameters = new ExpandoObject();
                    message = "";
                    title = "";
                    if (veh.VehiclePrice != null)
                    {
                        message += "Price: " + veh.VehiclePrice + " SAR";
                    }
                    if (!string.IsNullOrEmpty(veh.Description))
                    {
                        message += veh.Description;
                    }
                    else if (!string.IsNullOrEmpty(veh.FreeText))
                    {
                        message += veh.FreeText;
                    }
                    if (vehicleVideos.Count > 0)
                    {
                        message += " please follow our video here:" + vehicleVideos.FirstOrDefault().VideoPath;
                    }
                    parameters.message = message;
                    title = veh.Maker + " " + veh.AutoModelName + " " + veh.SubModelName;
                    parameters.name = title;
                    List<AutoMax.Models.Entities.VehicleImage> imgList = new VIRRepository().LoadVehicleImages(Id, "VehicleAttachments/").Data as List<AutoMax.Models.Entities.VehicleImage>;
                    JsonObject result = client.Post("/me/albums", parameters) as JsonObject;
                    if (result != null)
                    {
                        var albumId = result["id"].ToString();
                        WebClient _webClient = new WebClient();

                        int i = 0;
                        foreach (var image in imgList)
                        {
                            i++;
                            dynamic imageParameters = new ExpandoObject();
                            //parameters.message = "Latest Picture"; // Picture Caption
                            imageParameters.source = new FacebookMediaObject
                            {
                                ContentType = "image/jpeg",
                                FileName = Path.GetFileName("VVG Image" + i)
                            }.SetValue(_webClient.DownloadData(image.ImagePath.StartsWith("http://") ? image.ImagePath : WebConfigurationManager.AppSettings["dmsUrl"] + image.ImagePath));
                            client.Post("/" + albumId + "/photos", imageParameters);
                        }
                    }

                    PostToWebsite(Id, title, message, "Facebook", false, false, "Posted");
                    var VeichleWizard = db.VehicleWizards.Where(z => z.VehicleID == Id).FirstOrDefault();
                    if (VeichleWizard != null)
                    {
                        VeichleWizard.IsFacebook = true;

                        db.Entry(VeichleWizard).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    Response.Redirect("~/Inventory/Index?facebook=success");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Inventory/Index?facebook=failure");
            }


        }

        private dynamic PostVegonR(int id)
        {
            InventoryRespository rep = new InventoryRespository();
            var veh = rep.GetInventoryViewModelDetail(id).Data as VehicleViewModel;
            StringBuilder builder = new StringBuilder();
            if (veh.VehiclePrice != null)
            {
                builder.Append("<b>Price:</b>" + veh.VehiclePrice + " SAR" + "<br/>");
            }
            builder.Append("<b>Mileage:</b>" + veh.Milage + " <br/>");
            builder.Append("<b>Category:</b>" + veh.AutoModelName + " <br/>");
            builder.Append("<b>Colour:</b>" + veh.InteriorColor + " <br/>");
            builder.Append("<b>Steering:</b>" + veh.AutoSteering + " <br/>");
            builder.Append("<b>Steering:</b>" + veh.AutoSteering + " <br/>");
            builder.Append("<b>Number of Airbag:</b>" + veh.AutoAirBag + " <br/>");
            builder.Append("<b>Wheels:</b>" + veh.DriveType + " <br/>");
            builder.Append("<b>Gears:</b>" + veh.AutoTransmission + " <br/>");
            builder.Append("<b>Engine:</b>" + veh.EngineName + " <br/>");
            builder.AppendLine();
            var img = "";
            if (!string.IsNullOrEmpty(veh.ImageName))
            {


                img = "http://dms.automax.online/" + "VehicleAttachments/" + veh.ImageName;

            }
            else if (!string.IsNullOrEmpty(veh.ImageName2))
            {


                img = "http://dms.automax.online/" + "VehicleAttachments/" + veh.ImageName2;

            }
            else
            {
                img = "http://blog.caranddriver.com/wp-content/uploads/2014/03/2015-Nissan-GT-R-NISMO-placement-626x382.jpg";
            }
            dynamic parameters = new ExpandoObject();
            parameters.message = veh.YearName + " " + veh.Maker + " " + veh.AutoModelName + " " + veh.SubModelName;
            parameters.link = "http://automax.online/Vehicle?id=" + id; //"http://www.paksuzuki.com.pk/Automobile/Pages/Home.aspx";
            parameters.picture = img; //"https://cache2.pakwheels.com/system/car_generation_pictures/2780/original/1.PNG?1442841508";
            parameters.name = veh.YearName + " " + veh.Maker + " " + veh.AutoModelName + " " + veh.SubModelName;
            parameters.caption = veh.VehiclePrice != null ? @String.Format("{0:#,##0.00}", veh.VehiclePrice) + "SAR" : "";
            parameters.description = builder.ToString();
            return parameters;

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Post()
        {
            try
            {
                const string app_id = "1643904349238448";
                const string app_secret = "996f2227bf15018cfa8d257181a89e0e";
                const string scope = "publish_actions,publish_pages,manage_pages,user_photos";
                var images = new string[]
                      {
                          "https://cache2.pakwheels.com/system/car_generation_pictures/2970/original/Suzuki-wagaoR_PKDM.jpg?1444116705",
                          "https://cache2.pakwheels.com/system/car_generation_pictures/2780/original/1.PNG?1442841508",
                          "https://cache2.pakwheels.com/system/car_generation_pictures/2781/original/2.PNG?1442841508",
                          "https://cache2.pakwheels.com/system/car_generation_pictures/2782/original/3.PNG?1442841509",
                          "https://cache2.pakwheels.com/system/car_generation_pictures/3854/original/cabin.jpg?1451546674"
                      };

                if (Request["code"] == null)
                {
                    string url = string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope);
                    Response.Redirect(url, false);
                }
                else
                {
                    ViewBag.Message = PostData(app_id, scope, app_secret, "Suzuki Wagon For Sale", "Suzuki Wagon R VXL 2019. RS: 1069000", "", images);
                }
            }
            catch (Exception exp)
            {
                ViewBag.Message = exp.Message;
            }
            return View();
        }
        private bool PostData(int id)
        {

            return true;
        }
        private string PostData(string app_id, string scope, string app_secret, string tag, string description, string videolink, string[] images)
        {
            try
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

                HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string vals = reader.ReadToEnd();

                    foreach (string token in vals.Split('&'))
                    {
                        tokens.Add(token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                    }
                }

                string access_token = tokens["access_token"];

                var client = new FacebookClient(access_token);

                string pageAccessToken = "";
                JsonObject jsonResponse = client.Get("me/accounts") as JsonObject;
                foreach (var account in (JsonArray)jsonResponse["data"])
                {
                    string accountName = (string)(((JsonObject)account)["name"]);

                    if (accountName == "Car Bazar")
                    {
                        pageAccessToken = (string)(((JsonObject)account)["access_token"]);
                        break;
                    }
                }

                client = new FacebookClient(pageAccessToken);
                dynamic parameters = new ExpandoObject();
                var message = description + videolink;
                parameters.message = message;
                parameters.name = tag;
                JsonObject result = client.Post("/me/albums", parameters) as JsonObject;
                if (result != null)
                {
                    var albumId = result["id"].ToString();
                    WebClient _webClient = new WebClient();

                    int i = 0;
                    foreach (var image in images)
                    {
                        i++;
                        dynamic imageParameters = new ExpandoObject();
                        //parameters.message = "Latest Picture"; // Picture Caption
                        imageParameters.source = new FacebookMediaObject
                        {
                            ContentType = "image/jpeg",
                            FileName = Path.GetFileName("VVG Image" + i)
                        }.SetValue(_webClient.DownloadData(image));
                        client.Post("/" + albumId + "/photos", imageParameters);
                    }
                }
                return "Successfully Uploded on Facebook";
            }
            catch (Exception exp)
            {
                return exp.Message;
            }

        }

    }
}
