using Safespot.Models.Commons;
using System.Linq.Expressions;

namespace Safespot.Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        public ValueTask<TEntity> InsertAsync(TEntity entity);
        public ValueTask<bool> InsertAsync(IEnumerable<TEntity> entity);

        public ValueTask<bool> DeleteAsync(TEntity entity);

        public ValueTask<bool> DeleteManyAsync(Expression<Func<TEntity, bool>> expression);

        public TEntity Update(TEntity entity);

        public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);

        public Task<IList<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);

        public Task SaveAsync();
    }
}
