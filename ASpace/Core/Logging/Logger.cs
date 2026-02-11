using System;
using System.Diagnostics;

namespace ASpace.Core.Logging;

public class Logger(string name)
{
    private static Stopwatch _stopwatch = Stopwatch.StartNew();
    public static LogLevel MinLogLevel { get; set; } = LogLevel.Debug;
    public static event Action<LogEntry>? OnLog;
    
    public static void Log(LogLevel level, string name, string message)
    {
        if ((int)MinLogLevel > (int)level)
            return;
        
        var entry = new LogEntry
        {
            Time = DateTime.Now,
            Level = level,
            Name = name,
            Message = message
        };

        Console.WriteLine($"{_stopwatch.Elapsed.TotalSeconds:F3} {level.ToString().ToUpper()} | [{name}] {message}");
        
        OnLog?.Invoke(entry);
    }
    
    public string Name { get; private set; } = name;
    
    public void Debug(string message) => Log(LogLevel.Debug, Name, message);
    public void Info(string message)  => Log(LogLevel.Info,  Name, message);
    public void Warn(string message)  => Log(LogLevel.Warn,  Name, message);
    public void Error(string message) => Log(LogLevel.Error, Name, message);
}