using System;

namespace CalculoConsumo.Domain.Interfaces.Entities
{
    public interface ICobranca : IBaseEntity
    {
        string id { get; set; }

        string cpf { get; set; }

        DateTime vencimento { get; set; }

        float valor { get; set; }
    }
}
