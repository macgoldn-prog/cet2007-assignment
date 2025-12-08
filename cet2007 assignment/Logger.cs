using System;
using System.IO;

namespace CET2007_Assignment
{
    public class Logger
    {
        private static readonly Logger instance = new Logger();
        private static readonly string logFilePath = "log.txt";

        // Prevent external construction
        private Logger() { }

        public static Logger GetInstance()
        {
            return instance;
        }

        private void WriteEntry(string entry)
        {
            try
            {
                Console.WriteLine(entry);
                File.AppendAllText(logFilePath, entry + Environment.NewLine);
            }
            catch (Exception)
            {
                // exceptions so logging cannot crash the app
            }
        }

        // timestamp + message
        public void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            WriteEntry($"[{timestamp}] {message}");
        }

        public void Log(string source, string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            WriteEntry($"[{timestamp}] [{source}] {message}");
        }
        public void SaveLogToFile()
        {
            // nothing - to be removed in future versions
        }
    }
}