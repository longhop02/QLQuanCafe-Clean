using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Persistent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Repositories;
using Application.Interfaces;
using Application.Services;

namespace QLQuanCafe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QLQuanCafeContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<AppUser>(options =>
                 {options.SignIn.RequireConfirmedAccount = false;
                 options.Password.RequiredUniqueChars = 0;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase =false;
                 })
                .AddRoles<AppUserRole>()
                .AddEntityFrameworkStores<QLQuanCafeContext>();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                // options.Conventions.AddAreaPageRoute("Identity","/Account/Login","");
                // options.Conventions.AuthorizePage("/Account/Manage/Index");
                // options.Conventions.AuthorizePage("/Home/Index");
            });
            services.AddScoped<ITheRepository, EFTheRepository>();
            services.AddScoped<IDSNURepository, EFDSNURepository>();
            services.AddScoped<INURepository, EFNURepository>();
            services.AddScoped<IHoaDonRepository, EFHoaDonRepository>();
            services.AddScoped<ICTHDRepository, EFCTHDRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<INuocUongRepository, NuocUongRepository>();
            services.AddScoped<INuocUongService, NuocUongService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
