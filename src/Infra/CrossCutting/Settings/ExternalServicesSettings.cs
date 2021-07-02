using CalculoConsumo.Domain.Interfaces.Settings;

namespace CalculoConsumo.Infra.CrossCutting.Settings
{
    public class ExternalServicesSettings : IExternalServicesSettings
    {
        public string CobrancasApiUrl { get; set; }

        public string ClientesApiUrl { get; set; }
    }
}