using System.Collections.Generic;

namespace LogConverter.Interfaces
{
    public interface ILogFormatter
    {
        string FormatLogs(IEnumerable<LogEntry> entries);
    }
}
