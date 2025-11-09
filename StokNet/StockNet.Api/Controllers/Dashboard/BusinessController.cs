using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockNet.Application.DTOs;
using StockNet.Application.DTOs.Dashboard;
using StockNet.Business.Interfaces;
using StockNet.Business.Interfaces.Dashboard;
using StockNet.Domain.Entities;

namespace StockNet.Api.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBaseService<Negocio, BusinessDto> _baseService;
        private readonly IBusinessService _businessService;
        private readonly IAuthService _authService;
        public BusinessController(IBaseService<Negocio, BusinessDto> baseServices, IBusinessService businessService, IAuthService authService)
        {
            _baseService = baseServices;
            _businessService = businessService;
            _authService = authService;
        }

        [Authorize]
        [HttpPost("createBusiness")]
        public async Task<IActionResult> CreateBusiness([FromBody] BusinessDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _businessService.CreateBusinessAsync(dto);
            return Ok(ApiResponse<BusinessCreatedResponseDto>.Ok(result.Value,"Creado correctamente"));
        }

        [Authorize]
        [HttpPut("updateBusiness")]
        public async Task<IActionResult> UpdateBusiness(BusinessEditDto dto)
        {
            var result = await _businessService.UpdateBusinessAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(ApiResponse<Negocio>.Ok(result.Value, "Actualizado correctamente"));
            }
            return BadRequest(ApiResponse<Negocio>.Fail("Error al actualizar el negocio"));
        }

        /// <summary>
        /// Metodo que valida si el usaurio tiene un negocio asignado
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("getBusiness")]
        public async Task<bool> GetBusinessForUser()
        {
            var userId = _authService.GetUserId();
            var business = await _baseService.FindFirstAsync(n => n.ApplicationUserId == userId);

            return business != null;
        }
    }
}
