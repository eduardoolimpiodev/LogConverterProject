using System.Net.Http;
using System.Threading.Tasks;
using LogConverter.Interfaces;

namespace LogConverter.Services
{
    public class FileDownloader : IFileDownloader
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FileDownloader(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> DownloadFileAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
