using Microsoft.EntityFrameworkCore;
using StockNet.Data.DataContext;
using StockNet.Data.Interfaces.Dashboard;
using StockNet.Domain.Entities;

namespace StockNet.Data.Repository.Dashboard
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;
        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo para obtener todos los clientes de un negocio específico.
        /// </summary>
        /// <param name="negocioId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Cliente>> GetAllAsync(int negocioId)
        {
            return await _context.Clientes
                .Where(c => c.NegocioId == negocioId)
                .ToListAsync();
        }
    }
}
