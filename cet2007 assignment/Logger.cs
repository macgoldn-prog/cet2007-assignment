using System;

namespace CET2007_Assignment
{
    public class Logger
    {
        public void Log(string source, string message)
        {
            Console.WriteLine($"[{source}] {message}"); 
        }
    } 
}