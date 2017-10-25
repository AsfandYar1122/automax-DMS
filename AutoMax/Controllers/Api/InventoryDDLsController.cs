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
using AutoMax.Models.DataModel;

namespace AutoMax.Controllers.Api
{
    public class InventoryDDLsController : ApiController
    {
        private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();

        // GET: api/InventoryDDLs
        [ResponseType(typeof(InventoryDDLs))]
        public IHttpActionResult GetVehclieTitles()
        {
            InventoryDDLs model = new InventoryDDLs();
            model.AutoEngines = db.AutoEngines.ToList() == null ? new List<AutoEngine>() : db.AutoEngines.ToList();
            model.AutoDoor = db.AutoDoors.ToList() == null ? new List<AutoDoor>() : db.AutoDoors.ToList();
            model.AutoTransmissions = db.AutoTransmissions.ToList() == null ? new List<AutoTransmission>() : db.AutoTransmissions.ToList();

            model.AutoModel = db.AutoModels.Select(d => new AutoMax.Models.DataModel.AutoModelVM
            {
                AutoModelID = d.AutoModelID,
                MakerID = d.MakerID,
                CreatedBy = d.CreatedBy,
                CreatedDate = d.CreatedDate,
                ModelName = d.ModelName,
                UpdatedBy = d.UpdatedBy,
                UpdatedDate = d.UpdatedDate,
                LanguageID = d.LanguageID
            }).ToList() == null ? new List<AutoMax.Models.DataModel.AutoModelVM>() : db.AutoModels.Select(d => new AutoMax.Models.DataModel.AutoModelVM
            {
                MakerID = d.MakerID,
                AutoModelID = d.AutoModelID,
                CreatedBy = d.CreatedBy,
                CreatedDate = d.CreatedDate,
                ModelName = d.ModelName,
                UpdatedBy = d.UpdatedBy,
                UpdatedDate = d.UpdatedDate,
                LanguageID = d.LanguageID
            }).ToList();
            model.SubModels = db.SubModels.Select(d => new AutoMax.Models.DataModel.SubModelVM
            {
                SubModelID = d.SubModelID,
                AutoModelID = d.AutoModelID,
                CreatedBy = d.CreatedBy,
                CreatedDate = d.CreatedDate,
                ModelName = d.ModelName,
                UpdatedBy = d.UpdatedBy,
                UpdatedDate = d.UpdatedDate,
                LanguageID = d.LanguageID
            }).ToList() == null ? new List<AutoMax.Models.DataModel.SubModelVM>() : db.SubModels.Select(d => new AutoMax.Models.DataModel.SubModelVM
            {
                SubModelID = d.SubModelID,
                AutoModelID = d.AutoModelID,
                CreatedBy = d.CreatedBy,
                CreatedDate = d.CreatedDate,
                ModelName = d.ModelName,
                UpdatedBy = d.UpdatedBy,
                UpdatedDate = d.UpdatedDate,
                LanguageID = d.LanguageID
            }).ToList();
            model.AutoConditions = db.AutoConditions.ToList() == null ? new List<AutoCondition>() : db.AutoConditions.ToList();
            model.AutoAirBags = db.AutoAirBags.ToList() == null ? new List<AutoAirBag>() : db.AutoAirBags.ToList();
            model.AutoBodyStyles = db.AutoBodyStyles.ToList() == null ? new List<AutoBodyStyle>() : db.AutoBodyStyles.ToList();
            model.AutoExteriorColors = db.AutoExteriorColors.ToList() == null ? new List<AutoExteriorColor>() : db.AutoExteriorColors.ToList();
            model.AutoInteriorColors = db.AutoInteriorColors.ToList() == null ? new List<AutoInteriorColor>() : db.AutoInteriorColors.ToList();
            model.AutoSteerings = db.AutoSteerings.ToList() == null ? new List<AutoSteering>() : db.AutoSteerings.ToList();
            model.DriveTypes = db.DriveTypes.ToList() == null ? new List<DriveType>() : db.DriveTypes.ToList();
            model.EngineCapacities = db.EngineCapacities.ToList() == null ? new List<EngineCapacity>() : db.EngineCapacities.ToList();
            model.FuelTypes = db.FuelTypes.ToList() == null ? new List<FuelType>() : db.FuelTypes.ToList();
            model.InventoryStatus = db.InventoryStatus.ToList() == null ? new List<InventoryStatus>() : db.InventoryStatus.ToList();
            model.Makers = db.Makers.Select(d =>
                new MakerVM
                {
                    MakerID = d.MakerID,
                    Name = d.Name,
                    CreatedBy = d.CreatedBy,
                    UpdatedBy = d.UpdatedBy,
                    CreatedDate = d.CreatedDate,
                    UpdatedDate = d.UpdatedDate,
                    LanguageID = d.LanguageID,
                    VehicleTypeID = d.VehicleTypeID
                }
                ).ToList() == null ? new List<MakerVM>() : db.Makers.Select(d =>
                new MakerVM
                {
                    MakerID = d.MakerID,
                    Name = d.Name,
                    CreatedBy = d.CreatedBy,
                    UpdatedBy = d.UpdatedBy,
                    CreatedDate = d.CreatedDate,
                    UpdatedDate = d.UpdatedDate,
                    LanguageID = d.LanguageID,
                    VehicleTypeID = d.VehicleTypeID
                }
                ).ToList();
            model.MediaPlayers = db.MediaPlayers.ToList() == null ? new List<MediaPlayer>() : db.MediaPlayers.ToList();
            model.RoofTypes = db.RoofTypes.ToList() == null ? new List<RoofType>() : db.RoofTypes.ToList();
            model.Upholsteries = db.Upholsteries.ToList() == null ? new List<Upholstery>() : db.Upholsteries.ToList();
            model.VehclieTitles = db.VehclieTitles.ToList() == null ? new List<VehclieTitle>() : db.VehclieTitles.ToList();
            model.VehicleTypes = db.VehicleTypes.ToList() == null ? new List<VehicleType>() : db.VehicleTypes.ToList();
            model.Years = db.Years.ToList() == null ? new List<Year>() : db.Years.ToList();
            model.AutoUsedStatus = db.AutoUsedStatus.ToList() == null ? new List<AutoUsedStatus>() : db.AutoUsedStatus.ToList();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }


        private bool VehclieTitleExists(int id)
        {
            return db.VehclieTitles.Count(e => e.VehicleTitleID == id) > 0;
        }
    }
}