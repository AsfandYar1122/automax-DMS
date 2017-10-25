using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Sql;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMax.Models;
using System.IO;
using Newtonsoft.Json;
using AutoMax.Models.Entities;
using PagedList.Mvc;
using PagedList;
using AutoMax.Models.DataModel;

namespace AutoMax.Controllers
{
    public class BaseController : Controller
    {
        protected AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();


        protected void ValidateAdminUser()
        {
            var user = db.Users.Where(d => d.Email == User.Identity.Name).Select(d => new { d.UserID, d.UserRole.Role }).FirstOrDefault();
            if (user.Role != "Admin" && user.Role!= "Marketing")
            {
                throw new Exception("You are not allowed to perform this action. Please contact administrator.");
            }
        }

        protected void SetFlashMessage(string message = "Record has been successfully saved.", bool isError = false)
        {
            TempData["Message"] = message;
            TempData["HasError"] = isError;
        }
    }
}