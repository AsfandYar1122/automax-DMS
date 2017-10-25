using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using System.Drawing;
using AutoMax.Models.Entities;
using System.Reflection;
using System.IO;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public abstract class WebsiteBot
    {
        protected PostingDetail postingDetails = null;
        protected AutoMax.Models.AutoMaxContext db = null;
        protected PostingSiteUser postingSiteUser = null;
        protected MakerMapping makerMapping = null;
        protected AutoModelMapping autoModelMapping = null;
        protected AutoTransmissionMapping autoTransmissionMapping = null;
        protected string error;
        //protected VehicleTitleMapping vehicleTitleMapping = null;
        public string Error
        {
            get 
            {
                return error;
            }
        }
        public PostingSiteUser PostingSiteUser
        {
            get
            {
                return postingSiteUser;
            }   
        }

        public WebsiteBot()
        {
        }
        public void SetContext(AutoMax.Models.AutoMaxContext db)
        {
            this.db = db;
        }
        public abstract bool DoPosting();
        public bool PostAd()
        {
            string methodName = "PostAd";
            Library.WriteLog(methodName, "Entered");

            bool postingSuccess = false;

            try
            {
                if (Initialize())
                {
                    if (LoadValues())
                    {
                        postingSuccess = DoPosting();
                    }
                    else
                    {
                        Library.WriteLog(methodName, string.Format("Unable to load values"), LogLevel.Error);
                    }
                }
                else
                {
                    Library.WriteLog(methodName, string.Format("Unable to initialize"), LogLevel.Error);
                }

            }
            catch (Exception ex)
            {
                Library.WriteLog(methodName, ex.ToString(), LogLevel.Error);
                error = ex.ToString();
            }
            return postingSuccess;
        }
        public void SetPostingDetails(PostingDetail postingDetails)
        {
            this.postingDetails = postingDetails;
        }
        protected bool Initialize()
        {
            string methodName = "Initialize";
            postingSiteUser = db.PostingSiteUser.Where(p => p.PostingSiteID == postingDetails.PostingSiteID).OrderBy(p => p.UpdatedDate).FirstOrDefault();
            if (postingSiteUser == null)
            {
                error = "Posting Site User not found";
                Library.WriteLog(methodName, error);
                return false;
            }
            else
                return true;
        }
        protected void clickLink(Browser browser, string linkName)
        {
            browser.Link(Find.ByText(linkName)).Click();
            //Library.WriteErrorLog(string.Format("Link [{0}] clicked", linkName));
        }
        protected bool LoadValues()
        {
            string methodName = "LoadValues";
            if (postingDetails == null)
            {
                error = "Posting details not loaded";
                Library.WriteLog(methodName, error);
                return false;
            }
            
            makerMapping = db.MakerMapping.FirstOrDefault(p => p.MakerId == postingDetails.VehicleWizard.MakerID);
            if (makerMapping == null)
            {
                error = "Maker Mapping not loaded for MakerID " + postingDetails.VehicleWizard.MakerID;
                Library.WriteLog(methodName, error);
                return false;
            }

            autoModelMapping = db.AutoModelMapping.FirstOrDefault(p => p.AutoModelID == postingDetails.VehicleWizard.AutoModelID);
            if (autoModelMapping == null)
            {
                error = "Auto Model Mapping not loaded for AutoModelID " + postingDetails.VehicleWizard.AutoModelID;
                Library.WriteLog(methodName, error);
                return false;
            }

            autoTransmissionMapping = db.AutoTransmissionMapping.FirstOrDefault(p => p.AutoTransmissionID == postingDetails.VehicleWizard.AutoTransmissionID);
            if (autoTransmissionMapping == null)
            {
                error = "Auto Transmission Mapping not loaded for AutoTransmissionID " + postingDetails.VehicleWizard.AutoTransmissionID;
                Library.WriteLog(methodName, error);
                return false;
            }
            return true;
        }
        protected void updateDescription(ref string description, string name, string value)
        {
            description += string.Format("{0}: {1}{2}", name, value, Environment.NewLine);
        }
        protected string GetDescription()
        {
            string methodName = "GetDescription";
            string description = "";

            description += postingDetails.PostingDescription + Environment.NewLine;
            description += Environment.NewLine;
            if (postingDetails.PublishPrice && postingDetails.VehicleWizard.VehiclePrice != null)
            {
                description += string.Format("{2}: SAR {0:n}{1}", postingDetails.VehicleWizard.VehiclePrice, Environment.NewLine, "السعر");
            }
            description += postingDetails.Negotiable ? string.Format("{1}{0}", Environment.NewLine, "السعر قابل للتفاوض") : "";


            return description;
        }        
    }
}
