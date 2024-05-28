using System.Collections.Generic;
using LogConverter.Models;

namespace LogConverter.Interfaces
{
    public interface ILogFormatter
    {
        string FormatLogs(IEnumerable<LogEntry> entries);
    }
}
