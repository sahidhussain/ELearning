using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ELearning.Infrastructure.DbContext;
using ELearning.Services.Generic;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Infrastructure.Generic
{
    public class GenericRepository<TEntity> : IGenericAsyncRepository<TEntity> where TEntity : class
    {
        protected AppDbContext dbContext { get; set; }
        private DbSet<TEntity> dbSet;
        public GenericRepository(AppDbContext DBContext)
        {
            dbContext = DBContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(filter);
        }

        public async void InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async void InsertRangeAsync(IEnumerable<TEntity> entity)
        {
            await dbSet.AddRangeAsync(entity);
        }

        public async void UpdateAsync(TEntity entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;

            await Task.FromResult(true);
        }

        public async void UpdateRangeAsync(IEnumerable<TEntity> entity)
        {
            dbSet.AttachRange(entity);
            dbContext.Entry(entity).State = EntityState.Modified;

            await Task.FromResult(true);
        }

        public async void DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
           
            if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async void DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await Task.FromResult(true);
        }

        public async void DeleteRangeAsync(IEnumerable<TEntity> entity)
        {
            dbSet.RemoveRange(entity);
            await Task.FromResult(true);
        }
    }
}
