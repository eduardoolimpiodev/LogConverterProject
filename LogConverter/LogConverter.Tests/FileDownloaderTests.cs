using LogConverter.Interfaces;
using LogConverter.Services;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LogConverter.Tests
{
    public class FileDownloaderTests
    {
        [Fact]
        public async Task DownloadFileAsync_ValidUrl_ReturnsContent()
        {
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("File content")
                });

            var httpClient = new HttpClient(handlerMock.Object);
            mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var downloader = new FileDownloader(mockHttpClientFactory.Object);

            var content = await downloader.DownloadFileAsync("http://example.com");

            Assert.Equal("File content", content);
        }
    }
}
