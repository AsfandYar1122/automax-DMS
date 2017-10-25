using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMax.Models;
using AutoMax.Models.Entities;
using PagedList;
using AutoMax.Models.Common;
using AutoMax.Common.Enums;

namespace AutoMax.Controllers
{
    [Authorize]
    public class SubModelsController : BaseController
    {


        // GET: VehicleTrims
        public ActionResult Index(int? page, string Name, int pageSize = 10, string AutoModel = "")
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin" && user.Role != UserRolesConst.Marketing)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.Name = Name;
            ViewBag.AutoModel = AutoModel;
            var subModels = db.SubModels.Include(v => v.Language).Include(v => v.AutoModel);
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(AutoModel))
            {
                subModels = subModels.Where(d => d.AutoModel.ModelName == AutoModel);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                subModels = subModels.Where(d => d.ModelName == Name);
            }
            subModels = subModels.OrderBy(d => d.ModelName);
            ViewBag.AutoModel = AutoModel;
            ViewBag.Name = Name;
            int pageNumber = (page ?? 1);
            return View(subModels.ToPagedList(pageNumber, pgSz));
        }

        // GET: VehicleTrims/Create
        public ActionResult Create()
        {
            var trimModel = new SubModel();
            ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"));
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", SharedStorage.Instance.GetDropDownBindValue("Name"));
            return View(trimModel);
        }

        // POST: VehicleTrims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubModel subModelName)
        {
            var objVT = db.SubModels.Where(d => d.ModelName == subModelName.ModelName && d.AutoModelID == subModelName.AutoModelID).Count();
            if (objVT > 0)
            {
                ModelState.AddModelError("", "Model already exists!");
                ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), subModelName.AutoModelID);
                return View(subModelName);
            }
            try
            {
                //vehicleTrim.LanguageID = 1;
                subModelName.CreatedBy = 1;
                subModelName.CreatedDate = DateTime.Now;
                subModelName.UpdatedBy = 1;
                subModelName.UpdatedDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    db.SubModels.Add(subModelName);
                    db.SaveChanges();
                    this.SetFlashMessage();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), subModelName.AutoModelID);
                ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", SharedStorage.Instance.GetDropDownBindValue("Name"), subModelName.LanguageID);
                return View(subModelName);
            }
            ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), subModelName.AutoModelID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", SharedStorage.Instance.GetDropDownBindValue("Name"), subModelName.LanguageID);
            return View(subModelName);
        }

        // GET: VehicleTrims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubModel subModelName = db.SubModels.Find(id);
            if (subModelName == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", SharedStorage.Instance.GetDropDownBindValue("Name"), subModelName.LanguageID);
            ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), subModelName.AutoModelID);
            return View(subModelName);
        }

        // POST: VehicleTrims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubModel subModelName)
        {
            subModelName.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(subModelName).State = EntityState.Modified;
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", SharedStorage.Instance.GetDropDownBindValue("Name"), subModelName.LanguageID);
            ViewBag.AutoModelID = new SelectList(db.AutoModels, "AutoModelID", SharedStorage.Instance.GetDropDownBindValue("ModelName"), subModelName.AutoModelID);
            return View(subModelName);
        }

        // POST: VehicleTrims/Delete/5
        [HttpPost, ActionName("DeleteSubModel")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int SubModelID)
        {
            try
            {
                bool hasVehicles = db.VehicleWizards.Any(x => x.SubModelID == SubModelID);
                if (hasVehicles)
                {
                    return Json(new { IsDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SubModel SubModel = db.SubModels.Find(SubModelID);
                    db.SubModels.Remove(SubModel);
                    db.SaveChanges();
                    return Json(new { IsDeleted = true, Message = AutoMax.Utility.Constants.SUCCESSFULLY_DELETED }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsDeleted = false, Message = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
