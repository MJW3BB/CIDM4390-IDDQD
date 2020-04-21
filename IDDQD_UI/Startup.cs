using System;
using System.Collections.Generic;
using System.Linq;
using System.Net; // Droplet Use
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.HttpOverrides; // Droplet Use
using Microsoft.EntityFrameworkCore;
using IDDQD_Data.Data; // We are calling context not models
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using IDDQD.Middleware;
using IDDQD_Repo.DependencyInjection;
using IDDQD_Data.Data.Models; 
using IDDQD.Areas.Identity.Data; 

namespace IDDQD
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
            services.AddDbContext<IDDQDIdentityDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IDDQDIdentityDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
                //add database and add UnitOfWork using Wizard Context
            services.AddDbContext<CDKSTContext>(
                options => options.UseMySql(Configuration.GetConnectionString("IDDQD_MYSQL_CONNECTION"),
                                            mySqlOptions => mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)
                )).AddUnitOfWork<CDKSTContext>();  
                    services.ConfigureApplicationCookie(options =>
    {
        // Cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

        options.LoginPath = "/Identity/Account/Login";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.SlidingExpiration = true;
    });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
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
            // Droplet Use
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // app.UseHttpsRedirection();
            // app.UseStaticFiles();
            // app.UseRouting();
            // app.UseAuthentication();
            // app.UseAuthorization();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapRazorPages();
            // });
}
      
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            


      

          

    //     services.Configure<IdentityOptions>(options =>
    //     {
    //     // Password settings.
    //     options.Password.RequireDigit = true;
    //     options.Password.RequireLowercase = true;
    //     options.Password.RequireNonAlphanumeric = true;
    //     options.Password.RequireUppercase = true;
    //     options.Password.RequiredLength = 6;
    //     options.Password.RequiredUniqueChars = 1;

    //     // Lockout settings.
    //     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //     options.Lockout.MaxFailedAccessAttempts = 5;
    //     options.Lockout.AllowedForNewUsers = true;

    //     // User settings.
    //     options.User.AllowedUserNameCharacters =
    //     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    //     options.User.RequireUniqueEmail = false;
    // });

}
      

}