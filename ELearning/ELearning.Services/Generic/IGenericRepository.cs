using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services.Generic
{
    public interface IGenericAsyncRepository<TEntity>
    {
        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        void InsertAsync(TEntity entity);
        void InsertRangeAsync(IEnumerable<TEntity> entity);

        void UpdateAsync(TEntity entity);
        void UpdateRangeAsync(IEnumerable<TEntity> entity);

        void DeleteAsync(object id);
        void DeleteAsync(TEntity entity);
        void DeleteRangeAsync(IEnumerable<TEntity> entity);
    }
}
