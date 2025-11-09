
using System.Linq.Expressions;

namespace StockNet.Business.Interfaces
{
    public interface IBaseService<TEntity, TDto> where TEntity : class, new() where TDto : class
    {
        Task<TEntity> CreateAsync(TDto dto);
        Task DeleteAsync(int id);
        Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
