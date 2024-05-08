﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Rally.Application.Services.MediatR;
using Rally.Core.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Application.Services.Account
{
    public class UnassignUserRoleCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
                                             : IRequestHandler<UnassignUserRoleCommand>
    {
        public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
        {
            //Checks if the user exists in the database by his email
            var user = await userManager.FindByEmailAsync(request.UserEmail)
                ?? throw new ApplicationException("User not found");

            //Checks if a given role exists in the database
            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new ApplicationException("Role not found");

            //Unassigning a user to a given role
            if (role != null)
            {
                try
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name!);
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error unassigning user to role");
                }
            }
        }

    }
}