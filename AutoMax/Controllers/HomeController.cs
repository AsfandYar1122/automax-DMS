using AutoMax.Common.Enums;
using AutoMax.Common.Helpers;
using AutoMax.Models;
using AutoMax.Models.Common;
using AutoMax.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AutoMax.Controllers
{
    public class HomeController : Controller
    {
        private AutoMaxContext db = new AutoMaxContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("~/Dashboard/Index");
            }
            else
            {
                return Redirect("~/Home/Login");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userRole = null;
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect("~/Dashboard/Index");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
            else
            {
                ViewBag.ReturnUrl = ReturnUrl;
                return View();
            }

        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
            {
                try
                {
                    
                    var password = EncrypterDecrypter.Encrypt(model.Password);
                    var userObj = db.Users.Where(d => d.Email == model.Email && d.Password == password).FirstOrDefault();
                    if (userObj != null)
                    {
                        if (!userObj.IsActive)
                        {
                            ModelState.AddModelError("", "User account is Inactive");
                            return View(model);
                        }
                        FormsAuthentication.SetAuthCookie(userObj.Email, true);
                        string URL = "";
                        if (string.IsNullOrEmpty(ReturnUrl))
                        {
                           
                            return Redirect("~/Dashboard/Index");
                        }
                        else
                        {
                            return Redirect(ReturnUrl);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please enter correct email address or password");
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Please enter correct email address or password");
                    return View(model);
                }
            }
            else
            {
                ViewBag.ReturnUrl = ReturnUrl;
                return View(model);
            }
        }
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                return Redirect("~/Home/Login");
            }
            return Redirect("~/Home/Login");
        }
        public string ChangeCulture(string culture)
        {
            try
            {
                CultureHelper.Set(AppHelper.ParseEnum<Culture>(culture.ToUpper()));
                return "success";
            }
            catch
            {
                return "error";
            }
        }


        public string Ftp(string host = @"ftp://ftp.dealermade.co",
            string user = "dealermade-numou",
            string password = "qRHVMefyQbNaPY2Q7k")
        {
            //string localFilePath = @"E:\Projects\Automax\Data\Export.csv";
            string localFilePath = System.Web.HttpContext.Current.Server.MapPath("~/ftp/Export.csv");

            var result = new FTPRepository().UploadData(localFilePath, host, user, password);
            return result.Message;
        }


        public ActionResult backup()
        {
            var path = DBBackupRepository.TakeBackup();

            byte[] filedata = System.IO.File.ReadAllBytes(path);
            string contentType = MimeMapping.GetMimeMapping(path);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = Path.GetFileName(path),
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}