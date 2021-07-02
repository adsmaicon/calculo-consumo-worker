using System;
using CalculoConsumo.Domain.Interfaces.Entities;

namespace CalculoConsumo.Domain.Entities
{
    public class Cobranca: ICobranca
    {
        public string id { get; set; }
        
        public string cpf { get; set; }

        public DateTime vencimento { get; set; }

        public float valor { get; set; }
    }
}