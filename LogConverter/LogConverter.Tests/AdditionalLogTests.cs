using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LogConverter.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace LogConverter.Tests
{
    public class AdditionalLogTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;

        public AdditionalLogTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        }

        [Theory]
        [InlineData("https://domaniinteriores.com/log1.txt")]
        [InlineData("https://domaniinteriores.com/log2.txt")]
        [InlineData("https://domaniinteriores.com/log3.txt")]
        public async Task DownloadFileAsync_VariousUrls_ReturnsContent(string url)
        {
            var expectedContent = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2\n";
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(expectedContent)
                });

            var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            var downloader = new FileDownloader(_httpClientFactoryMock.Object);

            var content = await downloader.DownloadFileAsync(url);

            Assert.Equal(expectedContent, content);
        }
    }
}
