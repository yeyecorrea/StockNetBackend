using StockNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockNet.Business.Interfaces.Dashboard
{
    public interface ICustomerService
    {
        Task<IEnumerable<Cliente>> GetCustomerByBusiness();
        int ObtenerNegocioIdDesdeClaims();
    }
}
