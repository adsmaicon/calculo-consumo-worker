using System.Threading.Tasks;
using CalculoConsumo.Domain.Interfaces.Entities;

namespace CalculoConsumo.Domain.Interfaces.Services
{
    public interface IBaseService<TEntitiy> where TEntitiy: IBaseEntity
    {
        Task ProcessAsync();        
    }
}