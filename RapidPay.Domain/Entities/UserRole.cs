using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RapidPay.Domain.Entities
{
    public class UserRole : IdentityRole<Guid>
    {
        public override string Name { get; set; }
    }
}