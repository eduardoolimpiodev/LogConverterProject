using System;
using System.IO;
using System.Threading.Tasks;
using LogConverter.Interfaces;
using LogConverter.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogConverter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            await RunAsync(host.Services);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddHttpClient()
                            .AddTransient<IFileDownloader, FileDownloader>()
                            .AddTransient<ILogParser, LogParserService>()
                            .AddTransient<ILogFormatter, LogFormatterService>());

        static async Task RunAsync(IServiceProvider services)
        {
            var downloader = services.GetRequiredService<IFileDownloader>();
            var parser = services.GetRequiredService<ILogParser>();
            var formatter = services.GetRequiredService<ILogFormatter>();

            string url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            string outputPath = @"C:\testeTTTN\outputTest.txt";

            try
            {
                var logContent = await downloader.DownloadFileAsync(url);
                var logEntries = parser.ParseLogs(logContent);
                var formattedContent = formatter.FormatLogs(logEntries);
                File.WriteAllText(outputPath, formattedContent);
                Console.WriteLine("Log file downloaded and processed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
