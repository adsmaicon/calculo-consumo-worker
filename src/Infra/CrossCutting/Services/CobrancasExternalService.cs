
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CalculoConsumo.Domain.Entities;
using CalculoConsumo.Domain.Interfaces.ExternalServices;
using CalculoConsumo.Domain.Interfaces.Settings;

namespace CalculoConsumo.Infra.CrossCutting.Services
{
    public class CobrancasExternalService : ICobrancasExternalService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly string _apiUrl;

        public CobrancasExternalService(IExternalServicesSettings externalServicesSettings)
        {
            _apiUrl = externalServicesSettings.CobrancasApiUrl;
        }

        public async Task<IList<Cobranca>> GetItemsAsync()
        {
            var stream = _httpClient.GetStreamAsync($"{_apiUrl}/cobrancas");
            return await JsonSerializer.DeserializeAsync<List<Cobranca>>(await stream);
        }

        public async Task<Cobranca> InsertAsync(Cobranca entity)
        {
            var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync($"{_apiUrl}/cobrancas", content);
            var stream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<Cobranca>(stream);
            
        }
    }
}
