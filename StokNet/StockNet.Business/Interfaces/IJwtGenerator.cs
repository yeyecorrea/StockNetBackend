using FluentResults;
using StockNet.Application.DTOs.Token;
using StockNet.Domain.Entities;

namespace StockNet.Business.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(ApplicationUser user);
        Result<TokenValidationResultDto> ValidateToken(string token);
    }
}
