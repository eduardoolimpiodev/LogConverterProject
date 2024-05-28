using LogConverter.Interfaces;
using LogConverter.Models;
using System.Collections.Generic;
using System.Linq;

namespace LogConverter.Services
{
    public class LogFormatterService : ILogFormatter
    {
        public string FormatLogs(IEnumerable<LogEntry> entries)
        {
            var header = "#Version: 1.0\n#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n";
            return header + string.Join("\n", entries.Select(e => e.FormatAgora()));
        }
    }
}
