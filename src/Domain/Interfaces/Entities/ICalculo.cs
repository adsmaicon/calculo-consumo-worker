namespace CalculoConsumo.Domain.Interfaces.Entities
{
    public interface ICalculo : IBaseEntity
    {
        ICliente Cliente { get; set; }

        ICobranca Cobranca { get; set; }
    }
}
