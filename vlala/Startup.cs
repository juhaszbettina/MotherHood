using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotherHood.Data;
using MotherHood.Models;

namespace MotherHood
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();


            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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

            JogosultsagokBeallitasa(serviceProvider).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private async Task JogosultsagokBeallitasa(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var vanUser = await RoleManager.RoleExistsAsync("User");
            if (!vanUser)
            {
                IdentityRole szerepkor = new IdentityRole("User");
                await RoleManager.CreateAsync(szerepkor);
            }
            var vanAdmin = await RoleManager.RoleExistsAsync("Admin");
            if (!vanAdmin)
            {
                IdentityRole szerepkor = new IdentityRole("Admin");
                await RoleManager.CreateAsync(szerepkor);
            }
            var vanSuperAdmin = await RoleManager.RoleExistsAsync("SuperAdmin");
            if (!vanSuperAdmin)
            {
                IdentityRole szerepkor = new IdentityRole("SuperAdmin");
                await RoleManager.CreateAsync(szerepkor);
            }

            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser Sadmin = await userManager.FindByNameAsync("admin@admin.com");
            if (Sadmin == null)
            {
                var felhasznalo = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com", EmailConfirmed = true, LockoutEnabled = false, firstName="admin", lastName = "super", MegyeId = 19, SzuletesiEv=DateTime.Parse("1995-09-24")};
                var letre = await userManager.CreateAsync(felhasznalo, "Almafa13;");
                if (letre.Succeeded)
                {
                    await userManager.AddToRoleAsync(felhasznalo, "SuperAdmin");
                }
            }
        }
    }
}
