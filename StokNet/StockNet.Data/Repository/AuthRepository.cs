using Microsoft.AspNetCore.Identity;
using StockNet.Data.Interfaces;
using StockNet.Domain.Entities;

namespace StockNet.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        /// <summary>
        /// Meto para obtener un usuario por su ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ApplicationUser?> GetUserForIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        /// <summary>
        /// Metodo para obtener un usuario por su email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<ApplicationUser?> GetUserForEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        /// <summary>
        /// Metodo para actualizar un usuario en la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        /// <summary>
        /// metodo para crear un nuevo usuario en la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }


        /// <summary>
        /// Metodo para iniciar sesion un usuario en la aplicacion.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<SignInResult> LoginUserAsync(ApplicationUser user, string password, bool options)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, options);
        }

    }
}
