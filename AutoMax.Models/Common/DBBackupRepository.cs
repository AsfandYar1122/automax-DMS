using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AutoMax.Models.Common
{
    public static class DBBackupRepository
    {
        public static string TakeBackup()
        {
            Init();
            return ExecBackup();
        }

        private static string defaultDownloadsPath;
        private static string apiKey;
        private static string downloadsPath; 
        private static string dbName;

        private static long ToUnixTimestamp(this DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return (long)Math.Floor(diff.TotalSeconds);
        }

        private static void Init()
        {
            defaultDownloadsPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Downloads");
            if (!Directory.Exists(defaultDownloadsPath))
                Directory.CreateDirectory(defaultDownloadsPath);

            downloadsPath = defaultDownloadsPath;
            dbName = "automaxdb";
            apiKey = "6b76eddc224241dabae1772b02145d35";
        }

        public static string ExecBackup()
        { 
            string localPath = "";
            using (var webClient = new GearHostWebClient())
            {
                webClient.Headers.Add("Authorization", string.Format("bearer {0}", apiKey));
                DatabasesDTO dto = null;
                try
                {
                    var databasesJson = webClient.DownloadString("https://api.gearhost.com/v1/databases");
                    dto = new JavaScriptSerializer().Deserialize<DatabasesDTO>(databasesJson);
                }
                catch (Exception)
                {
                    throw new Exception("Error downloading API data. Check your API key");
                }

                var database = dto.databases.FirstOrDefault(d => string.Compare(d.name, dbName, StringComparison.OrdinalIgnoreCase) == 0);
                if (database == null)
                {
                    throw new Exception("Database not found. Check your database name.");
                }

                string localFileName = dbName + "_" + DateTime.Now.ToUnixTimestamp() + ".zip";
                localPath = Path.Combine(downloadsPath, localFileName);

                webClient.DownloadFile(string.Format("https://api.gearhost.com/v1/databases/{0}/backup", database.id), localPath);
                EmailAttachemnt(localPath);
            }

            return localPath;
        }

        private static void EmailAttachemnt(string localPath)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                var fromAddress = new MailAddress("dev.automax@gmail.com", "AutoMax");
                string fromPassword = "PasswordAutoMax";
                mail.From = fromAddress;
                mail.To.Add("wqshabib@gmail.com");
                mail.CC.Add("ghulammurtazaqazi@gmail.com");
                mail.Subject = "Database Backup";
                mail.Body = "Find attached database backup file";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(localPath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                //throw new Exception("Email sending failed. " + ex.Message, ex);
            }
        }
    }


    public class GearHostWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = Timeout.Infinite;
            return w;
        }
    }

    public class DatabaseDTO
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string plan { get; set; }
        public string type { get; set; }
        public long size { get; set; }
        public bool locked { get; set; }
        public DateTime dateCreated { get; set; }
    }

    public class DatabasesDTO
    {
        public DatabaseDTO[] databases { get; set; }
    }
}
