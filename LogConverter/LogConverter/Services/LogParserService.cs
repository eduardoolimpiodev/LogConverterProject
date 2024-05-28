using System.Collections.Generic;
using LogConverter.Interfaces;
using System.Globalization;

namespace LogConverter.Services
{
    public class LogParserService : ILogParser
    {
        public IEnumerable<LogEntry> ParseLogs(string content)
        {
            var lines = content.Split('\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');
                var logEntry = new LogEntry
                {
                    Size = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    StatusCode = int.Parse(parts[1], CultureInfo.InvariantCulture),
                    CacheStatus = parts[2],
                    HttpMethod = parts[3].Split(' ')[0].Trim('"'),
                    UriPath = parts[3].Split(' ')[1],
                    ResponseTime = double.Parse(parts[4], CultureInfo.InvariantCulture)
                };
                yield return logEntry;
            }
        }
    }
}
