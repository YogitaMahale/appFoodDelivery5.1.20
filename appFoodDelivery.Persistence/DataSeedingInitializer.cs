using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using appFoodDelivery.Entity;

namespace appFoodDelivery.Persistence
{
    public static class DataSeedingInitializer
    {
        public static async Task UserAndRoleSeedAsync(UserManager<ApplicationUser> userManager,
                                                 RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin","Store" };
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //Create Admin User
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    name ="admin",
                    mobileno = "0000000000"

                     
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            ////Create Manager User
            //if (userManager.FindByEmailAsync("manager@gmail.com").Result == null)
            //{
            //    IdentityUser user = new IdentityUser
            //    {
            //        UserName = "manager@gmail.com",
            //        Email = "manager@gmail.com"
            //    };
            //    IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
            //    if (identityResult.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(user, "Manager").Wait();
            //    }
            //}

            ////Create Staff User
            //if (userManager.FindByEmailAsync("jane.doe@gmail.com").Result == null)
            //{
            //    IdentityUser user = new IdentityUser
            //    {
            //        UserName = "jane.doe@gmail.com",
            //        Email = "jane.doe@gmail.com"
            //    };
            //    IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
            //    if (identityResult.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(user, "Staff").Wait();
            //    }
            //}

            ////Create No Role User
            //if (userManager.FindByEmailAsync("john.doe@gmail.com").Result == null)
            //{
            //    IdentityUser user = new IdentityUser
            //    {
            //        UserName = "john.doe@gmail.com",
            //        Email = "john.doe@gmail.com"
            //    };
            //    IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
            //    //No Role assigned to Mr John Doe
            //}
        }
    }
}
