namespace CalculoConsumo.Domain.Interfaces.Settings
{
    public interface IExternalServicesSettings
    {
        string CobrancasApiUrl { get; set; }

        string ClientesApiUrl { get; set; }
    }
}