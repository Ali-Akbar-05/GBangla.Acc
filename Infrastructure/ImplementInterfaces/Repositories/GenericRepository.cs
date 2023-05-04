using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        // Instance of the DbContext. Must be passed or injected.        
        private DbContext Context { get; set; }
        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        //Internally re-usable DbSet instance.
        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = Context.Set<TEntity>();
                return _dbSet;
            }
        }
        private DbSet<TEntity> _dbSet;

        #region Regular Members
  
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = this.DbSet;
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<TEntity, object>(includeProperty);
            }
            return queryable;
        }
         
        public virtual IQueryable<TEntity> GetIQueryable()
        {
            return this.DbSet.AsQueryable<TEntity>();
        }
         
        #endregion

        #region Async Members
        public virtual async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this.DbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken)
        {
            return await this.DbSet.Where(match).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, CancellationToken cancellationToken)
        {
            return await this.DbSet.FirstOrDefaultAsync(match,cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await this.DbSet.CountAsync(cancellationToken);
        }

        public virtual async Task<object> InsertAsync(TEntity entity, bool saveChanges = false)
        {
            var rtn = await this.DbSet.AddAsync(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
            return rtn;
        }

        public virtual async Task DeleteAsync(object id, bool saveChanges = false)
        {
            var dataobject= this.DbSet.Find(id);
            this.DbSet.Remove(dataobject);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(TEntity entity, bool saveChanges = false)
        {
            this.DbSet.Attach(entity);
            this.DbSet.Remove(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            var entry = Context.Entry(entity);
            this.DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false)
        {
            if (entity == null)
                return null;
            var exist = await this.DbSet.FindAsync(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                if (saveChanges)
                {
                    await Context.SaveChangesAsync();
                }
            }
            return exist;
        }

        public virtual async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }
        #endregion

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
