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
using AutoMax.Models.DataModel;

namespace AutoMax.Controllers
{
    public class AutoEngineController : BaseController
    {
        public ActionResult Index(int? page, int pageSize = 10, string Name = "")
        {
            this.ValidateAdminUser();

            var models = db.AutoEngines.ToList();
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(Name))
            {
                models = models.Where(d => d.EngineName.Contains(Name)).ToList();
            }
            models = models.OrderBy(d => d.EngineName).ToList();
            ViewBag.Name = Name;
            int pageNumber = (page ?? 1);
            return View(models.ToPagedList(pageNumber, pgSz));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.ValidateAdminUser();

            AutoEngine model = new AutoEngine();
            if (id != 0)
            {
                model = db.AutoEngines.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AutoEngine viewModel)
        {
            this.ValidateAdminUser();
            try
            {
                if (string.IsNullOrEmpty(viewModel.EngineName)) ModelState.AddModelError("EngineName", "This field is required.");
                if (ModelState.IsValid)
                {
                    AutoEngine model;
                    if (viewModel.AutoEngineID != 0)
                    {
                        model = db.AutoEngines.Find(viewModel.AutoEngineID);
                        if (model == null)
                        {
                            return HttpNotFound();
                        }
                        else
                        {
                            model.EngineName = viewModel.EngineName;
                            model.ArabicEngineName = viewModel.ArabicEngineName;
                            model.UpdatedDate = DateTime.Now;
                            db.SaveChanges();
                            this.SetFlashMessage();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        model = new AutoEngine();
                        model.EngineName = viewModel.EngineName;
                        model.ArabicEngineName = viewModel.ArabicEngineName;
                        model.CreatedDate = model.UpdatedDate = DateTime.Now;
                        model.CreatedBy = model.UpdatedBy = 1; // HACK : Hardcoded value represents Admin user

                        db.AutoEngines.Add(model);
                        db.SaveChanges();
                        this.SetFlashMessage();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetFlashMessage("Some Error occured. Error : " + ex.Message, isError: true);
                // log exception  ex.Message
            }
            return View(viewModel);

        }

        // POST: 
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                bool hasVehicles = db.VehicleWizards.Any(x => x.AutoEngineID == ID);
                if (hasVehicles)
                {
                    return Json(new { IsDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AutoEngine model = db.AutoEngines.FirstOrDefault(d => d.AutoEngineID == ID);
                    db.AutoEngines.Remove(model);
                    db.SaveChanges();
                    return Json(new { IsDeleted = true, Message = AutoMax.Utility.Constants.SUCCESSFULLY_DELETED }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsDeleted = false, Message = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}