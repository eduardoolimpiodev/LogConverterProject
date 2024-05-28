using LogConverter.Interfaces;
using LogConverter.Services;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LogConverter.Tests
{
    public class FileDownloaderTests
    {
        [Fact]
        public async Task DownloadFileAsync_ValidUrl_ReturnsContent()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Setup(handler => handler.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("File content")
                });

            var httpClient = new HttpClient(handlerMock.Object);
            mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var downloader = new FileDownloader(mockHttpClientFactory.Object);

            // Act
            var content = await downloader.DownloadFileAsync("http://valid.url");

            // Assert
            Assert.Equal("File content", content);
        }
    }
}
