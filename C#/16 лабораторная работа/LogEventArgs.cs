using System;

public class LogEventArgs : EventArgs
{
    public string Message { get; }
    public DateTime Timestamp { get; }

    public LogEventArgs(string message)
    {
        Message = message;
        Timestamp = DateTime.Now;
    }
}
