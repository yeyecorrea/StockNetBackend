using FluentResults;
using Microsoft.AspNetCore.Identity;
using StockNet.Application.DTOs;
using StockNet.Application.DTOs.Auth;
using StockNet.Business.Interfaces;
using StockNet.Data.Interfaces;
using StockNet.Domain.Entities;

namespace StockNet.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IAuthRepository _authRepository;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtGenerator jwtGenerator, IAuthRepository authRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _authRepository = authRepository;
        }

        /// <summary>
        /// Metodo para registrar un nuevo usuario en la aplicacion.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto dto)
        {
            var user = new ApplicationUser { UserName = dto.UserName, Email = dto.Email };
            var result = await _authRepository.CreateUserAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return Result.Fail<AuthResponseDto>($"No se pudo registrar el usuario: {string.Join("; ", result.Errors.Select(e => e.Description))}");

            }
            var token = _jwtGenerator.GenerateToken(user);
            var Response = new AuthResponseDto
            {
                UserName = user.UserName,
                Expiration = DateTime.UtcNow.AddDays(1),
                Email = user.Email,
                Token = token
            };

            return Result.Ok(Response);
        }

        /// <summary>
        /// Metodo para iniciar sesion en la aplicacion.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Result<AuthResponseDto>> LoginAsync(LoginDto dto)
        {
            var user = await _authRepository.GetUserForEmailAsync(dto.Email);
            if (user == null)
            {
                return Result.Fail<AuthResponseDto>("El usuario no se encuentra registrado.");
            }

            var result = await _authRepository.LoginUserAsync(user, dto.Password, false);
            if (!result.Succeeded)
            {
                return Result.Fail<AuthResponseDto>("Correo o contraseña incorrectos. Por favor, verifica tus datos.");
            }

            var token = _jwtGenerator.GenerateToken(user);
            var Response = new  AuthResponseDto
            {
                UserName = user.UserName,
                Expiration = DateTime.UtcNow.AddDays(1),
                Email = user.Email,
                Token = token
            };

            return Result.Ok(Response);

        }

        /// <summary>
        /// Metodo para obtener el perfil del usuario.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Result<UserProfileDto?>> GetUserProfile(string userId)
        {
            var user = await _authRepository.GetUserForIdAsync(userId);
            if (user == null)
            {
                return Result.Fail<UserProfileDto?>("Usuario no encontrado.");
            }

            var Response = new UserProfileDto
            {
                UserName = user.UserName,
                Email = user.Email,
                NombreCompleto = user.NombreCompleto,
                FotoPerfilUrl = user.FotoPerfilUrl,
                FechaNacimiento = user.FechaNacimiento,
                NumeroTelefono = user.PhoneNumber ?? string.Empty
            };

            return Result.Ok<UserProfileDto?>(Response);
        }

        /// <summary>
        /// Metodo para actualizar el perfil del usuario.
        /// </summary>
        /// <param name="userProfileDto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Result<bool>> UpdateUserProfileAsync(UserProfileDto userProfileDto, string userId)
        {
            var user = await _authRepository.GetUserForIdAsync(userId);
            if (user == null)
            {
                return Result.Fail("Usuario no encontrado.");
            }
            user.UserName = userProfileDto.UserName;
            user.Email = userProfileDto.Email;
            user.NombreCompleto = userProfileDto.NombreCompleto;
            user.FotoPerfilUrl = userProfileDto.FotoPerfilUrl;
            user.FechaNacimiento = userProfileDto.FechaNacimiento;
            user.PhoneNumber = userProfileDto.NumeroTelefono;

            var result = await _authRepository.UpdateUserAsync(user);

            if (!result)
            {
                return Result.Fail($"No se pudo actualizar el perfil");
            }
            return Result.Ok();
        }

        /// <summary>
        /// Metodo para cerrar sesion en la aplicacion.
        /// </summary>
        /// <returns></returns>
        public Task LogoutAsync()
        {
            return Task.CompletedTask;
        }
    }
}
