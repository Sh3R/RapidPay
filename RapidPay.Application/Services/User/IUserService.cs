

using Microsoft.AspNetCore.Identity;

namespace RapidPay.Application.Services.User
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUser(Domain.Entities.User user);
        Task<Domain.Entities.User?> FindByUsernameAsync(string username);
        Task<Domain.Entities.User?> GetById(string id);
    }
}