using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMax.PostingLibrary;
using AutoMax.PostingLibrary.WebsitePosting;
using AutoMax.Models;


namespace PostingTester
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string methodName = "Main";
            try
            {
                while (true)
                {
                    Console.WriteLine("Starting");
                    Console.Write("Posting Detail ID (-1 to exit): ");
                    string input = Console.ReadLine();
                    int postingDetailID = 0;
                    int.TryParse(input, out postingDetailID);
                    if (postingDetailID == -1)
                        break;
                    AutoMaxContext db = new AutoMax.Models.AutoMaxContext();
                    Library.SystemLogLevel = LogLevel.Debug;

                    var pd = db.PostingDetail
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
                            .Where(p => p.PostingDetailID == postingDetailID).FirstOrDefault();

                    WebsiteBot bot = WebsiteBotFactory.Instance.GetWebsiteBot(pd.PostingSite.PostingSiteName);
                    bot.SetContext(db);
                    bot.SetPostingDetails(pd);

                    if (bot.PostAd())
                    {
                        Library.WriteLog(methodName, "Posting successfull", LogLevel.Information);
                        pd.PostingStatus = db.PostingStatus.FirstOrDefault(p => p.StatusName == "Posted");
                        pd.UpdatedDate = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        Library.WriteLog(methodName, "Posting failed", LogLevel.Information);
                    }
                    Console.WriteLine("Done");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }
    }
}
