using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMax.Models;
using AutoMax.Models.Entities;
using System.Reflection;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public abstract class PostingDetailsGenerator
    {
        protected string title; 
        protected string description;

        protected AutoMaxContext db;
        protected int vehicleId;
        protected string postingWebsite;

        private string error;
        public string Error
        {
            get 
            { 
                return error; 
            }
        }
        public string Title
        {
            get 
            { 
                return title; 
            }
        }
        public string Description
        { 
            get 
            { 
                return description; 
            } 
        }
        public void Initialize(AutoMaxContext db, int vehicleId, string postingWebsite)
        {
            this.db = db;
            this.vehicleId = vehicleId;
            this.postingWebsite = postingWebsite;
        }
        public PostingDetailsGenerator()
        {}
        protected abstract string GetTitle(VehicleWizard vehicle);
        protected abstract string GetDescription(VehicleWizard vehicle);
        protected abstract string GetPostingFieldFieldName(PostingField p);
        protected abstract string GetPostingFieldLinkedFieldName(PostingField p);
        protected abstract string GetPostingFieldDisplayName(PostingField p);
        public virtual bool Generate()
        {
            var vehicle = db.VehicleWizards
                .Include("VehicleType")
                .Include("Maker")
                .Include("AutoModel")
                .Include("SubModel")
                .Include("Year")
                .Include("VehclieTitle")
                .Include("AutoCondition")
                .Include("AutoBodyStyle")
                .Include("AutoAirBag")
                .Include("AutoInteriorColor")
                .Include("AutoDoor")
                .Include("AutoExteriorColor")
                .Include("AutoEngine")
                .Include("EngineCapacity")
                .Include("DriveType")
                .Include("FuelType")
                .Include("AutoTransmission")
                .Include("MediaPlayer")
                .Include("RoofType")
                .Include("Upholstery")
                .Where(p => p.VehicleID == vehicleId).FirstOrDefault();


            this.title = "";
            this.description = "";

            this.title = GetTitle(vehicle);

            description += GetDescription(vehicle) + Environment.NewLine;
            description += Environment.NewLine;
            //if (postingDetails.PublishPrice && postingDetails.VehicleWizard.VehiclePrice != null)
            //{
            //    description += string.Format("Price: SAR {0:n}{1}", postingDetails.VehicleWizard.VehiclePrice, Environment.NewLine);
            //}
            //description += postingDetails.Negotiable ? string.Format("Price Negotiable{0}", Environment.NewLine) : "";

            var postingFields = db.PostingField.Where(p => p.PostingSite.PostingSiteName == postingWebsite && p.IncludeInPosting == true).OrderBy(p => p.IncludeOrder);

            foreach (PostingField p in postingFields)
            { 
                switch (p.FieldName)
                {
                    case "VIN":
                    case "StockNumber":
                    case "PlateNumber":
                    case "Odometer":
                        PropertyInfo propertyInfo = typeof(VehicleWizard).GetProperty(GetPostingFieldFieldName(p));
                        if (propertyInfo != null)
                        {
                            string value = propertyInfo.GetValue(vehicle).ToString();
                            if (!string.IsNullOrEmpty(value))
                            {
                                updateDescription(GetPostingFieldDisplayName(p), value);
                            }
                        }
                        break;
                    case "VehicleType":
                    case "Maker":
                    case "AutoModel":
                    case "SubModel":
                    case "Year":
                    case "VehclieTitle":
                    case "AutoCondition":
                    case "AutoBodyStyle":
                    case "AutoAirBag":
                    case "AutoInteriorColor":
                    case "AutoDoor":
                    case "AutoExteriorColor":
                    case "AutoEngine":
                    case "EngineCapacity":
                    case "DriveType":
                    case "FuelType":
                    case "AutoTransmission":
                    case "MediaPlayer":
                    case "RoofType":
                    case "Upholstery":
                        PropertyInfo vehiclepropertyInfo = typeof(VehicleWizard).GetProperty(GetPostingFieldFieldName(p));
                        if (vehiclepropertyInfo != null)
                        {
                            PropertyInfo linkedPropertyInfo = vehiclepropertyInfo.PropertyType.GetProperty(GetPostingFieldLinkedFieldName(p));
                            if (vehiclepropertyInfo.GetValue(vehicle) != null)
                            {
                                if (linkedPropertyInfo.GetValue(vehiclepropertyInfo.GetValue(vehicle)) != null)
                                {
                                    updateDescription(GetPostingFieldDisplayName(p), linkedPropertyInfo.GetValue(vehiclepropertyInfo.GetValue(vehicle)).ToString());
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return true;
        }
        protected abstract void updateDescription(string name, string value);
    }
}
