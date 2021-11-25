using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PMT.Data;
using PMT.Models;
using PMT.Services;
using PMT.Services.ImplementationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<Db_Context>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DbPMT")));
            services.AddIdentity<User_App, IdentityRole>().AddEntityFrameworkStores<Db_Context>();

            services.AddTransient<IServiceTache, ServiceTache>();
            services.AddTransient<IServiceNote, ServiceNote>();
            services.AddTransient<IServiceTechnicien, ServiceTechnicien>();
            services.AddTransient<IServiceAffectation, ServiceAffectation>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
