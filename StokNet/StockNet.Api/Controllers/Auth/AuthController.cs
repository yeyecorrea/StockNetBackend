using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockNet.Application.DTOs;
using StockNet.Application.DTOs.Auth;
using StockNet.Application.DTOs.Token;
using StockNet.Business.Interfaces;
using StockNet.Business.Services;
using System.Security.Claims;

namespace StockNet.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtGenerator _jwtGenerator;
        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor, IJwtGenerator jwtGenerator)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
            _jwtGenerator = jwtGenerator;
        }

        private string GetUserId()
        {
            var claims = _httpContextAccessor.HttpContext?.User?.Claims.ToList();
            // Revisa el contenido de claims aquí
            return claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub")?.Value ?? string.Empty;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (result.IsFailed)
            {
                return BadRequest(ApiResponse<AuthResponseDto>.Fail(result.Errors.First().Message));
            }
            return Ok(ApiResponse<AuthResponseDto>.Ok(result.Value, "Registro exitoso"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result.IsFailed)
                return BadRequest(ApiResponse<AuthResponseDto>.Fail(result.Errors.First().Message));

            return Ok(ApiResponse<AuthResponseDto>.Ok(result.Value, "Login exitoso"));
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new { message = "Logged out" });
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = GetUserId();
            var profile = await _authService.GetUserProfile(userId);
            if (profile.IsFailed || profile.Value == null)
            {
                return BadRequest(ApiResponse<UserProfileDto>.Fail(profile.Errors.First().Message));
            }
            return Ok(ApiResponse<UserProfileDto>.Ok(profile.Value, "User profile retrieved successfully."));
        }

        [Authorize]
        [HttpPut("updateProfile")]
        public async Task<IActionResult> UpdateProfile(UserProfileDto dto)
        {
            var result = await _authService.UpdateUserProfileAsync(dto, GetUserId());
            if (result.IsFailed)
            {
                return BadRequest(ApiResponse<bool>.Fail(result.Errors.First().Message));
            }
            return Ok(ApiResponse<bool>.Ok(result.Value, "User profile updated successfully."));
        }

        [HttpGet("validateToken")]
        public IActionResult ValidateJwtToken([FromQuery] string token)
        {
            var result = _jwtGenerator.ValidateToken(token);

            if (result.IsFailed)
            {
                return BadRequest(ApiResponse<TokenValidationResultDto>.Fail(result.Errors.First().Message));
            }

            return Ok(ApiResponse<TokenValidationResultDto>.Ok(result.Value, "Token validation successful."));
        }


    }
}
