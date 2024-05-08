
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Rally.Application.Interfaces;
using Rally.Core.Entities.Account;

namespace Rally.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AssignRoleAsync(string userEmail, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(userEmail)
                ?? throw new ApplicationException("User not found");

            var role = await _roleManager.FindByNameAsync(roleName)
                ?? throw new ApplicationException("Role not found");

            if (string.IsNullOrEmpty(role.Name))
                throw new ApplicationException("Role name is null or empty");

            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task UnassignRoleAsync(string userEmail, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(userEmail)
                ?? throw new ApplicationException("User not found");

            var role = await _roleManager.FindByNameAsync(roleName)
                ?? throw new ApplicationException("Role not found");

            if (string.IsNullOrEmpty(role.Name))
                throw new ApplicationException("Role name is null or empty");

            await _userManager.RemoveFromRoleAsync(user, role.Name);
        }

        public async Task LogoutAsync()
        {
            // Sign out the current user
            await _signInManager.SignOutAsync();
           
        }
    }
}