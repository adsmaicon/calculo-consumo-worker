using CalculoConsumo.Domain.Interfaces.Entities;

namespace CalculoConsumo.Domain.Entities
{
    public class Cliente: ICliente
    {
        public int id { get; set; }
        
        public string nome { get; set; }

        public string estado { get; set; }

        public string cpf { get; set; }
    }
}