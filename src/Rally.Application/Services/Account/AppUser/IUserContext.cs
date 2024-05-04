using Rally.Core.Entities.Account;

namespace Rally.Application.Services.Account.AppUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
