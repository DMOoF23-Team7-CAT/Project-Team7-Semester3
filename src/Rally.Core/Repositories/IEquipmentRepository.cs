using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<Equipment> GetEquipmentWithEquipmentBaseAsync(int equipmentId);
    }
}

