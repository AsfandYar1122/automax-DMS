using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMax.Models.Entities;
using AutoMax.Models;


namespace AutoMax.Controllers
{
    public class PublishSettingsController : Controller
    {
        private AutoMaxContext db = new AutoMaxContext();

        // GET: /PublishSettings/
        public ActionResult Index()
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin" && user.Role != "Marketing")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var postingfield = db.PostingField.Include(p => p.PostingSite);
            //return View(postingfield.ToList());
            return IndexbySiteID(1);//return 1 only
        }
        public ActionResult PublishItem()
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View();
        }
        public ActionResult IndexbySiteID(int? id)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postingfield = db.PostingField.Include(p => p.PostingSite).Where(p => p.PostingSiteID == id).OrderBy(p => p.IncludeInPosting).ThenBy(p => p.IncludeOrder);
            return View(postingfield.ToList());
        }
        // GET: /PublishSettings/Details/5
        public ActionResult Details(int? id)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingField postingfield = db.PostingField.Find(id);
            if (postingfield == null)
            {
                return HttpNotFound();
            }
            return View(postingfield);
        }
        public ActionResult Save(int? id, string[] multiselect_to)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Request.Form["Save"] != null)
            {
                var postingFields = db.PostingField.Where(p => p.IncludeInPosting == true && p.PostingSiteID == id).ToList();
                postingFields.ForEach(p => p.IncludeInPosting = false);

                for (int i = 0; i < multiselect_to.Count(); i++)
                {
                    var currentString = multiselect_to[i];
                    var postingField = db.PostingField.FirstOrDefault(p => p.PostingSiteID == id && p.FieldName == currentString);
                    postingField.IncludeInPosting = true;
                    postingField.IncludeOrder = i + 1;
                }
                db.SaveChanges();
            }
            return RedirectToAction("IndexbySiteID/" + id);
        }

        // GET: /PublishSettings/Create
        public ActionResult Create()
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.PostingSiteID = new SelectList(db.PostingSite, "PostingSiteID", "PostingSiteName");
            return View();
        }

        // POST: /PublishSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostingFieldID,PostingSiteID,FieldName,IncludeInPosting,IncludeOrder,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] PostingField postingfield)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (ModelState.IsValid)
            {
                db.PostingField.Add(postingfield);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostingSiteID = new SelectList(db.PostingSite, "PostingSiteID", "PostingSiteName", postingfield.PostingSiteID);
            return View(postingfield);
        }

        // GET: /PublishSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingField postingfield = db.PostingField.Find(id);
            if (postingfield == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostingSiteID = new SelectList(db.PostingSite, "PostingSiteID", "PostingSiteName", postingfield.PostingSiteID);
            return View(postingfield);
        }

        // POST: /PublishSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostingFieldID,PostingSiteID,FieldName,IncludeInPosting,IncludeOrder,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] PostingField postingfield)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (ModelState.IsValid)
            {
                db.Entry(postingfield).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostingSiteID = new SelectList(db.PostingSite, "PostingSiteID", "PostingSiteName", postingfield.PostingSiteID);
            return View(postingfield);
        }

        // GET: /PublishSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingField postingfield = db.PostingField.Find(id);
            if (postingfield == null)
            {
                return HttpNotFound();
            }
            return View(postingfield);
        }

        // POST: /PublishSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostingField postingfield = db.PostingField.Find(id);
            db.PostingField.Remove(postingfield);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult MakeMapping(string companyName)
        {
            ActionResult result = RedirectToAction("PublishItem");
            try
            {
                // only to avoid exceptions without parameters, setting default parameters
                if (string.IsNullOrEmpty(companyName)) companyName = AutoMax.Common.Enums.PostingSites.HARAJ.ToString();


                List<Models.DataModel.MakeMappingListViewModel> viewModel = new List<Models.DataModel.MakeMappingListViewModel>();
                ViewBag.CompanyName = companyName;
                if (companyName.Equals(AutoMax.Common.Enums.PostingSites.HARAJ.ToString()))
                {
                    viewModel = db.Database.SqlQuery<Models.DataModel.MakeMappingListViewModel>(
                                        @"Select   m.MakerID as ID, m.Name as MakeName, count(am.MakerID) as TotalCount  , count(amm.HarajName) as MappedCount
                                    from Makers m
                                    left join AutoModels am on am.MakerID = m.MakerID
                                    left join AutoModelMappings amm on m.MakerID = am.MakerID and amm.AutoModelID = am.AutoModelID
                                    group by m.MakerID, m.Name
                                    order by m.Name asc").ToList();
                    result = View(viewModel);
                }
                else if (companyName.Equals(AutoMax.Common.Enums.PostingSites.OPENSOUQ.ToString()))
                {
                    viewModel = db.Database.SqlQuery<Models.DataModel.MakeMappingListViewModel>(
                                        @"Select   m.MakerID as ID, m.Name as MakeName, count(am.MakerID) as TotalCount  , count(amm.OpensooqName) as MappedCount
                                    from Makers m
                                    left join AutoModels am on am.MakerID = m.MakerID
                                    left join AutoModelMappings amm on m.MakerID = am.MakerID and amm.AutoModelID = am.AutoModelID
                                    group by m.MakerID, m.Name
                                    order by m.Name asc").ToList();
                    result = View(viewModel);
                }
            }
            catch (Exception e)
            {
                result = RedirectToAction("PublishItem");
                this.SetFlashMessage("Some error occured. Error " + e.ToString(), isError: true);
            }
            return result;
        }

        [HttpGet]
        public ActionResult AddMakeMapping(string companyName, int ID)
        {
            ActionResult result = RedirectToAction("PublishItem");
            Models.DataModel.MakeMappingViewModel viewModel = new Models.DataModel.MakeMappingViewModel();
            viewModel.CompanyName = companyName;
            viewModel.ID = ID;

            // load Maker info
            Maker entity = db.Makers.FirstOrDefault(x => x.MakerID == ID);
            if (entity != default(Maker))
            {
                viewModel.EntityName = entity.Name;

                // load and sets Maker mapping for Company if exist
                MakerMapping entityMapping = db.MakerMapping.FirstOrDefault(x => x.MakerId == ID);
                if (entityMapping != default(MakerMapping))
                {
                    if (companyName.Equals(AutoMax.Common.Enums.PostingSites.HARAJ.ToString()))
                    {
                        viewModel.EntityNameForCompany = entityMapping.HarajName;
                    }
                    else if (companyName.Equals(AutoMax.Common.Enums.PostingSites.OPENSOUQ.ToString()))
                    {
                        viewModel.EntityNameForCompany = entityMapping.OpensooqName;
                    }
                }
                var autoModels = db.AutoModels.Where(x => x.MakerID == entity.MakerID).ToList();
                var autoModelIDs = autoModels.Select(x => x.AutoModelID).ToList();
                var autoModelsWithMapping = db.AutoModelMapping.Where(x => autoModelIDs.Contains(x.AutoModelID)).ToList();

                viewModel.MappingIDNames = new List<Models.DataModel.MappingIDName>();
                foreach (var item in autoModels)
                {
                    var map = autoModelsWithMapping.FirstOrDefault(x => x.AutoModelID == item.AutoModelID);
                    viewModel.MappingIDNames.Add(new Models.DataModel.MappingIDName
                    {
                        MappingID = item.AutoModelID,
                        MappingName = item.ModelName,
                        MappingNameForCompany = (map != null ? (companyName.Equals(AutoMax.Common.Enums.PostingSites.HARAJ.ToString()) ? map.HarajName : map.OpensooqName) : "")
                    });
                }

                result = View(viewModel);
            }
            return result;
        }

        [HttpPost]
        public ActionResult AddMakeMapping(Models.DataModel.MakeMappingViewModel viewModel)
        {
            ActionResult result;

            try
            {
                AddOrUpdateMakerInfoForCompany(db, viewModel);

                if (viewModel.MappingIDNames != null && viewModel.MappingIDNames.Any())
                {
                    foreach (Models.DataModel.MappingIDName item in viewModel.MappingIDNames)
                    {
                        AddOrUpdateAutoModelForCompany(db, viewModel, item);
                    }
                }

                // commit changes
                db.SaveChanges();
                SetFlashMessage("Mapping has been successfully saved.");
            }
            catch (Exception ex)
            {
                SetFlashMessage("Some error occured. Error : " + ex.ToString(), isError: true);
            }

            result = RedirectToAction("MakeMapping", new { companyName = viewModel.CompanyName });
            return result;

        }

        // save AutoModel info For Company
        private void AddOrUpdateAutoModelForCompany(AutoMaxContext database, Models.DataModel.MakeMappingViewModel viewModel, Models.DataModel.MappingIDName item)
        {
            AutoModelMapping amm = database.AutoModelMapping.FirstOrDefault(x => x.AutoModelID == item.MappingID);
            if (amm == default(AutoModelMapping))
            {
                amm = new AutoModelMapping();
                amm.CreatedBy = amm.UpdatedBy = 1;
                amm.CreatedDate = amm.UpdatedDate = DateTime.Now;
                amm.AutoModelID = item.MappingID;
            }
            else
                amm.UpdatedDate = DateTime.Now;


            if (viewModel.CompanyName.Equals(AutoMax.Common.Enums.PostingSites.HARAJ.ToString()))
                amm.HarajName = item.MappingNameForCompany;
            else if (viewModel.CompanyName.Equals(AutoMax.Common.Enums.PostingSites.OPENSOUQ.ToString()))
                amm.OpensooqName = item.MappingNameForCompany;

            // add new if not exist
            if (amm.AutoModelMappingID == 0)
                database.AutoModelMapping.Add(amm);
        }

        // save Maker info For Company
        private void AddOrUpdateMakerInfoForCompany(AutoMaxContext database, Models.DataModel.MakeMappingViewModel viewModel)
        {
            MakerMapping mm = database.MakerMapping.FirstOrDefault(x => x.MakerId == viewModel.ID);
            if (mm == default(MakerMapping))
            {
                mm = new MakerMapping();
                mm.CreatedBy = mm.UpdatedBy = 1;
                mm.CreatedDate = mm.UpdatedDate = DateTime.Now;
                mm.MakerId = viewModel.ID;
            }
            else
                mm.UpdatedDate = DateTime.Now;


            if (viewModel.CompanyName.Equals(AutoMax.Common.Enums.PostingSites.HARAJ.ToString()))
                mm.HarajName = viewModel.EntityNameForCompany;
            else if (viewModel.CompanyName.Equals(AutoMax.Common.Enums.PostingSites.OPENSOUQ.ToString()))
                mm.OpensooqName = viewModel.EntityNameForCompany;

            // add new if not exist
            if (mm.MakerMappingID == 0)
                database.MakerMapping.Add(mm);
        }

        protected void SetFlashMessage(string message = "Record has been successfully saved.", bool isError = false)
        {
            TempData["Message"] = message;
            TempData["HasError"] = isError;
        }

    }
}
