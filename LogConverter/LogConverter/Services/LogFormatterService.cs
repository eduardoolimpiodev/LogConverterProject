using System;
using System.Collections.Generic;
using System.Linq;
using LogConverter.Interfaces;


namespace LogConverter.Services
{
    public class LogFormatterService : ILogFormatter
    {
        public string FormatLogs(IEnumerable<LogEntry> entries)
        {
            var header = "#Version: 1.0\n#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n";
            var formattedEntries = entries.Select(e => $"\"MINHA CDN\" {e.HttpMethod} {e.StatusCode} {e.UriPath} {Math.Round(e.ResponseTime)} {e.Size} {ConvertCacheStatus(e.CacheStatus)}");
            return header + string.Join("\n", formattedEntries);
        }

        private string ConvertCacheStatus(string status)
        {
            return status switch
            {
                "INVALIDATE" => "REFRESH_HIT",
                _ => status
            };
        }
    }
}
