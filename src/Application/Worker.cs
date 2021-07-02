using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CalculoConsumo.Domain.Interfaces.Settings;
using CalculoConsumo.Domain.Interfaces.Services;

namespace CalculoConsumo.Application
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICalculoConsumoBackgroundSettings _settings;
        private readonly ICalculoConsumoService _calculoConsumoService;

        public Worker(ICalculoConsumoBackgroundSettings settings, 
            ICalculoConsumoService calculoConsumoService, ILogger<Worker> logger)
        {            
            _settings = settings;
            _calculoConsumoService = calculoConsumoService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"CalculoConsumo is starting.");

            stoppingToken.Register(() =>
                _logger.LogDebug($" CalculoConsumo background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug($"CalculoConsumo task doing background work.");

                await _calculoConsumoService.ProcessAsync();

                await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
            }

            _logger.LogDebug($"CalculoConsumo background task is stopping.");
        }

    }
}
