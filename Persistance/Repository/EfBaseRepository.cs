using Application.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EfBaseRepository<TEntity, TId, TContext> : IBaseRepository<TEntity, TId>, IAsyncRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfBaseRepository(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken=default)
        {
            entity.CreatedDate = DateTime.Now;
            await Context.AddAsync(entity,cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.Now;
            // Hard Delete - Soft Delete
            // Context.Remove(entity); // Hard Delete
            Context.Update(entity);
            Context.SaveChanges();
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.DeletedDate = DateTime.Now;
            Context.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }


        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().Where(entity => !entity.DeletedDate.HasValue).ToList();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<TEntity>().Where(entity => !entity.DeletedDate.HasValue).ToListAsync(cancellationToken);
        }

        public TEntity? GetById(TId id)
        {
            return Context.Set<TEntity>().FirstOrDefault(entity => entity.Id.Equals(id) && !entity.DeletedDate.HasValue);
        }

        public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id.Equals(id) && !entity.DeletedDate.HasValue, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            Context.Update(entity);
            Context.SaveChanges();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedDate = DateTime.Now;
            Context.Update(entity);
            await Context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}


