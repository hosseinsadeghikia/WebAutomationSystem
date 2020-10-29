using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.DbContexts;
using WebAutomationSystem.Infrastructure.Repositories;
using WebAutomationSystem.Infrastructure.Repositories.Generic;
using WebAutomationSystem.Infrastructure.Repositories.Roles;
using WebAutomationSystem.Infrastructure.Repositories.Users;
using WebAutomationSystem.Infrastructure.UnitOfWork;

namespace WebAutomationSystem
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
            services.AddDbContext<ApplicationDbContext>(
                option =>
                    option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                sqlOption =>
                    sqlOption.MigrationsAssembly("WebAutomationSystem.Infrastructure")));

            services.AddIdentity<ApplicationUsers, ApplicationRoles>(option =>
                {
                    option.Password.RequireDigit = false;
                    option.Password.RequiredLength = 4;
                    option.Password.RequireLowercase = false;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddControllersWithViews().AddNewtonsoftJson().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddTransient<ApplicationDbContext>();
            services.AddTransient<IGenericRepository<ApplicationUsers>, UsersRepository>();
            services.AddTransient<IGenericRepository<ApplicationRoles>, RolesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //Admin
                endpoints.MapAreaControllerRoute(
                    "Admin",
                    "AdminPanel",
                    "Admin/{controller=UserManager}/{action=Index}/{id?}"
                );

                //User
                endpoints.MapAreaControllerRoute(
                    "User",
                    "UserPanel",
                    "User/{controller=Home}/{action=Index}/{id?}"
                );

                //Default
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
