using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Application.Services.Auth
{
    public interface ITokenService
    {
        string CreateToken(Domain.Entities.User user, List<Claim> authClaims);
        string? ValidateJwtToken(string token);
    }
}