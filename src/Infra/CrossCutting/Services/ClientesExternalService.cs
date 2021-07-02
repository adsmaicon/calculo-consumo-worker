
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CalculoConsumo.Domain.Entities;
using CalculoConsumo.Domain.Interfaces.Entities;
using CalculoConsumo.Domain.Interfaces.ExternalServices;
using CalculoConsumo.Domain.Interfaces.Settings;

namespace CalculoConsumo.Infra.CrossCutting.Services
{
    public class ClientesExternalService : IClientesExternalService
    {
        private static HttpClient httpClient = new HttpClient();

        private readonly string _clientesApiUrl;

        public ClientesExternalService(IExternalServicesSettings externalServicesSettings)
        {
            _clientesApiUrl = externalServicesSettings.ClientesApiUrl;
        }
        public async Task<IList<Cliente>> GetItemsAsync()
        {
            var streamTask = httpClient.GetStreamAsync($"{_clientesApiUrl}/clientes");
            return await JsonSerializer.DeserializeAsync<List<Cliente>>(await streamTask);
        }

        public async Task<Cliente> InsertAsync(Cliente entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
