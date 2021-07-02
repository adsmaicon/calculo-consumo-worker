using System.Collections.Generic;
using System.Threading.Tasks;
using CalculoConsumo.Domain.Interfaces.Entities;

namespace CalculoConsumo.Domain.Interfaces.ExternalServices
{
    public interface IBaseExternalService<TEntity> where TEntity: IBaseEntity
    {
        Task<IList<TEntity>> GetItemsAsync();

        Task<TEntity> InsertAsync(TEntity entity);

    }
}