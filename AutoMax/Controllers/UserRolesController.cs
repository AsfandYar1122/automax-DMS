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
using PagedList.Mvc;
using PagedList;

namespace AutoMax.Controllers
{
    public class UserRolesController : BaseController
    {
        

        // GET: UserRoles
        public ActionResult Index(int? page,string Role, int pageSize= 10)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var sqlQuery = "SELECT        UserRoleID, Role, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate , (SELECT COUNT(*) From [Users] USS Where USS.UserRoleID = UserRoles.UserRoleID) TotalUsers FROM  UserRoles";

            var users = db.Database.SqlQuery<AutoMax.Models.DataModel.UserRoleViewModel>(sqlQuery).OrderBy(d=>d.Role).ToList();

            List<AutoMax.Models.DataModel.UserRoleViewModel> list = users.ToList();
            int pgSz = pageSize;
            if (!string.IsNullOrEmpty(Role))
            {
                list = list.Where(d => d.Role == Role).ToList();
            }
            ViewBag.Role = Role;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pgSz));
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserRoleID,Role,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userRole);
                db.SaveChanges();

                this.SetFlashMessage();
                return RedirectToAction("Index");
            }

            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserRoleID,Role,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                userRole.UpdatedDate = DateTime.Now;
                db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                this.SetFlashMessage();
                return RedirectToAction("Index");
            }
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost]
        public ActionResult DeleteUserRole(int RoleID)
        {
            try
            {
                UserRole userRole = db.UserRoles.Find(RoleID);
                db.UserRoles.Remove(userRole);
                db.SaveChanges();
                return Json(new { RoleDeleted = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { RoleDeleted = false }, JsonRequestBehavior.AllowGet);
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
