using Microsoft.AspNetCore.Identity;
using System;

namespace Domain.Entities
{
    public class AppUserRole : IdentityRole<Guid>
    {
        public AppUserRole() : base()
    {
    }

    public AppUserRole(string roleName) : base(roleName)
    {
    }
    }
}