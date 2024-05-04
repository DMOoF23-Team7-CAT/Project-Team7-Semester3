using Rally.Core.Entities.Account;

namespace Rally.Application.Services.Account.User
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
