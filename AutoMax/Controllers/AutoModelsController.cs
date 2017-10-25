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
    public class AutoModelsController : BaseController
    {


        // GET: AutoModels
        public ActionResult Index(int? page, string Name, int pageSize = 10, string Maker = "")
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin" && user.Role!= UserRolesConst.Marketing)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.Maker = Maker;
            ViewBag.Name = Name;
            var autoModels = db.AutoModels.Include(m => m.Language).Include(m => m.Maker);
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(Maker))
            {
                autoModels = autoModels.Where(d => d.Maker.Name == Maker);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                autoModels = autoModels.Where(d => d.ModelName == Name);
            }
            autoModels = autoModels.OrderBy(d => d.ModelName);
            ViewBag.Name = Name;
            ViewBag.Maker = Maker;
            int pageNumber = (page ?? 1);
            return View(autoModels.ToPagedList(pageNumber, pgSz));
        }
        // GET: AutoModels/Create
        public ActionResult Create()
        {
            var model = new AutoModel();
            ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"));
            return View(model);
        }

        // POST: AutoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutoModel autoModel)
        {
            var modeExist = db.AutoModels.Where(d => d.MakerID == autoModel.MakerID && d.ModelName == autoModel.ModelName).Count();
            if (modeExist > 0)
            {
                ModelState.AddModelError("", "Model already exists!");
                return View(autoModel);
            }
            autoModel.CreatedBy = 1;
            autoModel.CreatedDate = DateTime.Now;
            autoModel.UpdatedBy = 1;
            autoModel.UpdatedDate = DateTime.Now;
            //autoModel.LanguageID = 1;
            if (ModelState.IsValid)
            {
                db.AutoModels.Add(autoModel);
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }
            ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), autoModel.MakerID);
            return View(autoModel);
        }

        // GET: AutoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoModel autoModel = db.AutoModels.Find(id);
            if (autoModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), autoModel.MakerID);
            return View(autoModel);
        }

        // POST: AutoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AutoModel autoModel)
        {
            autoModel.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(autoModel).State = EntityState.Modified;
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }
            ViewBag.MakerID = new SelectList(db.Makers, "MakerID", SharedStorage.Instance.GetDropDownBindValue("Name"), autoModel.MakerID);
            return View(autoModel);
        }
        // POST: AutoModels/Delete/5
        [HttpPost, ActionName("DeleteModel")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool hasVehicles = db.VehicleWizards.Any(x => x.AutoModelID == id);
                bool hasSubModel = db.SubModels.Any(x => x.AutoModelID == id);

                if (hasVehicles)
                {
                    return Json(new { IsDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else if (hasSubModel)
                {
                    return Json(new { IsDeleted = false, Message = string.Format(AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_MODEL_INFO, "Sub Model") }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AutoModel autoModel = db.AutoModels.Find(id);
                    db.AutoModels.Remove(autoModel);
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
