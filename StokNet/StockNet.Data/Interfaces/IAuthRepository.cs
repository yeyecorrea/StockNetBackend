using Microsoft.AspNetCore.Identity;
using StockNet.Domain.Entities;

namespace StockNet.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser?> GetUserForEmailAsync(string email);
        Task<ApplicationUser?> GetUserForIdAsync(string userId);
        Task<SignInResult> LoginUserAsync(ApplicationUser user, string password, bool options);
        Task<bool> UpdateUserAsync(ApplicationUser user);
    }
}
