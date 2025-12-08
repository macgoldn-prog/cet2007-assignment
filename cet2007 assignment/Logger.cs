using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CET2007_Assignment
{
    public class Logger
    {
       
        private static readonly Logger instance = new Logger();

        // In-memory buffer for log entries
        private readonly List<ReportLog> logs = new List<ReportLog>();

        // Prevent external construction
        private Logger() { }

        // Return the singleton instance
        public static Logger GetInstance()
        {
            return instance;
        }

        public void Log(string source, string message)
        {
            var entry = $"[{source}] {message}";
            Console.WriteLine(entry);
            logs.Add(new ReportLog(entry));
        }

        public void SaveLogToFile()
        {
            try
            {
                if (logs.Count == 0) return;
                var lines = logs.Select(l => $"{l.Timestamp:O} {l.Message}");
                File.AppendAllLines("log.txt", lines);
                logs.Clear();
            }
            catch (Exception)
            {
                // try catch to prevent any failures in logging to crash the application
            }
        }
    }
}