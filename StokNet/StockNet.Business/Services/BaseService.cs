using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StockNet.Business.Interfaces;
using StockNet.Data.Interfaces;

namespace StockNet.Business.Services
{
    public class BaseService<TEntity, TDto> : IBaseServices<TEntity, TDto> where TEntity : class, new() where TDto : class
    {
        private readonly IBaseRepository<int, TEntity> _repository;
        private readonly IMapper _mapper;
        public BaseService(IBaseRepository<int, TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta todas las entidades
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _repository.GetAll().ToListAsync();
        }

        /// <summary>
        /// Consulta una entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
           return await _repository.GetByIdAsync(id);

        }

        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<TEntity> CreateAsync(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);
            var newEntity = await _repository.CreateAsync(entity);
            return newEntity;
        }

        /// <summary>
        /// Actualiza la entidad (GUARDA)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result;
        }

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
           await _repository.DeleteAsync(id);
        }
    }
}
