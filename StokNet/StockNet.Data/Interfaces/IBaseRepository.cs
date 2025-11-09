using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockNet.Data.Interfaces
{
    public interface IBaseRepository<TId, TEntity> where TEntity : class, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(TId id);
        Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(TId id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
