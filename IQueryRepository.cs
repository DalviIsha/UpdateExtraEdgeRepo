using System.Linq.Expressions;

namespace WebApplication1.Domain.Interfaces.Repositories.Common
{
    public interface IQueryRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Find();

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken token = default);

        Task<bool> IsRecordExist(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);
    }
}