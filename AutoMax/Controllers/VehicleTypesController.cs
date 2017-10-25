using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMax.Common.Enums;
using AutoMax.Models;
using AutoMax.Models.Entities;
using PagedList;

namespace AutoMax.Controllers
{
    [Authorize]
    public class VehicleTypesController : BaseController
    {
        

        // GET: VehicleTypes
        public ActionResult Index(int? page, string Type, int pageSize = 10)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin" && user.Role != UserRolesConst.Marketing)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.Type = Type;
            var vehicleTypes = db.VehicleTypes.Include(v => v.Language);
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(Type))
            {
                vehicleTypes = vehicleTypes.Where(d => d.Type == Type);
            }
            vehicleTypes = vehicleTypes.OrderBy(d => d.Type);
            ViewBag.Type = Type;
            int pageNumber = (page ?? 1);
            return View(vehicleTypes.ToPagedList(pageNumber, pgSz));
        }

        // GET: VehicleTypes/Create
        public ActionResult Create()
        {
            var model = new VehicleType();
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name");
            return View(model);
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleType vehicleType)
        {
            var typeExists = db.VehicleTypes.Where(d => d.Type == vehicleType.Type).Count();
            if (typeExists > 0)
            {
                ModelState.AddModelError("", "Type already exists!");
                return View(vehicleType);
            }
            //vehicleType.LanguageID = 1;
            vehicleType.CreatedBy = 1;
            vehicleType.CreatedDate = DateTime.Now;
            vehicleType.UpdatedBy = 1;
            vehicleType.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.VehicleTypes.Add(vehicleType);
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name", vehicleType.LanguageID);
            return View(vehicleType);
        }

        // GET: VehicleTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicleType = db.VehicleTypes.Find(id);
            if (vehicleType == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name", vehicleType.LanguageID);
            return View(vehicleType);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleType vehicleType)
        {
            vehicleType.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(vehicleType).State = EntityState.Modified;
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name", vehicleType.LanguageID);
            return View(vehicleType);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("DeleteType")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int VehicleTypeID)
        {
            try
            {
                bool hasVehicles = db.VehicleWizards.Any(x => x.VehicleTypeID == VehicleTypeID);
                bool hasMaker = db.Makers.Any(x => x.VehicleTypeID == VehicleTypeID);
                if (hasVehicles)
                {
                    return Json(new { IsDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else if (hasMaker)
                {
                    return Json(new { IsDeleted = false, Message = string.Format(AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_MODEL_INFO, "Maker") }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    VehicleType vehicleType = db.VehicleTypes.Where(d => d.VehicleTypeID == VehicleTypeID).FirstOrDefault();
                    db.VehicleTypes.Remove(vehicleType);
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
