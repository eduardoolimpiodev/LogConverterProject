using LogConverter.Models;
using LogConverter.Services;
using System.Collections.Generic;
using Xunit;

namespace LogConverter.Tests
{
    public class LogFormatterServiceTests
    {
        [Fact]
        public void FormatLogs_ValidEntries_ReturnsFormattedContent()
        {
            // Arrange
            var formatter = new LogFormatterService();
            var logEntries = new List<LogEntry>
            {
                new LogEntry { Size = 312, StatusCode = 200, CacheStatus = "HIT", HttpMethod = "GET", UriPath = "/robots.txt", ResponseTime = 100.2 }
            };
            string expectedContent = "#Version: 1.0\n#Date: 15/12/2017 23:01:06\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT";

            // Act
            var result = formatter.FormatLogs(logEntries);

            // Assert
            Assert.Equal(expectedContent, result);
        }
    }
}
