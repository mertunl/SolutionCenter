using DataAccessLayer.DatabaseContext;
using EntityLayer.Entites;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Utility;
using Utility.Constants;

namespace SolutionCenter.Extensions
{
    public static class SolutionCenterServiceExtensions
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
			//Seed Roles
			var userManager = service.GetService<UserManager<AppUser>>();
			var roleManager = service.GetService<RoleManager<IdentityRole>>();
			await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
			await roleManager.CreateAsync(new IdentityRole(Roles.User));

			// creating admin

			var user = new AppUser
			{
				UserName = "admin@gmail.com",
				Email = "admin@gmail.com",
				Name = "Mert",
				EmailConfirmed = true,
				PhoneNumberConfirmed = true
			};
			var userInDb = await userManager.FindByEmailAsync(user.Email);
			if (userInDb == null)
			{
				await userManager.CreateAsync(user, "Admin@123");
				await userManager.AddToRoleAsync(user, Roles.Admin);
			}
		}
        public static IServiceCollection AddSolutionCenterServices(this IServiceCollection services)
        {
 
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            //services.AddIdentity<AppUser, IdentityRole>()
            //    .AddEntityFrameworkStores<Context>()
            //    .AddDefaultUI()
            //    .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
            });
            return services;
        }
    }
}
