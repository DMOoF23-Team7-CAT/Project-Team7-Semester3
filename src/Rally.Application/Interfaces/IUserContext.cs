using Rally.Core.Entities.Account;

namespace Rally.Application.Interfaces
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
