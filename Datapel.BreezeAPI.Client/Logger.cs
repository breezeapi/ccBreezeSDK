using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration; 

namespace Datapel.BreezeAPI.SDK.Utils
{
    public static class Logger
    {
        /// <summary>
        /// Log file name. Required to have a '{0}', so that the log files is a daily log file. 
        /// </summary>
        private const string LOG_FILENAME = "LogFileName";
        /// <summary>
        /// AppSetting Key for Log Folder. Required to specified the full path for log folder. 
        /// </summary>
        private const string LOG_FOLDER = "LogFolder";
               
        private static string ProgramFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); 

        private static string LogFolder
        {
            get
            {
                try
                {
                    var temp = ConfigurationManager.AppSettings[LOG_FOLDER].ToString();
                    return temp; 
                }
                catch
                {
                    return ProgramFolder + "\\Log";
                }
            }
        }

        private static string LogFiles
        {
            get
            {
                try
                {
                    var temp = string.Format(ConfigurationManager.AppSettings[LOG_FILENAME], DateTime.Now.ToString("yyyyMMdd"));
                    return temp;
                }
                catch
                {
                    return string.Format("Log-{0}.txt", DateTime.Now.ToString("yyyyMMdd")); 
                }
            }
        }

        public static  void writeToFile(string content, string fullPathFileName, bool appendToFile = false)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(fullPathFileName);
            file.Directory.Create();
            using (var stream = file.Exists ? new StreamWriter(fullPathFileName, appendToFile) : file.CreateText())
            {
                stream.WriteLine(content);
            }
        }

        public static string ReadFromFile(string fullPathFileName)
        {
            using (var stream = new StreamReader(fullPathFileName))
            {
                return stream.ReadToEnd();
            }
        }

        public static void writeToLog(string logContent)
        {
            var logPath = LogFolder + "\\" + LogFiles;
            var pid = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
            logContent = string.Format("[{0}]-[{1}]-[{2}", pid, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logContent + "\n");
            writeToFile(logContent, logPath, true);
        }

        public static void LogInfo(string logContent)
        {
            logContent = "*** Info ***\t" + logContent;
            writeToLog(logContent);
        }

        public static void LogError(string logContent)
        {
            logContent = "*** Error ***\t" + logContent;
            writeToLog(logContent);
        }
    }




}
