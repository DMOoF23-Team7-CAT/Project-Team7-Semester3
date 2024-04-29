using MediatR;
using Microsoft.AspNetCore.Identity;
using Rally.Core.Entities.Account;

namespace Rally.Application.Services.MediatR
{
    public class AssignUserRoleCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
                                             : IRequestHandler<AssignUserRoleCommand>
    {        
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            //Checks if the user exists in the database by his email
            var user = await userManager.FindByEmailAsync(request.UserEmail)
                ?? throw new ApplicationException("User not found");

            //Checks if a given role exists in the database
            var role = await roleManager.FindByNameAsync(request.RoleName)
                ?? throw new ApplicationException("Role not found");

            //Assigning a user to a given role
            if (role != null)
                await userManager.AddToRoleAsync(user, role.Name!);

        }   

    }
}
