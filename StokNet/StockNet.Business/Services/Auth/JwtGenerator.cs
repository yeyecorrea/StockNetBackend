using FluentResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockNet.Application.DTOs.Token;
using StockNet.Business.Interfaces;
using StockNet.Domain.Entities;
using StockNet.Shared.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockNet.Business.Services.Auth
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Metodo que geenra el token del usuario autenticado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateToken(ApplicationUser user)
        {
            // Los clains son los datos que representan al usuario en el token.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim("fotoUrl", user.FotoPerfilUrl ?? ""),

            };

            // se agrega el NegocioId si el usuario tiene un negocio asociado
            if (user.NegocioId.HasValue)
            {
                claims.Add(new Claim("negocioId", user.NegocioId.Value.ToString()));
            }

            // Clave secreta para firmar el token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //Credenciales de firma del token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // El JWT en sí
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Metodo para validar el token JWT.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Result<TokenValidationResultDto> ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var parameters = JwtConfig.GetTokenValidationParameters(_configuration);

            try
            {
                var principal = tokenHandler.ValidateToken(token, parameters, out _);

                var username = principal.Identity?.Name;
                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                var roles = principal.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

                var resultDto = new TokenValidationResultDto
                {
                    IsValid = true,
                    Username = username,
                    Email = email,
                    Roles = roles
                };

                return Result.Ok(resultDto);
            }
            catch (SecurityTokenExpiredException)
            {
                return Result.Fail<TokenValidationResultDto>("Token expirado");
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return Result.Fail<TokenValidationResultDto>("Firma inválida");
            }
            catch (SecurityTokenInvalidIssuerException)
            {
                return Result.Fail<TokenValidationResultDto>("Emisor inválido");
            }
            catch (SecurityTokenInvalidAudienceException)
            {
                return Result.Fail<TokenValidationResultDto>("Audiencia inválida");
            }
            catch (Exception ex)
            {
                return Result.Fail<TokenValidationResultDto>($"Error al validar el token: {ex.Message}");
            }
        }

    }
}
