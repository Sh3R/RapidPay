using RapidPay.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace RapidPay.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}