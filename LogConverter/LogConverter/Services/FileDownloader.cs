using LogConverter.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace LogConverter.Services
{
    public class FileDownloader : IFileDownloader
    {
        private readonly IHttpClientFactory _clientFactory;

        public FileDownloader(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> DownloadFileAsync(string url)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Failed to download content from {url}. Status code: {response.StatusCode}");
            }
        }
    }
}
