using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockNet.Data.DataContext;
using StockNet.Data.Interfaces;
using System.Linq.Expressions;

namespace StockNet.Data.Repository
{
    public class BaseRespository<TId, TEntity> : IBaseRepository<TId, TEntity> where TEntity : class, new()
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<BaseRespository<TId, TEntity>> _logger;
        public BaseRespository(ApplicationContext context, ILogger<BaseRespository<TId, TEntity>> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Consulta todas las entidades
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        /// <summary>
        /// Consulta una entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(TId id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Erro al obtener entidad de tipo {EntityType} con id {Id}", typeof(TEntity).Name, id);
                throw;
            }

        }

        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula");

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro al guardar entidad de tipo {EntityType}", typeof(TEntity).Name);
                throw;
            }
        }

        // <summary>
        /// Actualiza la entidad (GUARDA)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro al guardar entidad de tipo {EntityType}", typeof(TEntity).Name);
                throw;
            }
        }

        /// <summary>
        /// Elimina una entidad (Guarda)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(TId id)
        {
            try
            {
                var entity = await _context.FindAsync<TEntity>(id);
                _context.Remove<TEntity>(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro al eliminar entidad de tipo {EntityType} con id {Id}", typeof(TEntity).Name, id);
                throw;
            }
        }

        /// <summary>
        /// Metodo que busca la primera entidad que cumpla con el predicado especificado.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro al buscar la primera entidad de tipo {EntityType} con el predicado {Predicate}", typeof(TEntity).Name, predicate);
                throw;
            }
        }
    }
}
