using Rally.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface ISignRepository : IRepository<Sign>
    {
        Task<Sign> GetSignWithSignBasesAsync(int signId);
    }
}

