using Challenge.WebApi.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.WebApi.Services
{
    public class BackgroundWorkerService : BackgroundService
    {
        private readonly IBackgroundQueue<string> _queue;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly string _filePath;
        private readonly string _delimiter;

        public BackgroundWorkerService(IBackgroundQueue<string> queue, IServiceScopeFactory scopeFactory,
            IConfiguration configuration, IWebHostEnvironment environment)
        {
            _queue = queue;
            _scopeFactory = scopeFactory;
            _filePath = Path.Combine(environment.WebRootPath, configuration.GetValue<string>("FileName"));
            _delimiter = configuration.GetValue<string>("Delimiter");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(500, stoppingToken);

                var item = _queue.Dequeue();
                if (string.IsNullOrWhiteSpace(item)) continue;

                using var scope = _scopeFactory.CreateScope();
                var writerService = scope.ServiceProvider.GetRequiredService<IWriterService>();
                await writerService.WriteToFileAsync(item, _delimiter, _filePath);
            }
        }
    }
}