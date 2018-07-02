using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using TravelCRMRepo;
using Microsoft.EntityFrameworkCore;
using TravelCRMData;
using TravelCRMServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace TravelCRM
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
            services.AddDbContext<ApplicationContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options => options.LoginPath = new PathString("/Login/Account/Login"));


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAdminOperationService, AdminService>();
            services.AddTransient<ITeam, TeamService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IEmailSender, EmailSenderService>();
            services.AddTransient<IEmployeeOperationService, EmployeeService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ILeadService, LeadService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

         
            var logger = loggerFactory.CreateLogger("start");
            logger.LogInformation("Executing Configure Method");

           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //app.UseAuthentication();
           
            app.UseMvc(routes =>

            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }

}
