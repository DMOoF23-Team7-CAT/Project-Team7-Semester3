using Microsoft.AspNetCore.Identity;
using Rally.Core.Entities.Account;
using Rally.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Infrastructure.Seeders
{
    public class RallySeeder(RallyContext context) : IRallySeeder
    {
        public async Task SeedAsync()
        {
            if (await context.Database.CanConnectAsync())
            {
                if (!context.Roles.Any())
                {
                    var roles = GetRoles();
                    context.Roles.AddRange(roles);
                    await context.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.User),
                    new (UserRoles.Judge),
                    new (UserRoles.Admin)
                ];
            return roles;
        }
    }
}
