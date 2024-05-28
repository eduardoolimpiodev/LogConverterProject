using System.Threading.Tasks;

namespace LogConverter.Interfaces
{
    public interface IFileDownloader
    {
        Task<string> DownloadFileAsync(string url);
    }
}
