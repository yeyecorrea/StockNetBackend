using AutoMapper;
using FluentResults;
using StockNet.Application.DTOs.Dashboard;
using StockNet.Business.Interfaces;
using StockNet.Business.Interfaces.Dashboard;
using StockNet.Data.DataContext;
using StockNet.Domain.Entities;

namespace StockNet.Business.Services.Dashboard
{
    public class BusinessService : IBusinessService
    {
        private readonly IBaseService<Negocio, BusinessDto> _businessService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IJwtGenerator _jwtGenerator;

        public BusinessService(IBaseService<Negocio, BusinessDto> businessService, IMapper mapper, IAuthService authService, ApplicationContext context, IJwtGenerator jwtGenerator)
        {
            _businessService = businessService;
            _mapper = mapper;
            _authService = authService;
            _context = context;
            _jwtGenerator = jwtGenerator;

        }

        /// <summary>
        /// Metodo para crear un negocio y a su vez asigna el negocio al usuario autenticado.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result<BusinessCreatedResponseDto>> CreateBusinessAsync(BusinessDto dto)
        {
            //obtene el id del usuario autenticado y lo asignamos al dto
            var userId = _authService.GetUserId();
            dto.ApplicationUserId = userId;

            // Verificamos que el usuario exista antes de crear el negocio
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return Result.Fail<BusinessCreatedResponseDto>("Usuario no encontrado.");
            }

            // Creamos el negocio utilizando el servicio base
            var result = await _businessService.CreateAsync(dto);
            if (result == null)
            {
                return Result.Fail<BusinessCreatedResponseDto>("Error al crear el negocio.");
            }

            // Asignamos el negocio creado al usuario
            user.NegocioId = result.Id;
            await _context.SaveChangesAsync();

            // Mapeamos el resultado a BusinessDto
            var businessDto = new BusinessDto
            {
                Nombre = result.Nombre,
                FotoUrl = result.FotoUrl,
                Correo = result.Correo,
                ApplicationUserId = result.ApplicationUserId
            };

            var token = _jwtGenerator.GenerateToken(user);
            if (string.IsNullOrEmpty(token))
            {
                return Result.Fail<BusinessCreatedResponseDto>("Error al generar el token.");
            }

            var response = new BusinessCreatedResponseDto
            {
                Business = businessDto,
                Token = token
            };

            return Result.Ok(response).WithSuccess("Negocio creado correctamente.");
        }

        /// <summary>
        /// Metodo para actualizar un negocio.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Result<Negocio>> UpdateBusinessAsync(BusinessEditDto dto)
        {
            var entity = await _businessService.GetByIdAsync(dto.Id);
            if (entity == null)
            {
                return Result.Fail<Negocio>("No se encontró el negocio con el ID proporcionado.");
            }

            // se realiza el mapeo del modelo a la entidad Negocio
            _mapper.Map(dto, entity);

            // se actualiza el negocio utilizando el servicio base
            var result = await _businessService.UpdateAsync(entity);

            // Additional logic for updating the business can be added here.
            return Result.Ok(result);
        }




    }
}
