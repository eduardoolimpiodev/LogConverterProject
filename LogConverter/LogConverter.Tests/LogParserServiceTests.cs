using System.Collections.Generic;
using System.Linq;
using LogConverter.Models;
using LogConverter.Services;
using Xunit;

namespace LogConverter.Tests
{
    public class LogParserServiceTests
    {
        [Fact]
        public void ParseLogs_ValidContent_ReturnsCorrectEntries()
        {
            var parser = new LogParserService();
            string content = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\n";
            var expectedEntries = new List<LogEntry>
            {
                new LogEntry { Size = 312, StatusCode = 200, CacheStatus = "HIT", HttpMethod = "GET", UriPath = "/robots.txt", ResponseTime = 100.2 }
            };

            var result = parser.ParseLogs(content).ToList();

            Assert.Single(result);
            Assert.Equal(expectedEntries[0].Size, result[0].Size);
            Assert.Equal(expectedEntries[0].StatusCode, result[0].StatusCode);
            Assert.Equal(expectedEntries[0].CacheStatus, result[0].CacheStatus);
            Assert.Equal(expectedEntries[0].HttpMethod, result[0].HttpMethod);
            Assert.Equal(expectedEntries[0].UriPath, result[0].UriPath);
            Assert.Equal(expectedEntries[0].ResponseTime, result[0].ResponseTime);
        }
    }
}
