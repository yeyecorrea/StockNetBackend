using FluentResults;
using StockNet.Application.DTOs;
using StockNet.Application.DTOs.Auth;

namespace StockNet.Business.Interfaces
{
    public interface IAuthService
    {
        Task<Result<UserProfileDto?>> GetUserProfile(string userId);
        Task<Result<AuthResponseDto>> LoginAsync(LoginDto dto);
        Task LogoutAsync();
        Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto dto);
        Task<Result<bool>> UpdateUserProfileAsync(UserProfileDto userProfileDto, string userId);
    }
}
