using System;

namespace CET2007_Assignment
{
    public class Logger
    {
        internal static Logger GetInstance()
        {
            throw new NotImplementedException();
        }

        public void Log(string source, string message)
        {
            Console.WriteLine($"[{source}] {message}"); 
        }

        internal void SaveLogToFile()
        {
            // new
        }
    } 
}