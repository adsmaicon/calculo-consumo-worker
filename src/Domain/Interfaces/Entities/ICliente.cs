namespace CalculoConsumo.Domain.Interfaces.Entities
{
    public interface ICliente : IBaseEntity
    {
        int id { get; set; }

        string nome { get; set; }

        string estado { get; set; }

        string cpf { get; set; }

    }
}
