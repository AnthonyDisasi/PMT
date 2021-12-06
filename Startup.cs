using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PMT.Data;
using PMT.Infrastructure;
using PMT.Interfaces;
using PMT.Interfaces.ImplementationServices;
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

            services.AddTransient<IServiceTache, ServiceTache>();
            services.AddTransient<IServiceNote, ServiceNote>();
            services.AddTransient<IServiceTechnicien, ServiceTechnicien>();
            services.AddTransient<IServiceAffectation, ServiceAffectation>();
            services.AddTransient<IServicePrioStatTypAsync, ServicePrioStatTypAsync>();

            services.AddTransient<IPasswordValidator<User_App>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<User_App>, CustomUserValidator>();


            services.AddDbContext<Db_Context>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DbPMT")));
            services.AddIdentity<User_App, IdentityRole>().AddEntityFrameworkStores<Db_Context>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
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
                    pattern: "{controller=Tache}/{action=Index}/{id?}");
            });
        }
    }
}
