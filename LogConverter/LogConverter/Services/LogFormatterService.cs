using System;
using System.Collections.Generic;
using System.Linq;
using LogConverter.Interfaces;
using LogConverter.Models;

namespace LogConverter.Services
{
    public class LogFormatterService : ILogFormatter
    {
        public string FormatLogs(IEnumerable<LogEntry> entries)
        {
            var header = $"#Version: 1.0\n#Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n";
            var logs = entries.Select(e =>
            {
                string cacheStatus = e.CacheStatus == "INVALIDATE" ? "REFRESH_HIT" : e.CacheStatus;
                return $"\"MINHA CDN\" {e.HttpMethod} {e.StatusCode} {e.UriPath} {Math.Truncate(e.ResponseTime)} {e.Size} {cacheStatus}";
            });

            return header + string.Join("\n", logs);
        }
    }
}
