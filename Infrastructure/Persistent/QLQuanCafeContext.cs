using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;

namespace Infrastructure.Persistent
{
    public class QLQuanCafeContext : IdentityDbContext<AppUser>
    {
        public QLQuanCafeContext(DbContextOptions<QLQuanCafeContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}