using System.Threading;
using System.Threading.Tasks;
using Challenge.WebApi.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Challenge.WebApi.Services
{
    public class BackgroundWorkerService : BackgroundService
    {
        private readonly IBackgroundQueue<string> _queue;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _configuration;

        public BackgroundWorkerService(IBackgroundQueue<string> queue, IServiceScopeFactory scopeFactory,
            IConfiguration configuration)
        {
            _queue = queue;
            _scopeFactory = scopeFactory;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(500, stoppingToken);

                var item = _queue.Dequeue();

                using var scope = _scopeFactory.CreateScope();
                var writerService = scope.ServiceProvider.GetRequiredService<IWriterService>();
                await writerService.WriteToFileAsync(item, _configuration.GetValue<string>("FileName"));
            }
        }
    }
}