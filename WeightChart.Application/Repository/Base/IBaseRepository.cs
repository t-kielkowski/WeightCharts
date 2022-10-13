using System.Linq.Expressions;

namespace WeightChart.Infrastructure.Repository
{
    public interface IBaseRepository<TEntity>
      where TEntity : class
    {
        Task<TEntity> GetByIdAsync<T>(T id);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> CreateAsync(TEntity entity);

        Task UpdateAsync(int id, TEntity entity);

        Task DeleteAsync(int id);
    }
}
