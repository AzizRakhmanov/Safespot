using Microsoft.EntityFrameworkCore;
using Safespot.Data.DataAccess;
using Safespot.Data.IRepositories;
using Safespot.Models.Commons;
using System.Linq.Expressions;

namespace Safespot.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly SafeSpotDbContext _context;
        private readonly DbSet<TEntity> _dbset;
        public Repository(SafeSpotDbContext context)
        {
            this._context = context;
            this._dbset = this._context.Set<TEntity>();
        }
        public async ValueTask<bool> DeleteAsync(TEntity entity)
        {
            this._dbset.Entry(entity).State = EntityState.Deleted;
            await this._context.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> DeleteManyAsync(Expression<Func<TEntity, bool>> expression)
        {
            var @object = await this.SelectAllAsync(expression);
            this._dbset.RemoveRange(@object);
            var result = await this._context.SaveChangesAsync();

            return result > 0;
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            this._dbset.Entry(entity).State = EntityState.Added;
            await this._context.SaveChangesAsync();

            return entity;
        }

        public async Task<IList<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = this._dbset.Where(expression);

            return await result.ToListAsync();
        }

        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = await this._dbset.FindAsync(expression);

            return result;
        }
        public TEntity Update(TEntity entity)
        {
            this._dbset.Entry(entity).State = EntityState.Modified;
            var result = this._context.SaveChanges();

            return entity;
        }
    }
}
