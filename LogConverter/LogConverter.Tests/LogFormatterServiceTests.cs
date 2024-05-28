using System;
using System.Collections.Generic;
using LogConverter.Services;
using Xunit;

namespace LogConverter.Tests
{
    public class LogFormatterServiceTests
    {
        [Fact]
        public void FormatLogs_ValidEntries_ReturnsFormattedString()
        {
            var formatter = new LogFormatterService();
            var logEntries = new List<LogEntry>
            {
                new LogEntry { Size = 312, StatusCode = 200, CacheStatus = "HIT", HttpMethod = "GET", UriPath = "/robots.txt", ResponseTime = 100.2 },
                new LogEntry { Size = 101, StatusCode = 200, CacheStatus = "MISS", HttpMethod = "POST", UriPath = "/myImages", ResponseTime = 319.4 },
                new LogEntry { Size = 199, StatusCode = 404, CacheStatus = "MISS", HttpMethod = "GET", UriPath = "/not-found", ResponseTime = 142.9 },
                new LogEntry { Size = 312, StatusCode = 200, CacheStatus = "INVALIDATE", HttpMethod = "GET", UriPath = "/robots.txt", ResponseTime = 245.1 }
            };

            var expectedContent = $"#Version: 1.0\n#Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n" +
                                  "\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT\n" +
                                  "\"MINHA CDN\" POST 200 /myImages 319 101 MISS\n" +
                                  "\"MINHA CDN\" GET 404 /not-found 143 199 MISS\n" +
                                  "\"MINHA CDN\" GET 200 /robots.txt 245 312 REFRESH_HIT";

            var result = formatter.FormatLogs(logEntries);

            Assert.StartsWith("#Version: 1.0\n#Date:", result);
            Assert.Contains(expectedContent.Split('\n')[2], result);
            Assert.Contains("\"MINHA CDN\" GET 200 /robots.txt 100 312 HIT", result);
            Assert.Contains("\"MINHA CDN\" POST 200 /myImages 319 101 MISS", result);
            Assert.Contains("\"MINHA CDN\" GET 404 /not-found 143 199 MISS", result);
            Assert.Contains("\"MINHA CDN\" GET 200 /robots.txt 245 312 REFRESH_HIT", result);
        }
    }
}
