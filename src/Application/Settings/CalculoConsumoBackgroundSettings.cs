using CalculoConsumo.Domain.Interfaces.Settings;

namespace CalculoConsumo.Application.Settings
{
    public class CalculoConsumoBackgroundSettings: ICalculoConsumoBackgroundSettings
    {
        public int CheckUpdateTime { get; set; }
    }
}