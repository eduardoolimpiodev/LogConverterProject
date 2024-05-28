using System.Collections.Generic;
using LogConverter.Models;

namespace LogConverter.Interfaces
{
    public interface ILogParser
    {
        IEnumerable<LogEntry> ParseLogs(string content);
    }
}
