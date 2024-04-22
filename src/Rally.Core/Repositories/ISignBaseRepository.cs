using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface ISignBaseRepository : IRepository<SignBase>
    {
        Task<SignBase> GetSignBaseWithCategoryAsync(int SignBaseId);
        Task<SignBase> GetSignBaseWithEquipmentBaseAsync(int SignBaseId);
    }
}