using Djoz.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Infrastructure.ExternalServices.AuthenticationServices
{
    public static class SeedRoles
    {
        public static async Task InitializeAsync(RoleManager<AppRole> roleManager)
        {
            string[] roles = { "Admin", "Member", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new AppRole { Name = role });
                }
            }
        }
    }
}
