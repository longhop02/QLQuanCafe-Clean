using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QLQuanCafe.Areas.Identity.Data;

[assembly: HostingStartup(typeof(QLQuanCafe.Areas.Identity.IdentityHostingStartup))]
namespace QLQuanCafe.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<QLQuanCafeIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QLQuanCafeIdentityDbContextConnection")));

                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<QLQuanCafeIdentityDbContext>();
            });
        }
    }
}