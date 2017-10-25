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
using System.Net.Mail;
using PagedList.Mvc;
using PagedList;

namespace AutoMax.Controllers
{
    public class UsersController : BaseController
    {


        // GET: Users
        public ActionResult Index(int? page, string Email = "", string FirstName = "", string LastName = "", int? pageSize = 10)
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin")
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            Email = Email.Trim();
            FirstName = FirstName.Trim();
            LastName = LastName.Trim();
            var users = from s in db.Users
                            //where s.UserRole.Role !="Admin"
                        orderby s.Email ascending
                        select s;
            List<User> list = users.Include(d => d.UserRole).ToList();
            int pgSz = pageSize.Value;
            if (!string.IsNullOrEmpty(Email))
            {
                list = list.Where(d => d.Email == Email).ToList();
            }
            if (!string.IsNullOrEmpty(FirstName))
            {
                list = list.Where(d => d.FirstName == FirstName).ToList();
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                list = list.Where(d => d.LastName.ToString() == LastName).ToList();
            }
            ViewBag.Email = Email;
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pgSz));
        }

        // GET: Users/Create
        public ActionResult Register()
        {
            var model = new User();
            return View(model);
        }
        public ActionResult Create()
        {
            var model = new User();

            List<SelectListItem> rolesDropdown = new List<SelectListItem>();
            // HACK : Default role is User
            foreach (var item in db.UserRoles)
                rolesDropdown.Add(new SelectListItem { Value = item.UserRoleID.ToString(), Text = item.Role, Selected = (item.UserRoleID == 3) });

            ViewBag.UserRoleID = rolesDropdown;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            user.LinkExpiryDate = DateTime.Now;
            user.IsActive = true;
            user.CreatedBy = 1;
            user.UpdatedBy = 1;
            var objUser = db.Users.Where(d => d.Email == user.Email).Count();
            if (objUser == 0)
            {
                if (ModelState.IsValid)
                {
                    if (!user.UserRoleID.HasValue) user.UserRoleID = 3; // HACK : default is User

                    user.Password = EncrypterDecrypter.Encrypt(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    base.SetFlashMessage("User has been successfully saved.");
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "User Already Exists");
                return View(user);
            }
            List<SelectListItem> rolesDropdown = new List<SelectListItem>();
            foreach (var item in db.UserRoles)
                rolesDropdown.Add(new SelectListItem { Value = item.UserRoleID.ToString(), Text = item.Role });
            ViewBag.UserRoleID = rolesDropdown;

            return View(user);
        }
        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            user.LinkExpiryDate = DateTime.Now;
            user.IsActive = true;
            user.CreatedBy = 1;
            user.UpdatedBy = 1;
            user.UserRoleID = 3;
            user.Password = EncrypterDecrypter.Encrypt(user.Password);
            var objUser = db.Users.Where(d => d.Email == user.Email).Count();
            if (objUser == 0)
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    base.SetFlashMessage("User has been successfully saved.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "User Already Exists");
                return View(user);
            }
            return View(user);
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objUser = db.Users.Where(d => d.Email == model.Email).FirstOrDefault();
                if (objUser != null)
                {
                    try
                    {
                        var fromAddress = new MailAddress("dev.automax@gmail.com", "AutoMax");
                        var toAddress = new MailAddress(model.Email);
                        const string fromPassword = "PasswordAutoMax";
                        const string subject = "Forgot Password";
                        var tokenis = Guid.NewGuid().ToString();
                        string body = "Dear " + objUser.FirstName + " " + objUser.LastName + ", <br/ ><br/ >"
+ "Please find below a reminder of your password as requested. This message has been sent only to the email address used in your account. <br/ ><br/ >"
+ "Your Password is : <b>" + EncrypterDecrypter.Decrypt(objUser.Password) + "</b> <br/ ><br/ >"
+ "Thank you for your patience. Have a nice day ! <br/ ><br/ >Regards,<br/ >Support Team<br/ >Automax";
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            IsBodyHtml = true,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }
                        ViewBag.EmailID = model.Email;
                        return View(model);
                    }
                    catch (Exception)
                    {
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Doesn't exists");
                    return View(model);
                }
            }
            ModelState.AddModelError("", "Please enter valid emial");
            return View(model);

        }
        public ActionResult ResetPassword(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError("", "Link is expired or invalid");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userObje = db.Users.Where(d => d.Email == model.Email).FirstOrDefault();
                if (userObje != null)
                {
                    userObje.Password = EncrypterDecrypter.Encrypt(model.Password);
                    db.SaveChanges();
                    ViewBag.UpdateMessage = "Success";
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Password & Confirm Password doesn't match");
                return View(model);
            }
            return View();
        }
        public ActionResult ChangePassword()
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).FirstOrDefault();
            ViewBag.UpdateMessage = "";
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            bool updated = false;
            if (ModelState.IsValid)
            {
                if (model.NewPassword == model.ConfirmPassword)
                {
                    var userObject = db.Users.Where(d => d.Email == User.Identity.Name).FirstOrDefault();
                    if (userObject != null)
                    {
                        userObject.Password = EncrypterDecrypter.Encrypt(model.NewPassword);
                        db.SaveChanges();
                        updated = true;
                    }
                    else
                    {
                        updated = false;
                        ModelState.AddModelError("", "Please enter valid information");
                    }
                }
            }
            else
            {
                updated = false;
                ModelState.AddModelError("", "Please enter valid information");
            }
            ViewBag.UpdateMessage = updated == true ? "Successfully updated" : "";
            return View(model);
        }
        // GET: Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            user.Password = EncrypterDecrypter.Decrypt(user.Password);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserRoleID = new SelectList(db.UserRoles, "UserRoleID", "Role", user.UserRoleID);

            return View(user);
        }

        [HttpPost]
        public ActionResult PasswordMatched(string Password)
        {
            var userExists = db.Users.Where(d => d.Email == User.Identity.Name && d.Password == Password).Count();
            bool userAvail = userExists == 0 ? false : true;
            return Json(new { PasswordMatched = userAvail }, JsonRequestBehavior.AllowGet);
        }
        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = EncrypterDecrypter.Encrypt(user.Password);
                user.UpdatedDate = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                base.SetFlashMessage("User has been successfully saved.");
                return RedirectToAction("Index");
            }
            ViewBag.UserRoleID = new SelectList(db.UserRoles, "UserRoleID", "Role", user.UserRoleID);
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult DeleteUser(long UserID)
        {
            try
            {
                bool hasUser = db.VehicleWizards.Any(x => x.UserID == UserID);
                if (hasUser)
                {
                    return Json(new { UserDeleted = false, Message = AutoMax.Utility.Constants.CAN_NOT_DELETE_AS_USED_IN_VEHICLE_INFO }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    User user = db.Users.Find(UserID);
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return Json(new { UserDeleted = true, Message = AutoMax.Utility.Constants.SUCCESSFULLY_DELETED }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { UserDeleted = false, Message = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UserExists(string Email)
        {
            try
            {
                var user = db.Users.Where(d => d.Email == Email).Count();
                bool exists = user > 0 ? true : false;
                return Json(new { UserAvailable = exists }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { UserAvailable = false }, JsonRequestBehavior.AllowGet);
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
