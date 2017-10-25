//using Microsoft.SqlServer.Management.Sdk.Sfc;
//using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Models.Entities
{


    public class UtilityRepository
    {
        private AutoMaxContext db = new AutoMaxContext();

        //public string TakeBackup(string filePath)
        //{
        //    try
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath, false))
        //        {
        //            Server myServer = new Server(@"mssql3.gear.host");
        //            myServer.ConnectionContext.LoginSecure = false;
        //            myServer.ConnectionContext.Login = "automaxdb";
        //            myServer.ConnectionContext.Password = "Uy9JS1!xk-6o";
        //            myServer.ConnectionContext.Connect();

        //            Scripter scripter = new Scripter(myServer);
        //            Database myAdventureWorks = myServer.Databases["automaxdb"];
        //            Database myAdventureWorksDW = myServer.Databases["automaxdb"];
        //            Urn[] DatabaseURNs = new Urn[] { myAdventureWorks.Urn, myAdventureWorksDW.Urn };
        //            StringCollection scriptCollection = scripter.Script(DatabaseURNs);
        //            foreach (string script in scriptCollection)
        //                writer.WriteLine(script);

        //            ScriptingOptions scriptOptions = new ScriptingOptions();
        //            scriptOptions.ScriptDrops = true;
        //            scriptOptions.IncludeIfNotExists = true;

        //            foreach (Table myTable in myAdventureWorks.Tables)
        //            {
        //                /* Generating IF EXISTS and DROP command for tables */
        //                StringCollection tableScripts = myTable.Script(scriptOptions);
        //                foreach (string script in tableScripts)
        //                    writer.WriteLine(script);

        //                /* Generating CREATE TABLE command */
        //                tableScripts = myTable.Script();
        //                foreach (string script in tableScripts)
        //                    writer.WriteLine(script);

        //                IndexCollection indexCol = myTable.Indexes;
        //                foreach (Index myIndex in myTable.Indexes)
        //                {
        //                    /* Generating IF EXISTS and DROP command for table indexes */
        //                    StringCollection indexScripts = myIndex.Script(scriptOptions);
        //                    foreach (string script in indexScripts)
        //                        writer.WriteLine(script);

        //                    /* Generating CREATE INDEX command for table indexes */
        //                    indexScripts = myIndex.Script();
        //                    foreach (string script in indexScripts)
        //                        writer.WriteLine(script);
        //                }
        //            }
        //        }

        //        MailMessage mail = new MailMessage();
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //        var fromAddress = new MailAddress("dev.automax@gmail.com", "AutoMax");
        //        string fromPassword = "PasswordAutoMax";
        //        mail.From = fromAddress;
        //        mail.To.Add("wqshabib@gmail.com");
        //        mail.Subject = "Database Backup";
        //        mail.Body = "Find attached database backup file";

        //        System.Net.Mail.Attachment attachment;
        //        attachment = new System.Net.Mail.Attachment(filePath);
        //        mail.Attachments.Add(attachment);

        //        SmtpServer.Port = 587;
        //        SmtpServer.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
        //        SmtpServer.EnableSsl = true;

        //        SmtpServer.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //    return "Success";
        //}

        public string TakeBackup1()
        {
            try
            {
                string dbname = "automaxdb";
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["AMConnectionStr"].ConnectionString;

            //Enter destination directory where backup file stored
            string destdir = "C:\\backupdb";

            //Check that directory already there otherwise create 
            if (!System.IO.Directory.Exists(destdir))
            {
                System.IO.Directory.CreateDirectory("C:\\backupdb");
            }
            
                //Open connection
                sqlcon.Open();
                //query to take backup database
                destdir = destdir + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak";
                sqlcmd = new SqlCommand("backup database  " + dbname + " to disk='" + destdir + "'", sqlcon);
                sqlcmd.ExecuteNonQuery();
                //Close connection
                sqlcon.Close();

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                var fromAddress = new MailAddress("dev.automax@gmail.com", "AutoMax");
                string fromPassword = "PasswordAutoMax";
                mail.From = fromAddress;
                mail.To.Add("wqshabib@gmail.com");
                mail.Subject = "Test Mail - 1";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(destdir);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return "Done";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void AddInventoryStatusHistory(long userId, long vehicleId, int? fromStatus, int? toStatus)
        {
            try
            {
                if (fromStatus == null)
                    return;
                if (toStatus == null)
                    return;

                if (fromStatus == toStatus)
                    return;

                if (userId < 1)
                    userId = 1;

                var autoInventoryStatusHistory = new AutoInventoryStatusHistory();
                autoInventoryStatusHistory.CreatedBy = userId;
                autoInventoryStatusHistory.FromInventoryStatusID = fromStatus.Value;
                autoInventoryStatusHistory.CreatedDate = DateTime.Now;
                autoInventoryStatusHistory.ToInventoryStatusID = toStatus.Value;
                autoInventoryStatusHistory.VehicleId = vehicleId;

                db.AutoInventoryStatusHistory.Add(autoInventoryStatusHistory);
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }


        public List<string> GetImageURLFromFTP(string basePath)
        {
            Random random = new Random();
            var result = new List<string>();
            FtpWebRequest reqFTP;
            try
            {
                String ftpserver = "ftp://dealermade-numou:qRHVMefyQbNaPY2Q7k@ftp.dealermade.co/dealermade_export.csv";

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpserver));
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                //use the response like below
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string[] allLines = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                //var lst = allLines.Where(a => a != null && a.StartsWith(VIN)).ToList();
                var lst = allLines.Where(a => a != null).ToList();
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        var vehicleData = item.Split(',');
                        if (vehicleData.Count() > 5)
                        {
                            var vinFromFile = vehicleData[0];
                            var images = vehicleData[5];

                            if (vinFromFile != null && !string.IsNullOrEmpty(images))
                            {
                                var lstImages = images.Split('|');
                                if (lstImages != null && lstImages.Count() > 0 && !string.IsNullOrEmpty(lstImages[0]) && lstImages[0] != "\"\"")
                                {
                                    try
                                    {
                                        var sqlQuery = "SELECT * FROM VehicleWizards where VIN = '" + vinFromFile + "' AND InventoryStatusID != 4";
                                        var vehicleObj = db.Database.SqlQuery<VehicleWizard>(sqlQuery).FirstOrDefault();

                                        //var vehicleObj = db.VehicleWizards.FirstOrDefault(a => a.VIN == vinFromFile && a.InventoryStatusID != 4);
                                        if (vehicleObj != null)
                                        {
                                            bool hasDealerImages = false;

                                            foreach (var externalImageURL in lstImages)
                                            {
                                                sqlQuery = "SELECT * FROM VehicleImages where ExternalURL = '" + externalImageURL + "' AND VehicleID = " + vehicleObj.VehicleID;
                                                var imageObjFromDB = db.Database.SqlQuery<VehicleImage>(sqlQuery).FirstOrDefault();

                                                //var imageObjFromDB = db.VehicleImages.FirstOrDefault(a => a.ExternalURL == externalImageURL && a.VehicleID == vehicleObj.VehicleID);
                                                if (!string.IsNullOrEmpty(externalImageURL) && externalImageURL != @"""" && imageObjFromDB == null)
                                                {
                                                    // Download image first
                                                    var fileName = "DealerImage-" + random.Next(10, 1000000000) + "-" + random.Next(10, 1000000000) + "-" + random.Next(10, 1000000000) + "-";
                                                    var extention = ".png"; // retur
                                                    var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                                                    DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                                                    fileName = fileName + date;// + extention;
                                                                               //var path = Path.Combine(HttpContext.Current.Server.MapPath("~/VehicleAttachments/"));
                                                    bool isExists = Directory.Exists(basePath);

                                                    if (!isExists)
                                                        System.IO.Directory.CreateDirectory(basePath);

                                                    var path = basePath + fileName + extention;
                                                    using (WebClient wc = new WebClient())
                                                        wc.DownloadFile(externalImageURL, path);

                                                    // Save image in database
                                                    VehicleImage img = new VehicleImage();
                                                    img.ImagePath = fileName + extention;
                                                    img.ExternalURL = externalImageURL;
                                                    img.VehicleID = vehicleObj.VehicleID;
                                                    img.CreatedBy = 1;
                                                    img.DisplayOrder = 1;
                                                    img.UpdatedBy = 1;
                                                    img.CreatedDate = DateTime.Now;
                                                    img.UpdatedDate = DateTime.Now;
                                                    db.VehicleImages.Add(img);
                                                    db.SaveChanges();

                                                    hasDealerImages = true;
                                                }
                                                else
                                                {
                                                    if (imageObjFromDB != null)
                                                    {
                                                        hasDealerImages = true;
                                                    }
                                                }
                                            }

                                            if (hasDealerImages)
                                            {
                                                var obj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == vehicleObj.VehicleID);
                                                obj.HasDealerImages = hasDealerImages;
                                                db.SaveChanges();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            RemoveDuplicateImages();

            return result;
        }

        public class RemoveDuplicateImagesModel
        {
            public long VehicleID { get; set; }
            public int CountOfDuplicates { get; set; }
        }

        private void RemoveDuplicateImages()
        {
            try
            {
                var findDuplicates = @"select VehicleID, COUNT(ExternalURL) as CountOfDuplicates from VehicleImages 
GROUP BY ExternalURL, VehicleID
HAVING COUNT(ExternalURL) > 1";
                var duplicateImagesRecord = db.Database.SqlQuery<RemoveDuplicateImagesModel>(findDuplicates).FirstOrDefault();
                if (duplicateImagesRecord!=null)
                {
                    // Remove duplication
                    var queryToRemoveDuplicateImages = @"DELETE from VehicleImages
where VehicleImageID in (select min(VehicleImageID) from VehicleImages
GROUP BY ExternalURL, VehicleID
HAVING COUNT(ExternalURL) > 1);";

                    var result = db.Database.ExecuteSqlCommand(queryToRemoveDuplicateImages);

                    //Check again
                    RemoveDuplicateImages();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }

    public class CarInfo
    {
        public string DealerID { get; set; }

        public int VehcileId { get; set; }
        public string VIN { get; set; }
        public int BodyStyleId { get; set; }
        public int ConditionId { get; set; }
        public int DoorsId { get; set; }
        public int EngineId { get; set; }
        public int ExteriorColorId { get; set; }
        public int InteriorColorId { get; set; }
        public int ModelId { get; set; }
        public int SubModelID { get; set; }
        public int SteeringId { get; set; }
        public int TransmissionId { get; set; }
        public int DriveTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int InventoryStatusId { get; set; }
        public int MakerId { get; set; }
        public int YearId { get; set; }
        public int AutoAirBagId { get; set; }
        

        
        public int AudioId { get; set; }
        public int InteriorTypeId { get; set; }
        public int TopStyleId { get; set; }
        public string Odometer { get; set; }

        public string StockNumber { get; set; }
        public string FreeText { get; set; }
        public string ArabicFreeText { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }

        public bool Has360 { get; set; }
        public int VehicleTypeId { get; set; }
        public int AutoUsedStatusID { get; set; }

        public string PlateNumber { get; set; }
        public decimal Price { get; set; }
        public string MilageValue { get; set; }
        public int RoofTypeID { get; set; }
        public decimal PurchasingCost { get; set; }
        public long UserId { get; set; }
        public int UpholsteryID { get;  set; }
    }

    public class VehicleOptionsSaveModel
    {
        public long VehicleId { get; set; }
        public string MoreValue { get; set; }
        public string ArabicMoreValue { get; set; }

        public int AddressId { get; set; }

        public string CsvIDs { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class VIRRepository
    {
        public ResultSetViewModel RemoveVehicleImage(int imageId)
        {
            try
            {
                var image = db.VehicleImages.FirstOrDefault(d => d.VehicleImageID == imageId);
                if (image != null)
                {
                    db.VehicleImages.Remove(image);
                    db.SaveChanges();
                    return new ResultSetViewModel("Image removed successfully");
                }
                else
                {
                    throw new Exception("No image found for id = " + imageId);
                }
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel AddUpdateVehicleVideo(VehicleVideoViewModel model)
        {
            try
            {
                var videoObj = db.VehicleVideo.FirstOrDefault(a => a.VideoPath == model.VideoPath && a.VehicleID == model.VehicleID);
                if (videoObj != null)
                {
                    //videoObj.DisplayOrder = model.DisplayOrder;
                    //videoObj.IsFeatured = model.IsFeatured;
                    //videoObj.LanguageID = model.LanguageID;
                    //videoObj.UpdatedDate = DateTime.Now;
                    //videoObj.VehicleID = model.VehicleID;
                    //videoObj.VehicleVideoID = model.VehicleVideoID;
                    //videoObj.VideoPath = model.VideoPath;

                    //db.SaveChanges();

                    //return new ResultSetViewModel("Video updated successfully.");
                    throw new Exception("Video with this URL already exist. Please add new URL. Thanks");
                }

                videoObj = db.VehicleVideo.FirstOrDefault(a => a.VehicleVideoID == model.VehicleVideoID);
                if (videoObj != null)
                {
                    videoObj.DisplayOrder = model.DisplayOrder;
                    videoObj.IsFeatured = model.IsFeatured;
                    videoObj.LanguageID = model.LanguageID;
                    videoObj.UpdatedDate = DateTime.Now;
                    videoObj.VehicleID = model.VehicleID;
                    videoObj.VideoPath = model.VideoPath;

                    db.SaveChanges();

                    return new ResultSetViewModel("Video updated successfully.", videoObj.VehicleVideoID);
                }
                else
                {
                    var newVideoObj = new VehicleVideo();
                    newVideoObj.CreatedDate = DateTime.Now;
                    newVideoObj.DisplayOrder = model.DisplayOrder;
                    newVideoObj.IsFeatured = model.IsFeatured;
                    newVideoObj.LanguageID = model.LanguageID;
                    newVideoObj.UpdatedDate = DateTime.Now;
                    newVideoObj.VehicleID = model.VehicleID;
                    newVideoObj.VideoPath = model.VideoPath;

                    db.VehicleVideo.Add(newVideoObj);
                    db.SaveChanges();

                    return new ResultSetViewModel("Video added successfully.", newVideoObj.VehicleVideoID);
                }
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel RemoveVehicleVideo(int videoId)
        {
            try
            {
                var video = db.VehicleVideo.FirstOrDefault(d => d.VehicleVideoID == videoId);
                if (video != null)
                {
                    db.VehicleVideo.Remove(video);
                    db.SaveChanges();
                    return new ResultSetViewModel("Video removed successfully");
                }
                else
                {
                    throw new Exception("No video found for id = " + videoId);
                }
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel LoadVehicleVideos(long vehicleId)
        {
            try
            {
                var lst = (from data in db.VehicleVideo
                           where data.VehicleID == vehicleId
                           select new VehicleVideoViewModel()
                           {
                               CreatedDate = data.CreatedDate,
                               DisplayOrder = data.DisplayOrder,
                               IsFeatured = data.IsFeatured,
                               LanguageID = data.LanguageID,
                               UpdatedDate = data.UpdatedDate,
                               VehicleID = data.VehicleID,
                               VehicleVideoID = data.VehicleVideoID,
                               VideoPath = data.VideoPath
                           }).OrderBy(d => d.DisplayOrder).ToList();

                return new ResultSetViewModel(lst);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel RemoveVehiclePartImage(int imageId)
        {
            try
            {
                var image = db.VehiclePartImage.FirstOrDefault(d => d.VehiclePartImageID == imageId);
                if (image != null)
                {
                    db.VehiclePartImage.Remove(image);
                    db.SaveChanges();
                    return new ResultSetViewModel("Image removed successfully");
                }
                else
                {
                    throw new Exception("No image found for id = " + imageId);
                }
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultSetViewModel LoadVehicleAddress(long Id)
        {
            try
            {
                long selectedId = -1;
                VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == Id);
                if (vehicleWizard != null)
                {
                    selectedId = vehicleWizard.VehicleID;
                }

                var lst = (from data in db.VehicleAddress
                           select new VehicleAddressViewModel()
                           {
                               IsSelected = selectedId == data.Id,
                               GoogleAddress = data.GoogleAddress,
                               Id = data.Id,
                               Name = data.Name,
                               PhysicalAddress = data.PhysicalAddress
                           }).ToList();

                return new ResultSetViewModel(lst);

            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResultSetViewModel AddVehicleAddress(VehicleAddressViewModel model)
        {
            try
            {
                var address = db.VehicleAddress.FirstOrDefault(a => a.Name == model.Name);
                if (address != null)
                {
                    throw new Exception("Address name already exist. Please try again with new name. Thanks");
                }

                var vehicleAddress = new VehicleAddress();
                vehicleAddress.GoogleAddress = model.GoogleAddress;
                vehicleAddress.Name = model.Name;
                vehicleAddress.PhysicalAddress = model.PhysicalAddress;
                db.VehicleAddress.Add(vehicleAddress);
                db.SaveChanges();
                return LoadVehicleAddress(-1);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel LoadVIRPartConditionSeverityLevels(int partId)
        {
            try
            {
                if (partId == -1)
                {
                    var lst = db.VIRPartConditionSeverityLevels.ToList();
                    return new ResultSetViewModel(lst);
                }
                else
                {
                    var lst = db.VIRPartConditionSeverityLevels.Where(a => a.VIRPartID == partId).ToList();
                    return new ResultSetViewModel(lst);
                }
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel SaveInformation(CarInfo model)
        {
            try
            {
                VehicleWizard vehicleWizard = db.VehicleWizards.FirstOrDefault(d => d.VehicleID == model.VehcileId);
                if (vehicleWizard != null)
                {
                    if (string.IsNullOrEmpty(model.PlateNumber) && model.AutoUsedStatusID == 4) // 4 is the status of used
                    {
                        throw new Exception("Empty plate number can not be in USED status.");
                    }

                    if (!string.IsNullOrEmpty(model.PlateNumber) && model.PlateNumber.Trim().ToLower().Equals("vcc") && model.AutoUsedStatusID == 4) // 4 is the status of used
                    {
                        throw new Exception("Plate number with VCC can not be in USED status.");
                    }

                    if (!string.IsNullOrEmpty(model.PlateNumber) && !model.PlateNumber.Trim().ToLower().Equals("vcc") && model.AutoUsedStatusID == 3) // 4 is the status of used
                    {
                        throw new Exception("Vehicle with plate number can not be in NEW status.");
                    }

                    vehicleWizard.PlateNumber = model.PlateNumber;
                    if (model.BodyStyleId > 0)
                        vehicleWizard.AutoBodyStyleID = model.BodyStyleId;

                    if (model.ConditionId > 0)
                        vehicleWizard.AutoConditionID = model.ConditionId;
                    if (model.DoorsId > 0)
                        vehicleWizard.AutoDoorsID = model.DoorsId;
                    if (model.EngineId > 0)
                        vehicleWizard.AutoEngineID = model.EngineId;
                    if (model.ExteriorColorId > 0)
                        vehicleWizard.AutoExteriorColorID = model.ExteriorColorId;
                    if (model.InteriorColorId > 0)
                        vehicleWizard.AutoInteriorColorID = model.InteriorColorId;
                    if (model.ModelId > 0)
                        vehicleWizard.AutoModelID = model.ModelId;
                    if (model.SubModelID > 0)
                        vehicleWizard.SubModelID = model.SubModelID;
                    if (model.SteeringId > 0)
                        vehicleWizard.AutoSteeringID = model.SteeringId;
                    if (model.TransmissionId > 0)
                        vehicleWizard.AutoTransmissionID = model.TransmissionId;
                    if (model.DriveTypeId > 0)
                        vehicleWizard.DriveTypeID = model.DriveTypeId;
                    if (model.FuelTypeId > 0)
                        vehicleWizard.FuelTypeID = model.FuelTypeId;
                    if (model.InventoryStatusId > 0)
                    {
                        // add status change history
                        new UtilityRepository().AddInventoryStatusHistory(model.UserId, vehicleWizard.VehicleID, vehicleWizard.InventoryStatusID, model.InventoryStatusId);
                        vehicleWizard.InventoryStatusID = model.InventoryStatusId;
                    }

                    if (model.MakerId > 0)
                        vehicleWizard.MakerID = model.MakerId;
                    if (model.YearId > 0)
                        vehicleWizard.YearID = model.YearId;
                    if (model.AutoAirBagId > 0)
                        vehicleWizard.AutoAirBagID = model.AutoAirBagId;
                    if (model.AudioId > 0)
                        vehicleWizard.VehicleAudioID = model.AudioId;
                    if (model.InteriorTypeId > 0)
                        vehicleWizard.VehicleInteriorTypeID = model.InteriorTypeId;
                    if (model.TopStyleId > 0)
                        vehicleWizard.VehicleTopStyleID = model.TopStyleId;
                    if (model.RoofTypeID > 0)
                        vehicleWizard.RoofTypeID = model.RoofTypeID;

                    if (model.VehicleTypeId > 0)
                        vehicleWizard.VehicleTypeID = model.VehicleTypeId;
                    if (model.AutoUsedStatusID > 0)
                        vehicleWizard.AutoUsedStatusID = model.AutoUsedStatusID;
                    if (model.UpholsteryID > 0)
                        vehicleWizard.UpholsteryID = model.UpholsteryID;

                    if (!string.IsNullOrEmpty(model.MilageValue))
                    {
                        vehicleWizard.MilageValue = model.MilageValue;
                    }
                    if (model.PurchasingCost > 0)
                    {
                        vehicleWizard.PurchasingCost = model.PurchasingCost;
                    }

                    vehicleWizard.Odometer = model.Odometer;
                    vehicleWizard.VIN = model.VIN;
                    vehicleWizard.StockNumber = model.StockNumber;
                    vehicleWizard.FreeText = model.FreeText;
                    vehicleWizard.Has360 = model.Has360;
                    db.SaveChanges();
                }
                else
                {
                    return new ResultSetViewModel(new Exception("No vehicle found for id = " + model.VehcileId));
                }

                return new ResultSetViewModel("Updated successfully");
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private AutoMaxContext db = new AutoMaxContext();

        /// <summary>
        /// Load vehicle images for any specific vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="baseUrl">Base url should be Server.MapPath("~/VehicleAttachments/")</param>
        /// <returns></returns>
        public ResultSetViewModel LoadVehicleImages(long vehicleId, string baseUrl)
        {
            try
            {
                var lst = db.VehicleImages.Where(a => a.VehicleID == vehicleId && a.ImagePath != @"""").OrderBy(d => d.DisplayOrder).ToList();

                var localList = lst.Where(a => !a.ImagePath.StartsWith("http://")).ToList();
                var globalList = lst.Where(a => a.ImagePath.StartsWith("http://")).ToList();
                localList.ForEach(a => a.ImagePath = Path.Combine(baseUrl, a.ImagePath));

                var result = new List<VehicleImage>();
                result.AddRange(localList);
                result.AddRange(globalList);
                result = result.OrderBy(a => a.DisplayOrder).ToList();
                return new ResultSetViewModel(result);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel LoadVIRTabImages(long vehicleId, VIRPartType virPartType, string baseUrl)
        {
            try
            {
                var lstVIRPart = db.VIRPart.Where(a => a.VIRPartsType == virPartType).Select(a => a.Id).ToList();
                var lstVIR = db.VIR.Where(a => a.fkVehickeId == vehicleId && lstVIRPart.Contains(a.fkPartId)).Select(a => a.Id).ToList();
                var lst = db.VehiclePartImage.Where(a => a.VehicleID == vehicleId && lstVIR.Contains(a.VIRID)).ToList();
                lst.ForEach(a => a.ImagePath = Path.Combine(baseUrl, a.ImagePath));
                return new ResultSetViewModel(lst);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="vehiclePartId"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public ResultSetViewModel LoadVehiclePartImages(long vehicleId, long vehiclePartId, string baseUrl)
        {
            try
            {
                var objVIR = db.VIR.FirstOrDefault(a => a.fkVehickeId == vehicleId && a.fkPartId == vehiclePartId);
                if (objVIR == null)
                {
                    return new ResultSetViewModel(null);
                }

                var lst = db.VehiclePartImage.Where(a => a.VehicleID == vehicleId && a.VIRID == objVIR.Id).ToList();
                lst.ForEach(a => a.ImagePath = Path.Combine(baseUrl, a.ImagePath));
                return new ResultSetViewModel(lst);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        public ResultSetViewModel SaveVIROption(VehicleOptionsSaveModel model)
        {
            try
            {
                var obj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == model.VehicleId);
                obj.VehicleMoreOptions = model.MoreValue;
                obj.ArabicVehicleMoreOptions = model.ArabicMoreValue;
                obj.VehicleOptions = model.CsvIDs;

                if (model.AddressId > 0)
                {
                    obj.VehicleAddressId = model.AddressId;
                }

                db.SaveChanges();

                return new ResultSetViewModel("Saved successfully");
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResultSetViewModel SaveVIRFlags(VehicleOptionsSaveModel model)
        {
            try
            {
                var obj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == model.VehicleId);
                obj.VehiclemoreFlags = model.MoreValue;
                obj.ArabicVehicleMoreFlags = model.ArabicMoreValue;
                obj.VehicleFlags = model.CsvIDs;
                db.SaveChanges();

                return new ResultSetViewModel("Saved successfully");
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultSetViewModel LoadVIROptionProperties(long vehicleId)
        {
            try
            {
                var obj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == vehicleId);
                List<int> ids = new List<int>();
                if (!string.IsNullOrEmpty(obj.VehicleOptions))
                {
                    ids.AddRange(obj.VehicleOptions.Split(',').Select(a => Convert.ToInt32(a)).ToList());
                }

                var result = new VIROptionsPropertiesViewModelData
                {
                    MoreOptions = obj.VehicleMoreOptions,
                    List = (from data in db.VIROptionProperties
                            group data by data.GroupName into groupedData
                            select new VIROptionsPropertiesViewModelGroupData
                            {
                                Name = groupedData.Key,
                                List = (from innerdata in groupedData
                                        select new VIROptionPropertiesViewModel()
                                        {
                                            Name = innerdata.Name,
                                            Id = innerdata.Id,
                                            GroupName = innerdata.GroupName,
                                            ArabicGroupName = innerdata.ArabicGroupName,
                                            ArabicName = innerdata.ArabicName,
                                            Checked = ids.Contains(innerdata.Id)
                                        }).ToList()
                            }).ToList()
                };

                return new ResultSetViewModel(result);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public ResultSetViewModel LoadVIRFlagProperties(long vehicleId)
        {
            try
            {
                var obj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == vehicleId);
                List<int> ids = new List<int>();
                if (!string.IsNullOrEmpty(obj.VehicleFlags))
                {
                    ids.AddRange(obj.VehicleFlags.Split(',').Select(a => Convert.ToInt32(a)).ToList());
                }

                var result = new VIRFlagPropertiesViewModelData
                {
                    MoreFlags = obj.VehiclemoreFlags,
                    List = (from data in db.VIRFlagProperties
                            select new VIRFlagPropertiesViewModel()
                            {
                                Name = data.Name,
                                ArabicName = data.ArabicName,
                                Id = data.Id,
                                Checked = ids.Contains(data.Id)
                            }).ToList()
                };

                return new ResultSetViewModel(result);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static dynamic GetVIRDynamicObject(Dictionary<string, object> properties)
        {
            return new VIRDynamicObject(properties);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="virType"></param> 
        /// <returns></returns>
        public ResultSetViewModel GetVIR(long vehicleId, VIRPartType virPartType)
        {
            try
            {
                try
                {
                    string arabicConditions = @"update VIRs
set ArabicCondition = (select top 1 ArabicName from VIRPartConditionSeverityLevels where Name = VIRs.Condition)
where ArabicCondition is NULL";
                    db.Database.ExecuteSqlCommand(arabicConditions);
                }
                catch (Exception ex)
                {

                }
                var vehicleObj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == vehicleId);

                // Load all VIRParts for this specific virPartType
                var virParts = db.VIRPart.Where(a => a.VIRPartsType == virPartType).ToList();
                var virPartIDs = virParts.Select(a => a.Id).ToList();

                // Load list of VIR for these parts and vehicleId
                //var lstVIR = (from data in db.VIR
                //              where virPartIDs.Contains(data.fkPartId)
                //              && data.fkVehickeId == vehicleId
                //              select data).ToList();

                var sqlQuery = string.Format(@"SELECT 
  VIRs.*,
  VehiclePartImages.ImagePath
FROM 
  VIRs
  left JOIN (
    SELECT
      VIRs.Id,
      Max(VehiclePartImages.VIRID) AS VIRID
    FROM
      VIRs left JOIN VehiclePartImages
      ON VIRs.Id = VehiclePartImages.VIRID
    GROUP BY VIRs.Id
  ) AS Items ON VIRs.Id = Items.VIRID
  left JOIN VehiclePartImages 
  ON Items.VIRID = VehiclePartImages.VIRID
where VIRs.fkVehickeId = {0} and
VIRs.fkPartId in (SELECT VIRParts.Id from VIRParts where VIRParts.VIRPartsType = {1})", vehicleId, (int)virPartType);
                var lstVIR = db.Database.SqlQuery<VIRImageViewModel>(sqlQuery).ToList();
                //lstVIR.ForEach(a => a.ImagePath = Path.Combine("VehicleAttachments/VehicleParts/", a.ImagePath)); 
                // Generate anonymous object from this list
                var properties = new Dictionary<string, object>();

                foreach (var item in virParts)
                {

                    try
                    {
                        var vehicleVIR = lstVIR.FirstOrDefault(a => a.fkPartId == item.Id);
                        if (vehicleVIR != null && !string.IsNullOrEmpty(vehicleVIR.ImagePath))
                        {
                            vehicleVIR.ImagePath = Path.Combine("VehicleAttachments/VehicleParts/", vehicleVIR.ImagePath);
                        }
                        var name = item.Name.Replace(" ", "");
                        name = name.Replace(".", "");
                        properties.Add(name + "Id", item.Id);
                        properties.Add(name + "Data", vehicleVIR);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.Message;
                    }
                }

                if (vehicleObj != null)
                {
                    if (virPartType == VIRPartType.EXTERIOR)
                    {
                        properties.Add("Ratting", vehicleObj.ExteriorRatting);
                        properties.Add("EvaluatorRatting", vehicleObj.EvaluatorExteriorRatting);
                    }

                    if (virPartType == VIRPartType.INTERIOR)
                    {
                        properties.Add("Ratting", vehicleObj.InteriorRatting);
                        properties.Add("EvaluatorRatting", vehicleObj.EvaluatorInteriorRatting);
                    }

                    if (virPartType == VIRPartType.FRAME)
                    {
                        properties.Add("Ratting", vehicleObj.FrameRatting);
                        properties.Add("EvaluatorRatting", vehicleObj.EvaluatorFrameRatting);
                    }

                    if (virPartType == VIRPartType.MECHANICS)
                    {
                        properties.Add("Ratting", vehicleObj.MechanicsRatting);
                        properties.Add("EvaluatorRatting", vehicleObj.EvaluatorMechanicsRatting);
                    }

                    properties.Add("TotalRatting", vehicleObj.TotalRatting);
                    properties.Add("EvaluatorTotalRatting", vehicleObj.EvaluatorTotalRatting);
                }
                else
                {
                    properties.Add("Ratting", 0);
                    properties.Add("TotalRatting", 0);
                    properties.Add("EvaluatorExteriorRatting", 0);
                    properties.Add("EvaluatorInteriorRatting", 0);
                    properties.Add("EvaluatorFrameRatting", 0);
                    properties.Add("EvaluatorMechanicsRatting", 0);
                    properties.Add("EvaluatorTotalRatting", 0);
                }

                // Will return all VIR objects for a single vehicle of any specific vir type
                return new ResultSetViewModel(GetVIRDynamicObject(properties));
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="partId"></param>
        /// <returns></returns>
        public ResultSetViewModel GetVIRForPart(int vehicleId, int partId)
        {
            try
            {
                var obj = db.VIR.FirstOrDefault(a => a.fkVehickeId == vehicleId && a.fkPartId == partId);
                return new ResultSetViewModel(obj);
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        /// <summary>
        /// POST service call to update vir object or create new one if it does not exist
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ResultSetViewModel AddUpdateVIRPartInformation(VIR vir)
        {
            try
            {
                //var obj = db.VIR.FirstOrDefault(a => a.fkVehickeId == vir.fkVehickeId && a.fkPartId == vir.fkPartId && a.Id == vir.Id);
                var obj = db.VIR.FirstOrDefault(a => a.fkVehickeId == vir.fkVehickeId && a.fkPartId == vir.fkPartId);
                double ratting = 0;
                if (obj != null)
                {
                    if (vir.Severity < 0)
                    {
                        db.VIR.Remove(obj);
                        db.SaveChanges();
                    }
                    else
                    {
                        // Update it
                        obj.Condition = vir.Condition;
                        obj.CostOfRepair = vir.CostOfRepair;
                        obj.CostOfReplacement = vir.CostOfReplacement;
                        obj.EstimatedRepairCost = vir.EstimatedRepairCost;
                        obj.Part = vir.Part;
                        obj.Severity = vir.Severity;

                        var condition = db.VIRPartConditionSeverityLevels.FirstOrDefault(a => a.VIRPartID == vir.fkPartId && a.Name == vir.Condition);
                        if (condition != null)
                        {
                            obj.Ratting = GetVehiclePartRatting(condition.SeverityLevels, vir.Severity);
                        }
                        else
                        {
                            obj.Ratting = 0;
                        }

                        ratting = obj.Ratting;
                        obj.Description = vir.Description;

                        db.SaveChanges();
                    }

                    var vehicleObj = UpdateVehicleRatting(vir.fkVehickeId);

                    var rattingViewModel = new RattingViewModel()
                    {
                        PartRatting = ratting,
                        ExteriorRatting = vehicleObj.ExteriorRatting == null ? 0 : vehicleObj.ExteriorRatting.Value,
                        InteriorRatting = vehicleObj.InteriorRatting == null ? 0 : vehicleObj.InteriorRatting.Value,
                        FrameRatting = vehicleObj.FrameRatting == null ? 0 : vehicleObj.FrameRatting.Value,
                        MechanicsRatting = vehicleObj.MechanicsRatting == null ? 0 : vehicleObj.MechanicsRatting.Value,
                        TotalRatting = vehicleObj.TotalRatting == null ? 0 : vehicleObj.TotalRatting.Value,
                    };

                    return new ResultSetViewModel(rattingViewModel);
                }
                else
                {
                    if (vir.Severity > -1)
                    {
                        var newObj = new VIR();
                        newObj.Condition = vir.Condition;
                        newObj.CostOfRepair = vir.CostOfRepair;
                        newObj.CostOfReplacement = vir.CostOfReplacement;
                        newObj.EstimatedRepairCost = vir.EstimatedRepairCost;
                        newObj.Part = vir.Part;
                        newObj.Severity = vir.Severity;
                        newObj.Description = vir.Description;
                        newObj.fkPartId = vir.fkPartId;
                        newObj.fkUserId = vir.fkUserId;
                        newObj.fkVehickeId = vir.fkVehickeId;
                        var condition = db.VIRPartConditionSeverityLevels.FirstOrDefault(a => a.VIRPartID == vir.fkPartId && a.Name == vir.Condition);
                        if (condition != null)
                        {
                            newObj.Ratting = GetVehiclePartRatting(condition.SeverityLevels, vir.Severity);
                        }
                        else
                        {
                            newObj.Ratting = 0;
                        }

                        ratting = newObj.Ratting;
                        db.VIR.Add(newObj);
                        db.SaveChanges();
                    }

                    var vehicleObj = UpdateVehicleRatting(vir.fkVehickeId);

                    var rattingViewModel = new RattingViewModel()
                    {
                        PartRatting = ratting,
                        ExteriorRatting = vehicleObj.ExteriorRatting == null ? 0 : vehicleObj.ExteriorRatting.Value,
                        InteriorRatting = vehicleObj.InteriorRatting == null ? 0 : vehicleObj.InteriorRatting.Value,
                        FrameRatting = vehicleObj.FrameRatting == null ? 0 : vehicleObj.FrameRatting.Value,
                        MechanicsRatting = vehicleObj.MechanicsRatting == null ? 0 : vehicleObj.MechanicsRatting.Value,
                        TotalRatting = vehicleObj.TotalRatting == null ? 0 : vehicleObj.TotalRatting.Value,
                    };

                    return new ResultSetViewModel(rattingViewModel);
                }
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }

        private double GetVehiclePartRatting(double condition, double severity)
        {
            try
            {
                if (condition > 0)
                {
                    return Math.Ceiling((condition * severity) / 20.0);
                }
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private VehicleWizard UpdateVehicleRatting(long vehickeId)
        {
            try
            {
                var vehicleObj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == vehickeId);
                if (vehicleObj != null)
                {
                    var equality = new VIREquality();
                    // Load all VIRParts for this specific virPartType
                    var virParts = db.VIRPart.ToList();
                    var virPartIDs = virParts.Select(a => a.Id).ToList();

                    // Load list of VIR for these parts and vehicleId
                    var lstVIR = (from data in db.VIR
                                  where virPartIDs.Contains(data.fkPartId)
                                  && data.fkVehickeId == vehickeId
                                  select data).ToList();

                    double defaultExteriorRatting = 4;
                    if (vehicleObj.EvaluatorExteriorRatting != null)
                    {
                        defaultExteriorRatting = vehicleObj.EvaluatorExteriorRatting.Value;
                    }

                    var exteriorParts = virParts.Where(a => a.VIRPartsType == VIRPartType.EXTERIOR).ToList();
                    var exteriorPartsIDs = exteriorParts.Select(a => a.Id).ToList();
                    var lstExteriorPartsHavingVIRDone = lstVIR.Where(a => exteriorPartsIDs.Contains(a.fkPartId)).ToList();
                    var lstExteriorPartsIDsHavingVIRDone = lstExteriorPartsHavingVIRDone.Select(a => a.fkPartId).ToList().Distinct().ToList();
                    var lstExteriorPartsIDsHavingVIRNorDoneYet = exteriorPartsIDs.Where(a => !lstExteriorPartsIDsHavingVIRDone.Contains(a)).ToList().Distinct().ToList();
                    var selectedExteriorPartsRatting = Convert.ToDouble(lstExteriorPartsHavingVIRDone.Distinct(equality).Sum(a => a.Ratting));
                    var nonSelectedExteriorPartsRatting = lstExteriorPartsIDsHavingVIRNorDoneYet.Count * defaultExteriorRatting;
                    var totalVIRExteriorRatting = selectedExteriorPartsRatting + nonSelectedExteriorPartsRatting;
                    vehicleObj.ExteriorRatting = Math.Round(Convert.ToDouble(totalVIRExteriorRatting / (double)exteriorParts.Count), 2);
                    if (vehicleObj.ExteriorRatting == double.NaN)
                    {
                        vehicleObj.ExteriorRatting = 0;
                    }

                    double defaultMechanicsRatting = 4;
                    if (vehicleObj.EvaluatorMechanicsRatting != null)
                    {
                        defaultMechanicsRatting = vehicleObj.EvaluatorMechanicsRatting.Value;
                    }

                    var mechanicsParts = virParts.Where(a => a.VIRPartsType == VIRPartType.MECHANICS).ToList();
                    var mechanicsPartsIDs = mechanicsParts.Select(a => a.Id).ToList();
                    var lstmechanicsPartsHavingVIRDone = lstVIR.Where(a => mechanicsPartsIDs.Contains(a.fkPartId)).ToList();
                    var lstmechanicsPartsIDsHavingVIRDone = lstmechanicsPartsHavingVIRDone.Select(a => a.fkPartId).ToList().Distinct().ToList();
                    var lstmechanicsPartsIDsHavingVIRNorDoneYet = mechanicsPartsIDs.Where(a => !lstmechanicsPartsIDsHavingVIRDone.Contains(a)).ToList().Distinct().ToList();
                    var selectedmechanicsPartsRatting = Convert.ToDouble(lstmechanicsPartsHavingVIRDone.Distinct(equality).Sum(a => a.Ratting));
                    var nonSelectedmechanicsPartsRatting = lstmechanicsPartsIDsHavingVIRNorDoneYet.Count * defaultMechanicsRatting;
                    var totalVIRmechanicsRatting = selectedmechanicsPartsRatting + nonSelectedmechanicsPartsRatting;
                    vehicleObj.MechanicsRatting = Math.Round(Convert.ToDouble(totalVIRmechanicsRatting / (double)mechanicsParts.Count), 2);
                    if (vehicleObj.MechanicsRatting == double.NaN)
                    {
                        vehicleObj.MechanicsRatting = 0;
                    }

                    double defaultFrameRatting = 4;
                    if (vehicleObj.EvaluatorFrameRatting != null)
                    {
                        defaultFrameRatting = vehicleObj.EvaluatorFrameRatting.Value;
                    }

                    var frameParts = virParts.Where(a => a.VIRPartsType == VIRPartType.FRAME).ToList();
                    var framePartsIDs = frameParts.Select(a => a.Id).ToList();
                    var lstframePartsHavingVIRDone = lstVIR.Where(a => framePartsIDs.Contains(a.fkPartId)).ToList();
                    var lstframePartsIDsHavingVIRDone = lstframePartsHavingVIRDone.Select(a => a.fkPartId).ToList().Distinct().ToList();
                    var lstframePartsIDsHavingVIRNorDoneYet = framePartsIDs.Where(a => !lstframePartsIDsHavingVIRDone.Contains(a)).ToList().Distinct().ToList();
                    var selectedframePartsRatting = Convert.ToDouble(lstframePartsHavingVIRDone.Distinct(equality).Sum(a => a.Ratting));
                    var nonSelectedframePartsRatting = lstframePartsIDsHavingVIRNorDoneYet.Count * defaultFrameRatting;
                    var totalVIRframeRatting = selectedframePartsRatting + nonSelectedframePartsRatting;
                    vehicleObj.FrameRatting = Math.Round(Convert.ToDouble(totalVIRframeRatting / (double)frameParts.Count), 2);
                    if (vehicleObj.FrameRatting == double.NaN)
                    {
                        vehicleObj.FrameRatting = 0;
                    }

                    double defaultInteriorRatting = 4;
                    if (vehicleObj.EvaluatorInteriorRatting != null)
                    {
                        defaultInteriorRatting = vehicleObj.EvaluatorInteriorRatting.Value;
                    }

                    var interiorParts = virParts.Where(a => a.VIRPartsType == VIRPartType.INTERIOR).ToList();
                    var interiorPartsIDs = interiorParts.Select(a => a.Id).ToList();
                    var lstInteriorPartsHavingVIRDone = lstVIR.Where(a => interiorPartsIDs.Contains(a.fkPartId)).ToList();
                    var lstInteriorPartsIDsHavingVIRDone = lstInteriorPartsHavingVIRDone.Select(a => a.fkPartId).ToList().Distinct().ToList();
                    var lstInteriorPartsIDsHavingVIRNorDoneYet = interiorPartsIDs.Where(a => !lstInteriorPartsIDsHavingVIRDone.Contains(a)).ToList().Distinct().ToList();
                    var selectedInteriorPartsRatting = Convert.ToDouble(lstInteriorPartsHavingVIRDone.Distinct(equality).Sum(a => a.Ratting));
                    var nonSelectedInteriorPartsRatting = lstInteriorPartsIDsHavingVIRNorDoneYet.Count * defaultInteriorRatting;
                    var totalVIRInteriorRatting = selectedInteriorPartsRatting + nonSelectedInteriorPartsRatting;
                    vehicleObj.InteriorRatting = Math.Round(Convert.ToDouble(totalVIRInteriorRatting / (double)interiorParts.Count), 2);
                    if (vehicleObj.InteriorRatting == double.NaN)
                    {
                        vehicleObj.InteriorRatting = 0;
                    }


                    vehicleObj.VIRCompletenessPercentage = Math.Ceiling(Convert.ToDouble(lstVIR.Count) / Convert.ToDouble(virParts.Count) * 100.0);
                    vehicleObj.TotalRatting = Math.Round(Convert.ToDouble((vehicleObj.MechanicsRatting + vehicleObj.FrameRatting + vehicleObj.InteriorRatting + vehicleObj.ExteriorRatting) / 4.0), 2);

                    db.SaveChanges();
                }

                return vehicleObj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="virPartType"></param>
        /// <param name="ratting"></param>
        /// <returns></returns>
        public ResultSetViewModel UpdateEvaluatorRatting(long vehicleId, VIRPartType virPartType, double ratting)
        {
            try
            {
                var vehicleObj = db.VehicleWizards.FirstOrDefault(a => a.VehicleID == vehicleId);
                if (vehicleObj == null)
                {
                    throw new Exception("No vehicle found for id = " + vehicleId);
                }

                if (virPartType == VIRPartType.INTERIOR)
                {
                    vehicleObj.EvaluatorInteriorRatting = ratting;
                }
                else if (virPartType == VIRPartType.EXTERIOR)
                {
                    vehicleObj.EvaluatorExteriorRatting = ratting;
                }
                else if (virPartType == VIRPartType.FRAME)
                {
                    vehicleObj.EvaluatorFrameRatting = ratting;
                }
                else if (virPartType == VIRPartType.MECHANICS)
                {
                    vehicleObj.EvaluatorMechanicsRatting = ratting;
                }

                db.SaveChanges();
                UpdateVehicleRatting(vehicleId);
                return new ResultSetViewModel("Success");
            }
            catch (Exception ex)
            {
                return new ResultSetViewModel(ex);
            }
        }
    }

    public class VIREquality : IEqualityComparer<VIR>
    {
        public bool Equals(VIR x, VIR y)
        {
            if (x != null && y != null && x.fkPartId == y.fkPartId && x.fkVehickeId == y.fkVehickeId)
            {
                return true;
            }

            return false;
        }

        public int GetHashCode(VIR obj)
        {
            return base.GetHashCode();
        }
    }

    public class VIRReportViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        /// Array of VIR objects
        /// </summary>
        public Array VIRParts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VIRPartType VIRPartType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Ratting { get; set; }
    }

    /// <summary>
    /// Static data model 
    /// </summary>
    public class VIROptionProperties
    {
        [Key]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }

        public string ArabicGroupName { get; set; }
        public string ArabicName { get; set; }
    }

    public class VIRFlagProperties
    {
        public string ArabicName { get;  set; }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class VehicleVideo
    {
        [Key]
        public long VehicleVideoID { get; set; }
        public string VideoPath { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public VehicleWizard VehicleWizard { get; set; }
        public Nullable<int> LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
        public Nullable<int> IsFeatured { get; set; }
    }


    public class VIROptionPropertiesViewModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        public string ArabicGroupName { get; set; }
        public string ArabicName { get; set; }
    }

    public class VehicleVideoViewModel
    {
        public long VehicleVideoID { get; set; }
        public string VideoPath { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long VehicleID { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> IsFeatured { get; set; }
    }


    public class VIRFlagPropertiesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public bool Checked { get; set; }
    }

    public class VehicleAddress
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string PhysicalAddress { get; set; }
        public string ArabicPhysicalAddress { get; set; }
        public string GoogleAddress { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VehicleAddressViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhysicalAddress { get; set; }
        public string GoogleAddress { get; set; }
        public bool IsSelected { get; internal set; }
    }

    public class EvaluatorRatting
    {
        public long VehicleId { get; set; }
        public VIRPartType VIRPartType { get; set; }
        public double Ratting { get; set; }
    }

    /// <summary>
    /// Model class for VIR
    /// </summary>
    public class VIR
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fkVehickeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fkUserId { get; set; }

        /// <summary>
        /// VIRPart foreign key
        /// </summary>
        public int fkPartId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Condition { get; set; }
        public string ArabicCondition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Part { get; set; }
        public string ArabicPart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Severity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        public string ArabicDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CostOfRepair { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CostOfReplacement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EstimatedRepairCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Ratting { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum VIRPartType
    {
        EXTERIOR = 0,
        INTERIOR = 1,
        MECHANICS = 2,
        FRAME = 3
    }

    /// <summary>
    /// Database model class, will contains static list of all parts IDs and Name
    /// </summary>
    public class VIRPart
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public string ArabicName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VIRPartType VIRPartsType { get; set; }

        public ICollection<VIRPartConditionSeverityLevels> VIRPartConditionSeverityLevels { get; set; }

    }

    public class VIRPartConditionSeverityLevels
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public string ArabicName { get; set; }

        public double SeverityLevels { get; set; }

        public int VIRPartID { get; set; }


        [ForeignKey("VIRPartID")]
        public VIRPart VIRPart { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResultSetViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ResultSetViewModel()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ResultSetViewModel(Exception ex)
        {
            this.Message = ex.Message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ResultSetViewModel(Object data)
        {
            if (data != null)
            {
                this.Message = "Success";
                this.Result = true;
                this.Data = data;
            }
            else
            {
                this.Message = "No data found";
                this.Result = false;
                this.Data = data;
            }
        }

        public ResultSetViewModel(Object data, long Id)
        {
            if (data != null)
            {
                RecordID = Id;
                this.Message = "Success";
                this.Result = true;
                this.Data = data;
            }
            else
            {
                RecordID = -1;
                this.Message = "No data found";
                this.Result = false;
                this.Data = data;
            }
        }

        public long RecordID { get; set; }

        /// <summary>
        /// Result indicating true for positive and false for any error
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Status message about the operation performed
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Contains any data object
        /// </summary>
        public dynamic Data { get; set; }
    }

    public sealed class VIRDynamicObject : DynamicObject
    {
        private readonly Dictionary<string, object> _properties;

        public VIRDynamicObject(Dictionary<string, object> properties)
        {
            _properties = properties;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                result = _properties[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_properties.ContainsKey(binder.Name))
            {
                _properties[binder.Name] = value;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class VehicleInteriorType
    {
        [Key]
        public int InteriorTypeID { get; set; }
        public string Type { get; set; }
        public string ArabicType { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<VehicleWizard> Vehicle { get; set; }
    }

    public class VehicleAudio
    {
        [Key]
        public int AudioID { get; set; }
        public string Type { get; set; }
        public string ArabicType { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<VehicleWizard> Vehicle { get; set; }
    }

    public class VehicleTopStyle
    {
        [Key]
        public int TopStyleID { get; set; }
        public string Type { get; set; }
        public string ArabicType { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<VehicleWizard> Vehicle { get; set; }
    }

    public class VehicleWheel
    {
        [Key]
        public int WheelID { get; set; }
        public string Type { get; set; }
        public string ArabicType { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<VehicleWizard> Vehicle { get; set; }

    }
    public class VIRFlagPropertiesViewModelData
    {
        public List<VIRFlagPropertiesViewModel> List { get; set; }
        public string MoreFlags { get; set; }
    }
    public class VIROptionsPropertiesViewModelData
    {
        public List<VIROptionsPropertiesViewModelGroupData> List { get; set; }
        public string MoreOptions { get; set; }
    }
    public class VIROptionsPropertiesViewModelGroupData
    {
        public List<VIROptionPropertiesViewModel> List { get; set; }
        public string Name { get; set; }
    }

    public class RattingViewModel
    {
        public double ExteriorRatting { get; set; }
        public double InteriorRatting { get; set; }
        public double MechanicsRatting { get; set; }
        public double FrameRatting { get; set; }
        public double TotalRatting { get; set; }

        public double PartRatting { get; set; }
    }

    public class VIRImageViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fkVehickeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int fkUserId { get; set; }

        /// <summary>
        /// VIRPart foreign key
        /// </summary>
        public int fkPartId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Condition { get; set; }
        public string ArabicCondition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Part { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Severity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CostOfRepair { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CostOfReplacement { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EstimatedRepairCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Ratting { get; set; }

        public string ImagePath { get; set; }

    }

}
