using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovBooks.Core.Jobs.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovBooks.Core.Jobs
{
    public class QueuedHostedService : BackgroundService
    {
        private readonly ILogger<QueuedHostedService> _logger;
        public IBackgroundTaskQueue TaskQueue { get; }

        private IServiceProvider _serviceProvider;

        public QueuedHostedService(ILogger<QueuedHostedService> logger, IBackgroundTaskQueue taskQueue, IServiceProvider serviceProvider)
        {
            _logger = logger;
            TaskQueue = taskQueue;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queued Hosted Service is running.");

            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem =
                    await TaskQueue.DequeueAsync(stoppingToken);

                try
                {
                    _logger.LogInformation("executing {WorkItem}.", nameof(workItem));

                    await workItem(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "Error occurred executing {WorkItem}.", nameof(workItem));
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queued Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
