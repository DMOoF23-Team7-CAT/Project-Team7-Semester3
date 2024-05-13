namespace Rally.Application.Interfaces
{
    public interface IAccountService
    {
        Task AssignRoleAsync(string userEmail, string roleName);        
        Task UnassignRoleAsync(string userEmail, string roleName);
        Task LogoutAsync();
    }
}

