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
    public class MakersController : BaseController
    {
        
        // GET: Makers
        public ActionResult Index(int? page, string Name, int pageSize = 10, string Type="")
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin" && user.Role != UserRolesConst.Marketing)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.Name = Name;
            ViewBag.Type = Type;
            var makers = db.Makers.Include(m => m.Language).Include(d=>d.VehicleType);
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(Type))
            {
                makers = makers.Where(d => d.VehicleType.Type == Type);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                makers = makers.Where(d => d.Name == Name);
            }
            makers = makers.OrderBy(d => d.Name);
            ViewBag.Name = Name;
            ViewBag.Type = Type;
            int pageNumber = (page ?? 1);
            return View(makers.ToPagedList(pageNumber, pgSz));
        }

        // GET: Makers/Create
        public ActionResult Create()
        {
            var model = new Maker();
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"));
            return View(model);
        }

        // POST: Makers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Maker maker)
        {
            var objVT = db.Makers.Where(d => d.Name == maker.Name && d.VehicleTypeID== maker.VehicleTypeID).Count();
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), maker.VehicleTypeID);
            if (objVT > 0)
            {
                ModelState.AddModelError("", "Maker already exists!");
                return View(maker);
            }
            //maker.LanguageID = 1;
            maker.CreatedBy = 1;
            maker.CreatedDate = DateTime.Now;
            maker.UpdatedBy = 1;
            maker.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Makers.Add(maker);
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), maker.VehicleTypeID);
            return View(maker);
        }

        // GET: Makers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maker maker = db.Makers.Find(id);
            if (maker == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), maker.VehicleTypeID);
            return View(maker);
        }

        // POST: Makers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Maker maker)
        {
            maker.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(maker).State = EntityState.Modified;
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleTypeID = new SelectList(db.VehicleTypes, "VehicleTypeID", SharedStorage.Instance.GetDropDownBindValue("Type"), maker.VehicleTypeID);
            return View(maker);
        }

        [HttpPost, ActionName("DeleteMaker")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool hasVehicles = db.VehicleWizards.Any(x => x.MakerID == id);
                bool hasModel = db.AutoModels.Any(x => x.MakerID == id);
                if (hasVehicles)
                {
                    return Json(new { IsDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else if (hasModel)
                {
                    return Json(new { IsDeleted = false, Message = string.Format(AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_MODEL_INFO, "Auto Model") }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Maker maker = db.Makers.Find(id);
                    db.Makers.Remove(maker);
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
