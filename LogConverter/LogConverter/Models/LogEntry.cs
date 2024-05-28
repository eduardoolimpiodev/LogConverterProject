using System;

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
        string convertedCacheStatus = CacheStatus == "INVALIDATE" ? "REFRESH_HIT" : CacheStatus;
        return $"\"MINHA CDN\" {HttpMethod} {StatusCode} {UriPath} {Math.Round(ResponseTime)} {Size} {convertedCacheStatus}";
    }
}
