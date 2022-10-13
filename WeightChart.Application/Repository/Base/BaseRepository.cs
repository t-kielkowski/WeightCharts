using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WeightChart.Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
     where TEntity : class, new()
    {
        protected readonly SensorReadingsContext DbContext;

        protected BaseRepository(SensorReadingsContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task<TEntity> GetByIdAsync<T>(T id)
        {
            return await DbContext.Set<TEntity>()
            .FindAsync(id)
            .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            return await (orderBy != null ? orderBy(query) : query)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(int id, TEntity entity)
        {
            var entityToUpdate = await GetByIdAsync(id);
            UpdateEntity(entityToUpdate, entity);
            DbContext.Set<TEntity>().Update(entityToUpdate);
            await DbContext.SaveChangesAsync();
        }

        protected virtual TEntity UpdateEntity(TEntity dbEntity, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync()
            .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }

}
