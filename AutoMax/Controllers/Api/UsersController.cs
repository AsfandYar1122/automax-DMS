using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMax.Models;
using AutoMax.Models.Entities;
using System.Net.Mail;

namespace AutoMax.Controllers.Api
{
    public class UserManagementController : ApiController
    {
        private AutoMaxContext db = new AutoMaxContext();
        public ResultSetViewModel ForgotPassword(string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var objUser = db.Users.Where(d => d.Email == email).FirstOrDefault();
                    if (objUser != null)
                    {
                        try
                        {
                            var fromAddress = new MailAddress("dev.automax@gmail.com", "AutoMax");
                            var toAddress = new MailAddress(email);
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

                            return new ResultSetViewModel("Email sent successfully with password instruction.");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        throw new Exception("User does not exist, please try again. Thanks");
                    }
                }

                throw new Exception("Please enter valid email and try again. Thanks");
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
    }

    public class UsersController : ApiController
    {
        private AutoMaxContext db = new AutoMaxContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUserById(long id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string email, string password)
        {
            password = EncrypterDecrypter.Encrypt(password);
            User user = db.Users.Where(d => d.Email == email && d.Password == password).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(long id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(long id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(long id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}