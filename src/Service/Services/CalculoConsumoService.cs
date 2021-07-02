using System;
using System.Threading.Tasks;
using CalculoConsumo.Domain.Entities;
using CalculoConsumo.Domain.Interfaces.ExternalServices;
using CalculoConsumo.Domain.Interfaces.Services;

namespace CalculoConsumo.Service.Services
{
    public class CalculoConsumoService : ICalculoConsumoService
    {
        private readonly IClientesExternalService _clientesExternal;
        private readonly ICobrancasExternalService _cobrancasExternal;

        public CalculoConsumoService(IClientesExternalService clientesExternal, ICobrancasExternalService cobrancasExternal)
        {
            _clientesExternal = clientesExternal;
            _cobrancasExternal = cobrancasExternal;
        }

        public async Task ProcessAsync()
        {
            var clientes = await _clientesExternal.GetItemsAsync();

            foreach (var cliente in clientes)
            {
                var cobranca = new Cobranca{
                    cpf = cliente.cpf,
                    vencimento = DateTime.Now,
                    valor = int.Parse(cliente.cpf.Substring(0, 2) + cliente.cpf.Substring(cliente.cpf.Length - 2))
                };

                await _cobrancasExternal.InsertAsync(cobranca);
            }
        }
    }
}