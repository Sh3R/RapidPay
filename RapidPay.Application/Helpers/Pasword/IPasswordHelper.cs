using RapidPay.Domain.Entities;

namespace RapidPay.Application.Helpers.Pasword
{
    public interface IPasswordHelper
    {
        string HashPassword(User user, string password);
        bool VerifyPassword(User user, string hashedPassword, string password);
    }
}