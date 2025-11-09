using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockNet.Application.DTOs;
using StockNet.Application.DTOs.Dashboard;
using StockNet.Business.Interfaces;
using StockNet.Business.Interfaces.Dashboard;
using StockNet.Domain.Entities;
using System.Net.WebSockets;

namespace StockNet.Api.Controllers.Dashboard
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBaseService<Cliente, CustomerDto> _baseService;
        private readonly ICustomerService _customerService;
        public CustomerController(IBaseService<Cliente, CustomerDto> baseService, ICustomerService customerService)
        {
            _baseService = baseService;
            _customerService = customerService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetCustomerByBusiness();
            return result.Any() 
                ? Ok(ApiResponse<IEnumerable<Cliente>>.Ok(result, "Clientes obtenidos correctamente")) 
                : NotFound(ApiResponse<IEnumerable<Cliente>>.Fail("No se encontraron clientes."));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Result<Cliente> result = await _baseService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                return NotFound();
            }
            return Ok(ApiResponse<Cliente>.Ok(result.Value, "Actualizado correctamente"));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
        {
            var negocioId = _customerService.ObtenerNegocioIdDesdeClaims();
            customerDto.NegocioId = negocioId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Result<Cliente> result = await _baseService.CreateAsync(customerDto);
            return Ok(ApiResponse<Cliente>.Ok(result.Value, "Actualizado correctamente"));
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] CustomerDto customerDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var customer = await _baseService.GetByIdAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    customerDto.Id = id;
        //    Result<Cliente> result = await _baseService.UpdateAsync(customerDto);
        //    return Ok(ApiResponse<Cliente>.Ok(result.Value, "Actualizado correctamente"));
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _baseService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _baseService.DeleteAsync(id);
            return Ok(ApiResponse<Cliente>.Ok(null, "Eliminado correctamente"));
        }
    }
}
