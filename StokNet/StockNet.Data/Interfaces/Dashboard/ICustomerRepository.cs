using StockNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockNet.Data.Interfaces.Dashboard
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync(int negocioId);
    }
}
