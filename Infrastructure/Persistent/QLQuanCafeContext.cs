using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;
using System;

namespace Infrastructure.Persistent
{
    public class QLQuanCafeContext : IdentityDbContext<AppUser,AppUserRole,Guid>
    {
        public QLQuanCafeContext(DbContextOptions<QLQuanCafeContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<AppUserRole> AppUserRoles {get;set;}
        public DbSet<The> Thes { get; set; }

        public DbSet<NuocUongThe> DSNU { get; set; }

         public DbSet<NuocUong> NUs { get; set; }

         public DbSet<HoaDon> HDs { get; set; }

         public DbSet<ChiTietHoaDon> CTHDs { get; set; }
    }
}