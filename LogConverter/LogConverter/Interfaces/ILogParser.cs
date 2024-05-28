using System.Collections.Generic;

namespace LogConverter.Interfaces
{
    public interface ILogParser
    {
        IEnumerable<LogEntry> ParseLogs(string content);
    }
}
