using Application.Common.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.ImplementInterfaces.Repositories;
 
using Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business;
using Infrastructure.ImplementInterfaces.Services.GBAcc.Business;
using Infrastructure.Persistence;
using Infrastructure.Services;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
                services.AddDbContext<GBAccDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("GBAccConnection"),
                        b => b.MigrationsAssembly(typeof(GBAccDbContext).Assembly.FullName)).EnableSensitiveDataLogging());
                /*
                services.AddDbContext<MaterialsManagementDbContext>(options => {
                    options.UseSqlServer(configuration.GetConnectionString("MaterialsManagementConnection"));
                    options.EnableSensitiveDataLogging();
                });
                services.AddDbContext<EmbroDbContext>(options => {
                    options.UseSqlServer(configuration.GetConnectionString("EmbroConnection"));
                    options.EnableSensitiveDataLogging();
                });
                services.AddDbContext<MaxcoDbContext>(options => {
                    options.UseSqlServer(configuration.GetConnectionString("MaxcoConnection"));
                    options.EnableSensitiveDataLogging();
                });
                services.AddDbContext<AOPDbContext>(options => {
                    options.UseSqlServer(configuration.GetConnectionString("AOPConnection"));
                    options.EnableSensitiveDataLogging();
                });

          
                services.AddDbContext<HRMSDBContext>(options => {
                    options.UseSqlServer(configuration.GetConnectionString("HRMSConnection"));
                    options.EnableSensitiveDataLogging();
                });
                      */
 

            // services.AddScoped<IHRMDbContext>(provider => provider.GetService<ERPAccessAuthDBContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();
            /*
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ERPAccessAuthDBContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
                //lockout Setting
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(45);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(45);

                options.LoginPath = "/Identity/Authenticate/Login";
                options.AccessDeniedPath = "/Identity/Authenticate/AccessDenied";
                options.SlidingExpiration = true;
            });
            */

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            /*
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            */

            services.AddTransient<IDateTime, DateTimeService>();
          
            // services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            Dependency(services, configuration);
            /*
            services.AddAuthentication()
                .AddIdentityServerJwt();
           */

            return services;
        }


        public static void Dependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #region Assembly Repository
            //This registers the service layer: I only register the classes who name ends with "Service" (at the moment)
            services.RegisterAssemblyPublicNonGenericClasses(
                Assembly.GetExecutingAssembly())
                .Where(s => s.Name.EndsWith("Repository")
                         || s.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            //Now I register the  assembly used by DevModService
            services.RegisterAssemblyPublicNonGenericClasses(
                     Assembly.GetAssembly(typeof(VoucherService)))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(
                Assembly.GetAssembly(typeof(VoucherRepository)))
           .AsPublicImplementedInterfaces();


            //Put any code here to initialise values from the configuration parameter
            #endregion Assembly Repository

        }
    }
}
