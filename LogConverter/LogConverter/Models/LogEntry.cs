namespace LogConverter.Models
{
    public class LogEntry
    {
        public int Size { get; set; }
        public int StatusCode { get; set; }
        public string CacheStatus { get; set; }
        public string HttpMethod { get; set; }
        public string UriPath { get; set; }
        public double ResponseTime { get; set; }

        public string FormatAgora()
        {
            return $"\"MINHA CDN\" {HttpMethod} {StatusCode} {UriPath} {(int)ResponseTime} {Size} {CacheStatus}";
        }
    }
}
