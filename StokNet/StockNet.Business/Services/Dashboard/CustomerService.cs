using Microsoft.AspNetCore.Http;
using StockNet.Business.Interfaces;
using StockNet.Business.Interfaces.Dashboard;
using StockNet.Data.Interfaces.Dashboard;
using StockNet.Domain.Entities;

namespace StockNet.Business.Services.Dashboard
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerService(ICustomerRepository customerRepository, IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            _customerRepository = customerRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// metodo
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Cliente>> GetCustomerByBusiness()
        {
            var negocioId = ObtenerNegocioIdDesdeClaims();
            if (negocioId <= 0)
                throw new Exception("El negocio no es válido.");

            return await _customerRepository.GetAllAsync(negocioId);
        }

        /// <summary>
        /// Metodo que obtiene el negocio del usuario desde los claims
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int ObtenerNegocioIdDesdeClaims()
        {
            var claim = _httpContextAccessor.HttpContext?.User?.FindFirst("negocioId");
            if (claim == null)
                throw new Exception("No se pudo determinar el negocio del usuario.");

            return int.Parse(claim.Value);
        }



    }
}
