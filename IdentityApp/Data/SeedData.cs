using IdentityApp.Authorizations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace IdentityApp.Data
{
    public class SeedData
    {
        public static async Task Initialize(
            IServiceProvider serviceProvider,  
            string password = "Test@1234")
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var managerUserId = await EnsureUser(serviceProvider, "manager@manager.net", password);
                await EnsureRole(serviceProvider, managerUserId, Constants.InvoiceManagersRole);
            }
        }
        private static async Task<string> EnsureUser(
            IServiceProvider serviceProvider,
            string userName,
            string initPW)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, initPW);
            }

            if (user == null)
            {
                throw new Exception("User did not get created. Password Policy problem?");
            }

            return user.Id;

        }

        private static async Task<IdentityResult> EnsureRole(
            IServiceProvider serviceProvider,
            string userId,
            string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            var user = await userManager.FindByIdAsync(userId);
            IdentityResult result;

            if (roleManager == null)
            {

            }

            if (await roleManager.RoleExistsAsync(role) ==  false)
            {
                result = await roleManager.CreateAsync(new IdentityRole(role));
            }

            if(user == null)
            {
                throw new Exception("User not existing");
            }

            result = await userManager.AddToRoleAsync(user, role);

            return result;
        }

    }
}
