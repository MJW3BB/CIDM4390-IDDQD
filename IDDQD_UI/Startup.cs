using System;
using System.Collections.Generic;
using System.Linq;
using System.Net; // Droplet Use
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
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

using IDDQD.Areas.Identity.Data;
using IDDQD.Services;

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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            /*
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(
                Configuration.GetConnectionString("DefaultConnection")));
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddDbContext<SKLContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("SkillContext")));
        
        services.AddDbContext<DISPContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("DispositionContext")));
        
        services.AddDbContext<KNEContext>(options =>
        options.UseSqlite(Configuration.GetConnectionString("KnowledgeContext")));
          */
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddRazorPages();

            //add database and add UnitOfWork using CDKST Context
            services.AddDbContext<CDKSTContext>(
                options => options.UseMySql(Configuration.GetConnectionString("IDDQD_MYSQL_CONNECTION"),
                                            mySqlOptions => mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)
                )).AddUnitOfWork<CDKSTContext>();

            services.AddDbContext<IDDQDIdentityDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("IDDQD_ID_CONNECTION"), mySqlOptions =>
                        mySqlOptions.ServerVersion(new Version(5, 7, 29), ServerType.MySql)));
            services.AddDefaultIdentity<IdentityUser>(
            options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IDDQDIdentityDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
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
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Droplet Use
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            //this can cause headaches when testing locally.
            //uncomment for deploy
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            //for session variables
            app.UseHttpContextItemsMiddleware();
            //app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
