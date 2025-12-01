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

        }
        public void SaveLogToFile() // change Log saving and loading to .txt NOT JSON - games and players are json only. 
        {
            try
            {
                var json = JsonSerializer.Serialize(_logEntry);
                File.WriteAllText(logFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving log to file: {ex.Message}");
            }
        }
        private void LoadLogFromFile()
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                    var json = File.ReadAllText(logFilePath);
                    var logEntries = JsonSerializer.Deserialize<List<LoggerEntry>>(json);
                    if (logEntries != null)
                    {
                        _logEntry.AddRange(logEntries);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading log from file: {ex.Message}");
            }
        }

    }
}
