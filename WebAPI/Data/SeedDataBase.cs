using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SeedDataBase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "admin@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Admin"
                };
                userManager.CreateAsync(user, "Root@@123");
            }
        }
    }
}
