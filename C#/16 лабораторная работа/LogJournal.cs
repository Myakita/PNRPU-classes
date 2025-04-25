using System;
using System.Collections.Generic;

public delegate void LogAddedEventHandler(object sender, LogEventArgs e);

public class LogJournal
{
    private readonly List<string> logs = new List<string>();
    public event LogAddedEventHandler LogAdded;

    public void Add(string message)
    {
        var log = $"[{DateTime.Now:HH:mm:ss}] {message}";
        logs.Add(log);
        LogAdded?.Invoke(this, new LogEventArgs(message));
    }

    public IEnumerable<string> GetAll() => logs.AsReadOnly();
    public void Clear() => logs.Clear();
}
