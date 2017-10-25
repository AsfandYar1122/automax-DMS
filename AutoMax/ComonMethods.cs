using AutoMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMax
{
    public static class ComonMethods
    {
        public static string GetUserName(string emil)
        {
            AutoMaxContext db = new AutoMaxContext();
            return db.Users.Where(d => d.Email == emil).Select(d => new { FullName = d.UserName }).FirstOrDefault().FullName;
        }
        public static string GetUserRole(this string email)
        {
            AutoMaxContext db = new AutoMaxContext();
            return db.Users.Where(d => d.Email == email).Select(d => d.UserRole.Role).FirstOrDefault();
        }
        public static string GetFullName(string emil)
        {
            AutoMaxContext db = new AutoMaxContext();
            return db.Users.Where(d => d.Email == emil).Select(d => new { FullName = d.FirstName + " " + d.LastName }).FirstOrDefault().FullName;
        }
    }
}