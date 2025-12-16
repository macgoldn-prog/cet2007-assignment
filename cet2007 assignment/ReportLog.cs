using System;

namespace CET2007_Assignment
{
    public class ReportLog
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } // time of the log entry

        public ReportLog(string message, DateTime? timestamp = null)
        {
            Message = message;
            Timestamp = timestamp ?? DateTime.UtcNow; // default to current UTC time if no timestamp provided
        }
    }
}