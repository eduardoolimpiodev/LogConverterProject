using LogConverter.Interfaces;
using LogConverter.Models;
using System.Collections.Generic;
using System.Linq;

namespace LogConverter.Services
{
    public class LogParserService : ILogParser
    {
        public IEnumerable<LogEntry> ParseLogs(string content)
        {
            var lines = content.Split('\n');
            foreach (var line in lines.Where(line => !string.IsNullOrEmpty(line)))
            {
                var parts = line.Split('|');
                yield return new LogEntry
                {
                    Size = int.Parse(parts[0]),
                    StatusCode = int.Parse(parts[1]),
                    CacheStatus = parts[2],
                    HttpMethod = parts[3].Split(' ')[0].Trim('"'),
                    UriPath = parts[3].Split(' ')[1],
                    ResponseTime = double.Parse(parts[4])
                };
            }
        }
    }
}
