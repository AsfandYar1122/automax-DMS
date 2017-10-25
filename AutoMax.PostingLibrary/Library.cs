using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoMax.Models;
using AutoMax.Models.Entities;

namespace AutoMax.PostingLibrary
{
    public enum LogLevel
    {
        Error = 0,
        Information = 1,
        Debug = 2
    }
    public static class Library
    {
        public static LogLevel SystemLogLevel { get; set; }
        public static void WriteLog(Exception ex)
        {
            WriteLog(ex.Source.ToString().Trim(), ex.Message.ToString().Trim(), LogLevel.Error);
        }
        public static void WriteLog(string source, string message, LogLevel logLevel = LogLevel.Debug)
        {
            if (logLevel <= SystemLogLevel)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(string.Format("{0}\\Logs\\LogFile{1}.txt", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd")), true);
                    sw.WriteLine(DateTime.Now.ToString() + ":" + logLevel.ToString().Substring(0,5) + ": " + source + ": " + message);
                    sw.Flush();
                    sw.Close();
                }
                catch
                { }
            }
        }
        public static string GetPostingConfiguration(string name, string defaultvalue = null)
        {
            AutoMaxContext db = new AutoMaxContext();
            var postingConfiguration = db.PostingConfiguration.FirstOrDefault(p => p.Name == name);
            if (postingConfiguration == null)
                return defaultvalue;
            else
                return postingConfiguration.Value;

        }
    }
}
