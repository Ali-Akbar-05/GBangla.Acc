using Application;
using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIAcc.Helper;
using WebUIAcc.Services;

namespace WebUIAcc
{
    public class Startup
    {
        public IWebHostEnvironment _environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = "X-CSRF-TOKEN-AJT-HRM";
                options.HeaderName = "X-CSRF-TOKEN-AJT-HRM";
                options.FormFieldName = "X-CSRF-TOKEN-AJT-HRM";
            });

            services.AddRazorPages()
                            .AddFluentValidation()
                            .AddDataAnnotationsLocalization()
                           .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllersWithViews()
                  .AddFluentValidation()
                  .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver())
                   .AddDataAnnotationsLocalization();

            services.AddHttpContextAccessor();
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
            }
            app.UseStaticFiles();
            app.UseErrorHandlingMiddleware();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
