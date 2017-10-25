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
using AutoMax.API.Models;

namespace AutoMax.API.Controllers
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
        public IHttpActionResult GetVehicleWizard(long id)
        {
            VehicleWizard vehicleWizard = db.VehicleWizards.Find(id);
            if (vehicleWizard == null)
            {
                return NotFound();
            }
            return Ok(vehicleWizard);
        }
        [HttpGet]
        [Route("DDLS")]
        public ResultSetViewModel VehicleDropDowns()
        {
            ResultSetViewModel model = new ResultSetViewModel{
                Result = true, 
                Message= "",
                Data = "XYZ"
            };
            return model;
        }
        
        //public IHttpActionResult GetVehicleDropdown(string type= "ddls")
        //{
        //    InventoryDDLs model = new InventoryDDLs();
        //    model.AutoAirBags = db.AutoAirBags.ToList();
        //    model.AutoEngines = db.AutoEngines.ToList();
        //    model.AutoDoor = db.AutoDoors.ToList();
        //    model.AutoTransmissions = db.AutoTransmissions.ToList();
        //    model.AutoModel = db.AutoModels.ToList();
        //    model.SubModels = db.SubModels.ToList();
        //    model.AutoConditions = db.AutoConditions.ToList();
        //    model.AutoAirBags = db.AutoAirBags.ToList();
        //    model.AutoBodyStyles = db.AutoBodyStyles.ToList();
        //    model.AutoExteriorColors = db.AutoExteriorColors.ToList();
        //    model.AutoInteriorColors = db.AutoInteriorColors.ToList();
        //    model.AutoSteerings = db.AutoSteerings.ToList();
        //    model.DriveTypes = db.DriveTypes.ToList();
        //    model.EngineCapacities = db.EngineCapacities.ToList();
        //    model.FuelTypes = db.FuelTypes.ToList();
        //    model.InventoryStatus = db.InventoryStatus.ToList();
        //    model.Makers = db.Makers.ToList();
        //    model.MediaPlayers = db.MediaPlayers.ToList();
        //    model.RoofTypes = db.RoofTypes.ToList();
        //    model.Upholsteries = db.Upholsteries.ToList();
        //    model.VehclieTitles = db.VehclieTitles.ToList();
        //    model.VehicleTypes = db.VehicleTypes.ToList();
        //    model.Years = db.Years.ToList();
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(model);
        //}
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