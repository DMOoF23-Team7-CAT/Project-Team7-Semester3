using Rally.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface ISignBaseRepository : IRepository<SignBase>
    {
        Task<SignBase> GetSignBaseWithEquipmentBaseAsync(int SignBaseId);
    }
}