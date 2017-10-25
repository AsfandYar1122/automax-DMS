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
    [Authorize]
    public class VehicleInteriorColorController : BaseController
    {
        public ActionResult Index(int? page, int pageSize = 10, string Name = "")
        {
            this.ValidateAdminUser();
            ViewBag.Name = Name;
            var autoInteriorColors = db.AutoInteriorColors.ToList();
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(Name))
            {
                autoInteriorColors = autoInteriorColors.Where(d => d.InteriorColor.Contains(Name)).ToList();
            }
            autoInteriorColors = autoInteriorColors.OrderBy(d => d.InteriorColor).ToList();
            ViewBag.Name = Name;
            int pageNumber = (page ?? 1);
            return View(autoInteriorColors.ToPagedList(pageNumber, pgSz));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.ValidateAdminUser();

            AutoInteriorColor model = new AutoInteriorColor();
            if (id != 0)
            {
                model = db.AutoInteriorColors.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AutoInteriorColor viewModel)
        {
            this.ValidateAdminUser();
            try
            {
                if (string.IsNullOrEmpty(viewModel.InteriorColor)) ModelState.AddModelError("InteriorColor", "This field is required.");
                if (ModelState.IsValid)
                {
                    AutoInteriorColor model;
                    if (viewModel.AutoInteriorColorID != 0)
                    {
                        model = db.AutoInteriorColors.Find(viewModel.AutoInteriorColorID);
                        if (model == null)
                        {
                            return HttpNotFound();
                        }
                        else
                        {
                            model.InteriorColor = viewModel.InteriorColor;
                            model.ArabicInteriorColor = viewModel.ArabicInteriorColor;
                            model.Value = viewModel.Value;
                            model.UpdatedDate = DateTime.Now;
                            db.SaveChanges();
                            this.SetFlashMessage();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        model = new AutoInteriorColor();
                        model.InteriorColor = viewModel.InteriorColor;
                        model.ArabicInteriorColor = viewModel.ArabicInteriorColor;
                        model.Value = viewModel.Value;
                        model.CreatedDate = model.UpdatedDate = DateTime.Now;
                        model.CreatedBy = model.UpdatedBy = 1; // HACK : Hardcoded value represents Admin user

                        db.AutoInteriorColors.Add(model);
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
        public ActionResult DeleteColor(int ID)
        {
            JsonResult result;
            try
            {
                bool hasVehicles = db.VehicleWizards.Any(x => x.AutoInteriorColorID == ID);
                if (hasVehicles)
                {
                    result = Json(new { IsDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AutoInteriorColor model = db.AutoInteriorColors.FirstOrDefault(d => d.AutoInteriorColorID == ID);
                    db.AutoInteriorColors.Remove(model);
                    db.SaveChanges();
                    result = Json(new { IsDeleted = true, AutoMax.Utility.Constants.SUCCESSFULLY_DELETED }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                result = Json(new { IsDeleted = false, Message = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
            return result;
        }
    }
}