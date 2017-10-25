using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WatiN.Core;
using System.Threading;
using AutoMax.Models;
using AutoMax.Models.Entities;
using AutoMax.PostingLibrary;
using AutoMax.PostingLibrary.WebsitePosting;
using AutoMax.Models.Common;

namespace AutomaxPostingService
{
    public partial class Scheduler : ServiceBase
    {
        private System.Timers.Timer timer = null;
        private System.Timers.Timer ftpTimer = null;
        private System.Timers.Timer dbBackupTimer = null;
        bool isExecuting = false;
        //private AutoMax.Models.AutoMaxContext db = new AutoMax.Models.AutoMaxContext();
        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string methodName = "OnStart";
            timer = new System.Timers.Timer();
            int interval;
            if(int.TryParse(Library.GetPostingConfiguration("PostingIntervalInSeconds", "5"), out interval) == false)
            {
                interval = 5000;
            }
            else
            {
                interval = interval * 1000;
            }
            Library.SystemLogLevel = (LogLevel)int.Parse(Library.GetPostingConfiguration("LogLevel", "1"));
            
            timer.Interval = interval;
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;

            StartFtpTask();
            //StartDbBackup();

            Library.WriteLog(methodName, "Service started", LogLevel.Information);
        }

        //private void StartDbBackup()
        //{
        //    try
        //    {
        //        dbBackupTimer = new System.Timers.Timer();
        //        dbBackupTimer.Interval = 1000 * 60 * 60 * 24;
        //        dbBackupTimer.Elapsed += DbBackupTimer_Elapsed;
        //        dbBackupTimer.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Library.WriteLog("StartDbBackup", ex.Message, LogLevel.Error);
        //    }
        //}

        //private void DbBackupTimer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    try
        //    {
        //        DBBackupRepository.TakeBackup();
        //    }
        //    catch (Exception ex)
        //    {
        //        Library.WriteLog("StartFtpTask", ex.Message, LogLevel.Error);
        //    }
        //}

        private void StartFtpTask()
        {
            try
            {
                ftpTimer = new System.Timers.Timer();
                ftpTimer.Interval = 1000 * 60 * 60;
                ftpTimer.Elapsed += FtpTimer_Elapsed;
                ftpTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Library.WriteLog("StartFtpTask", ex.Message, LogLevel.Error);
            }
        }

        private void FtpTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                string exportFilePath = Library.GetPostingConfiguration("ExportFilePath", @"C:\Export\Export.csv");
                string ftpHost = Library.GetPostingConfiguration("ftpHost", @"ftp://ftp.dealermade.co");
                string ftpUser = Library.GetPostingConfiguration("ftpUser", "dealermade-numou");
                string ftpPassword = Library.GetPostingConfiguration("ftpPassword", "qRHVMefyQbNaPY2Q7k");

                var result = new FTPRepository().UploadData(exportFilePath, ftpHost, ftpUser, ftpPassword);
                if (result.Result)
                {
                    Library.WriteLog("FtpTimer_Elapsed", "FTP Process completed successfully.", LogLevel.Information);
                }
                else
                {
                    Library.WriteLog("FtpTimer_Elapsed", "FTP Process failed with error: " + result.Message, LogLevel.Information);
                }
            }
            catch (Exception ex)
            {
                Library.WriteLog("FtpTimer_Elapsed", ex.Message, LogLevel.Error);
            }
        }

        [STAThread]
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string methodName = "timer_Elapsed";
            try
            {
                if (isExecuting == false)
                {
                    isExecuting = true;
                    try
                    {
                        Library.WriteLog(methodName, "Entered");

                        Thread thread = new Thread(new ThreadStart(executePosting));
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                        thread.Join();
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        isExecuting = false;
                    }
                }
                else
                {
                    //Library.WriteErrorLog(methodName, "Thread already executing");
                }
                
            }
            catch (Exception ex)
            {

                Library.WriteLog(ex);
            }
        }
        void executePosting()
        {
            string methodName = "executePosting";
            Library.WriteLog(methodName, "Entered");
            try
            {
                AutoMaxContext db = new AutoMaxContext();

                Library.WriteLog(methodName, "Fetching posting with status 1 (Pending)");
                var postingDetails = db.PostingDetail
                    .Include("PostingSite")
                    .Include("VehicleWizard")
                    .Include("VehicleWizard.VehicleType")
                    .Include("VehicleWizard.Maker")
                    .Include("VehicleWizard.AutoModel")
                    .Include("VehicleWizard.SubModel")
                    .Include("VehicleWizard.Year")
                    .Include("VehicleWizard.VehclieTitle")
                    .Include("VehicleWizard.AutoCondition")
                    .Include("VehicleWizard.AutoBodyStyle")
                    .Include("VehicleWizard.AutoAirBag")
                    .Include("VehicleWizard.AutoInteriorColor")
                    .Include("VehicleWizard.AutoDoor")
                    .Include("VehicleWizard.AutoExteriorColor")
                    .Include("VehicleWizard.AutoEngine")
                    .Include("VehicleWizard.EngineCapacity")
                    .Include("VehicleWizard.DriveType")
                    .Include("VehicleWizard.FuelType")
                    .Include("VehicleWizard.AutoTransmission")
                    .Include("VehicleWizard.MediaPlayer")
                    .Include("VehicleWizard.RoofType")
                    .Include("VehicleWizard.Upholstery")
                    .Where(p => p.PostingStatus.StatusName != "Posted" && p.RetryCount < p.Retries).ToList();
                
                Library.WriteLog(methodName, string.Format("Fetch count {0}", postingDetails.Count), postingDetails.Count > 0 ? LogLevel.Information : LogLevel.Debug);
                
                foreach (PostingDetail pd in postingDetails)
                {
                    WebsiteBot bot = WebsiteBotFactory.Instance.GetWebsiteBot(pd.PostingSite.PostingSiteName);
                    bot.SetContext(db);
                    bot.SetPostingDetails(pd);

                    if (bot.PostAd())
                    {
                        Library.WriteLog(methodName, "Posting successfull", LogLevel.Information);
                        pd.PostingStatus = db.PostingStatus.FirstOrDefault(p => p.StatusName == "Posted");
                        pd.UpdatedDate = DateTime.Now;
                        pd.PostingSiteUser = bot.PostingSiteUser;
                        pd.RetryCount++;
                        pd.PostingError = "Success";
                        db.SaveChanges();
                    }
                    else 
                    {
                        Library.WriteLog(methodName, "Posting failed", LogLevel.Information);
                        pd.PostingStatus = db.PostingStatus.FirstOrDefault(p => p.StatusName == "Failed");
                        pd.UpdatedDate = DateTime.Now;
                        pd.RetryCount++;
                        pd.PostingError = bot.Error;
                        db.SaveChanges();
                    }

                }
                Library.WriteLog(methodName, "Loop completed");

            
            }
            catch(Exception ex)
            {
                Library.WriteLog(methodName, ex.ToString());
            }
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }
    }
}
