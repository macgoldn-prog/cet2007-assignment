using System.Colectionds.Generic;
using System.IO;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CET2007_Assignment
    {
    internal class Logger
    {
        private static Logger instance;
        private static readonly object _lock = new object();
        private readonly List<LoggerEntry> _logEntry;
        private readonly string logFilePath = "userlog.log";
        private Logger()
        {
            _logEntry = new List<LoggerEntry>();
            LoadLogFromFile();
        }
        public static Logger GetInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
        public void Log(string source, string message)
        {
            var logEntry = new _logEntry(source, message);
            logEntry.Timestamp = DateTime.Now;
            _logEntry.Add(logEntry);
            SaveLogToFile();


        }
    }
}