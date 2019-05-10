using Demo.Api.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Api.Services
{
    public class TestService : BackgroundService
    {
        private readonly ILogger<TestService> _logger;
        private readonly BackgroundSettings _backgroundSettings;
       
        public TestService(ILogger<TestService> logger, IOptions<BackgroundSettings> backgroundSettings)
        {
            _logger = logger;
            _backgroundSettings = backgroundSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("TestService is starting");

            stoppingToken.Register(() => 
                _logger.LogDebug("TestService background task is stopping")
            );

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("TestService background task doing background work.");

                //Do Something

                await Task.Delay(TimeSpan.FromSeconds(_backgroundSettings.PollingIntervalSeconds), stoppingToken);
            }

            _logger.LogDebug("TestService background task is stopping.");
        }
    }
}
