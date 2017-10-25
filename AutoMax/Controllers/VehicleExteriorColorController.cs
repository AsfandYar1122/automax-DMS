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
    public class VehicleExteriorColorController : BaseController
    {
        public ActionResult Index(int? page, int pageSize = 10, string Name = "")
        {
            this.ValidateAdminUser();
            ViewBag.Name = Name;
            var autoInteriorColors = db.AutoExteriorColors.ToList();
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(Name))
            {
                autoInteriorColors = autoInteriorColors.Where(d => d.ExteriorColor.Contains(Name)).ToList();
            }
            autoInteriorColors = autoInteriorColors.OrderBy(d => d.ExteriorColor).ToList();
            ViewBag.Name = Name;
            int pageNumber = (page ?? 1);
            return View(autoInteriorColors.ToPagedList(pageNumber, pgSz));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.ValidateAdminUser();

            AutoExteriorColor model = new AutoExteriorColor();
            if (id != 0)
            {
                model = db.AutoExteriorColors.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AutoExteriorColor viewModel)
        {
            this.ValidateAdminUser();
            try
            {
                if (string.IsNullOrEmpty(viewModel.ExteriorColor)) ModelState.AddModelError("ExteriorColor", "This field is required.");
                if (ModelState.IsValid)
                {
                    AutoExteriorColor model;
                    if (viewModel.AutoExteriorColorID != 0)
                    {
                        model = db.AutoExteriorColors.Find(viewModel.AutoExteriorColorID);
                        if (model == null)
                        {
                            return HttpNotFound();
                        }
                        else
                        {
                            model.ExteriorColor = viewModel.ExteriorColor;
                            model.ArabicExteriorColor = viewModel.ArabicExteriorColor;
                            model.Value = viewModel.Value;
                            model.UpdatedDate = DateTime.Now;
                            db.SaveChanges();
                            this.SetFlashMessage();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        model = new AutoExteriorColor();
                        model.ExteriorColor = viewModel.ExteriorColor;
                        model.ArabicExteriorColor = viewModel.ArabicExteriorColor;
                        model.Value = viewModel.Value;
                        model.CreatedDate = model.UpdatedDate = DateTime.Now;
                        model.CreatedBy = model.UpdatedBy = 1; // HACK : Hardcoded value represents Admin user

                        db.AutoExteriorColors.Add(model);
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
                bool hasVehicles = db.VehicleWizards.Any(x => x.AutoExteriorColorID == ID);
                if (hasVehicles)
                {
                    result= Json(new { IsDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    AutoExteriorColor model = db.AutoExteriorColors.FirstOrDefault(d => d.AutoExteriorColorID == ID);
                    db.AutoExteriorColors.Remove(model);
                    db.SaveChanges();
                    result = Json(new { IsDeleted = true, Message = AutoMax.Utility.Constants.SUCCESSFULLY_DELETED }, JsonRequestBehavior.AllowGet);
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