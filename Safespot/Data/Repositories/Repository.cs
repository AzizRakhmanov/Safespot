using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            this._context.SaveChanges();

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
            EntityEntry<TEntity> entry = await this._dbset.AddAsync(entity);

            return entry.Entity;
        }

        public async ValueTask<bool> InsertAsync(IEnumerable<TEntity> entity)
        {
            await this._dbset.AddRangeAsync(entity);

            return true;
        }

        public async Task<IList<TEntity>> SelectAllAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            if (includes is not null)
            {
                IQueryable<TEntity> query = this._dbset;
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }

                var result = await query.Where(expression).ToListAsync();
                return result;
            }
            else
            {
               return await this._dbset.Where(expression).ToListAsync();
            }
        }

        /// <summary>
        /// selects the first or default from database and returns it
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            if (includes is not null)
            {
                IQueryable<TEntity> query = this._dbset;

                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
                var result = await query.AsNoTracking().FirstOrDefaultAsync(expression);

                return result;
            }
            else
            {
                var result = await this._dbset.AsNoTracking().FirstOrDefaultAsync(expression);
                return result;
            }
        }

        /// <summary>
        /// updates the entity from database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            EntityEntry<TEntity> entryentity = this._context.Update(entity);

            return entryentity.Entity;
        }

        public async Task SaveAsync()
        {
            await this._context.SaveChangesAsync();
        }


    }
}
