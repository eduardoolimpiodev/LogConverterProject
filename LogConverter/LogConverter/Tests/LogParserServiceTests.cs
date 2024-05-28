using LogConverter.Models;
using LogConverter.Services;
using System.Collections.Generic;
using Xunit;

namespace LogConverter.Tests
{
    public class LogParserServiceTests
    {
        [Fact]
        public void ParseLogs_ValidContent_ReturnsCorrectEntries()
        {
            // Arrange
            var parser = new LogParserService();
            string content = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\n";
            var expectedEntries = new List<LogEntry>
            {
                new LogEntry { Size = 312, StatusCode = 200, CacheStatus = "HIT", HttpMethod = "GET", UriPath = "/robots.txt", ResponseTime = 100.2 }
            };

            // Act
            var result = parser.ParseLogs(content);

            // Assert
            Assert.Equal(expectedEntries, result);
        }
    }
}
