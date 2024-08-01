using Safespot.Models.Commons;
using System.Linq.Expressions;

namespace Safespot.Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        public ValueTask<TEntity> InsertAsync(TEntity entity);

        public ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);

        public ValueTask<bool> DeleteManyAsync(Expression<Func<TEntity,bool>> expression);

        public TEntity UpdateAsync(TEntity entity);

        public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression);

        public Task<IList<TEntity>> SelectAllAsync(Expression<Func<TEntity,bool>> expression);
    }
}
