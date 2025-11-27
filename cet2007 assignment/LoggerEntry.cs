using System;

internal public class LoggerEntry
{
    public DateTime Timestamp { get; set; }
    public string Source { get; set; }
    public string Message { get; set; }
    public LoggerEntry(string source, string message)
    {
        Source = source;
        Message = message;
        Timestamp = DateTime.Now;
    }
    public LoggerEntry()
    {
    }
}
