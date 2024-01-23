using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await SeedAdmin();
            await SeedUsers();
        }
        private async Task SeedAdmin()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var admin = new ApplicationUser()
            {
                UserName="admin@mail.com",
                Name = "Admin",
                Email = "admin@mail.com",
                Phone="9876543210"
            };

            var user = await _userManager.FindByNameAsync(admin.Email);
            if (user == null)
            {
                var result = await _userManager.CreateAsync(admin, "Admin@123");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
        private async Task SeedUsers()
        {
            if(!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName="usera@mail.com",
                    Name = "User A",
                    Email="usera@mail.com",
                    Phone="9876543211"
                },
                new ApplicationUser()
                {
                    UserName="userb@mail.com",
                    Name="User B",
                    Email="userb@mail.com",
                    Phone="9876543212"
                },
                new ApplicationUser()
                {
                    UserName="userc@mail.com",
                    Name="User C",
                    Email="userc@mail.com",
                    Phone="9786543210"
                },
                new ApplicationUser()
                {
                    UserName="userd@mail.com",
                    Name="User D",
                    Email="userd@mail.com",
                    Phone="9786543222"
                }
            };

            foreach(var user in users)
            {
                var currentUser = await _userManager.FindByNameAsync(user.Email);
                if (currentUser == null)
                {
                    var result = await _userManager.CreateAsync(user, "Default@123");
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                }
            }
        }
    }
}
