using Rally.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<Equipment> GetEquipmentWithEquipmentBaseAsync(int equipmentId);
    }
}

