
using Microsoft.AspNetCore.Identity;

namespace RapidPay.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<Domain.Entities.User> _userManager;
        public UserService(UserManager<Domain.Entities.User> userManager)
        {
            _userManager = userManager; 
        }
        /// <summary>
        /// Method for creating user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<IdentityResult> CreateUser(Domain.Entities.User user)
        {
            return _userManager.CreateAsync(user);
        }
        /// <summary>
        /// Search user by User name 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Task<Domain.Entities.User?> FindByUsernameAsync(string username)
        {
            return _userManager.FindByNameAsync(username);
        }
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Domain.Entities.User?> GetById(string id)
        {
            return _userManager.FindByIdAsync(id);
        }
    }
}