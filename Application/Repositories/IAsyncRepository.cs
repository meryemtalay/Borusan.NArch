using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAsyncRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
        // GetAllAsync GetAsync vs..

    { 
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken=default);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    } 


}
