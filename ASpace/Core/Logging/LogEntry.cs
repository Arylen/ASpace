using System;

namespace ASpace.Core.Logging;

public struct LogEntry
{
    public DateTime Time { get; set; }
    public LogLevel Level { get; set; }
    public string Name { get; set; }
    public string Message { get; set; }
}