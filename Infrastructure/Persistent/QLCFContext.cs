using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistent
{
    public class QLCFContext : IdentityDbContext
    {
        public QLCFContext(DbContextOptions<QLCFContext> options) : base(options)
        {
        }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        //     builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // }

    }
}