using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        
    }
}