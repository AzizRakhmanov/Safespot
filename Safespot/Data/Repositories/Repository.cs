using Safespot.Data.IRepositories;
using Safespot.Models.Commons;
using System.Linq.Expressions;

namespace Safespot.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        public Repository()
        {

        }
        public ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteManyAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public TEntity UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
