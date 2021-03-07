using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using SinavProje.Business.DependencyResolvers.RegisterServices;
using SinavProje.Core.Utilities.Security.Authorization;
using SinavProje.DataAccess.Concrete.Base;

namespace SinavProje
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
            services.AddEntityFrameworkSqlite().AddDbContext<SqLiteDbContext>();
            
            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.LoginPath = new PathString("/Auth/Index");
            });
            services.AddHttpContextAccessor();
            services.AddScopedBusinessServices();
            services.AddScopedCoreServices();
            services.AddScopedDataAccessServices();
            

            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Index}/{id?}");
            });
        }
        public virtual TokenOptions GetTokenOptions()
        {
            return Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
    }
}
