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

namespace AutoMax.Controllers.Api
{
    public class InventoryController : ApiController
    {
        private AutoMaxContext db = new AutoMaxContext();

        // GET: api/Inventory
        public IQueryable<VehicleWizard> GetVehicleWizards()
        {
            return db.VehicleWizards;
        }

        // GET: api/Inventory/5
        [ResponseType(typeof(VehicleWizard))]
        public IHttpActionResult GetVehicleWizard(string VIN)
        {
            try
            {
                //var lst = db.VehicleWizards.Where(a => a.VIN != null).Select(a => a.VIN.Substring(a.VIN.Length - 6)).ToList();
                //var vehicleWizard = db.VehicleWizards.Where(d => d.VIN.Contains(VIN)).ToList();
                var vehicleWizard = db.VehicleWizards.Where(d => (d.IsDeleted == null || d.IsDeleted == false) && (d.VIN == VIN || (d.VIN != null && d.VIN.Substring(d.VIN.Length - 6).Contains(VIN)))).ToList();

                if (vehicleWizard.Count == 0)
                {
                    throw new Exception("No record found for this VIN.");
                }

                return Ok(vehicleWizard);
            }
            catch (Exception ex)
            {
                return Ok(new ResultSetViewModel(ex));
            }
        }

        // PUT: api/Inventory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleWizard(long id, VehicleWizard vehicleWizard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleWizard.VehicleID)
            {
                return BadRequest();
            }

            db.Entry(vehicleWizard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleWizardExists(id))
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

        // POST: api/Inventory
        [ResponseType(typeof(VehicleWizard))]
        public IHttpActionResult PostVehicleWizard(VehicleWizard vehicleWizard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleWizards.Add(vehicleWizard);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = vehicleWizard.VehicleID }, vehicleWizard);
        }

        // DELETE: api/Inventory/5
        [ResponseType(typeof(VehicleWizard))]
        public IHttpActionResult DeleteVehicleWizard(long id)
        {
            VehicleWizard vehicleWizard = db.VehicleWizards.Find(id);
            if (vehicleWizard == null)
            {
                return NotFound();
            }

            db.VehicleWizards.Remove(vehicleWizard);
            db.SaveChanges();

            return Ok(vehicleWizard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleWizardExists(long id)
        {
            return db.VehicleWizards.Count(e => e.VehicleID == id) > 0;
        }
    }
}