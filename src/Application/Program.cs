using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using CalculoConsumo.Domain.Interfaces.ExternalServices;
using CalculoConsumo.Domain.Interfaces.Services;
using CalculoConsumo.Service.Services;
using CalculoConsumo.Infra.CrossCutting.Services;
using CalculoConsumo.Infra.CrossCutting.Settings;
using CalculoConsumo.Domain.Interfaces.Settings;
using CalculoConsumo.Domain.Interfaces.Entities;
using CalculoConsumo.Domain.Entities;
using CalculoConsumo.Application.Settings;

namespace CalculoConsumo.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;

                    services.Configure<ExternalServicesSettings>(
                        configuration.GetSection(nameof(ExternalServicesSettings)));
                    services.Configure<CalculoConsumoBackgroundSettings>(
                        configuration.GetSection(nameof(CalculoConsumoBackgroundSettings)));

                    services.AddSingleton<IExternalServicesSettings>(sp =>
                        sp.GetRequiredService<IOptions<ExternalServicesSettings>>().Value);
                    services.AddSingleton<ICalculoConsumoBackgroundSettings>(sp =>
                        sp.GetRequiredService<IOptions<CalculoConsumoBackgroundSettings>>().Value);

                    services.AddScoped<ICliente, Cliente>();
                    services.AddSingleton<IClientesExternalService, ClientesExternalService>();
                    services.AddSingleton<ICobrancasExternalService, CobrancasExternalService>();
                    services.AddSingleton<ICalculoConsumoService, CalculoConsumoService>();
                    
                    services.AddHostedService<Worker>();
                });
    }
}
