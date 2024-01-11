using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Twitter.Core.Entities;
using Twitter.Core.Enums;

namespace TwitFriday.Helpers
{
    public static class Seed
    {
        public static IApplicationBuilder UseSeedData(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                using (var scope = context.RequestServices.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    await CreateRolesAsync(roleManager);
                    await CreateUserAsync(userManager, app);

                }

                await next();

            });
            return app;
        }

        static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                foreach (var role in Enum.GetNames(typeof(Roles)))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!result.Succeeded)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var error in result.Errors)
                        {
                            sb.Append(error.Description + " ");
                        }
                        throw new Exception(sb.ToString().TrimEnd());
                    }
                }
            }
        }
        static async Task CreateUserAsync(UserManager<AppUser> userManager, WebApplication app)
        {
            if (await userManager.FindByNameAsync(app.Configuration.GetSection("Admin")?["Username"]) == null)
            {
                var user = new AppUser
                {
                    UserName = app.Configuration.GetSection("Admin")["Username"],
                    Email = app.Configuration.GetSection("Admin")["Email"],
                    Surname = app.Configuration.GetSection("Admin")["Username"],
                    EmailConfirmed=true,
                    Name = app.Configuration.GetSection("Admin")["Username"]
                }; 
                var result = await userManager.CreateAsync(user, app.Configuration.GetSection("Admin")["Password"]);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.Append(error.Description + " ");
                    }
                    throw new Exception(sb.ToString().TrimEnd());
                }
                await userManager.AddToRoleAsync(user, nameof(Roles.Admin));

            }
        }
    }
}
