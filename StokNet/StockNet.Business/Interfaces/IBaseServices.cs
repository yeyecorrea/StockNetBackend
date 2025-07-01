
namespace StockNet.Business.Interfaces
{
    public interface IBaseServices<TEntity, TDto> where TEntity : class, new() where TDto : class
    {
        Task<TEntity> CreateAsync(TDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
