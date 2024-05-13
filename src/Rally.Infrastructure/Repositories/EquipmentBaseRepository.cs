using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Infrastructure.Data;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class EquipmentBaseRepository : Repository<EquipmentBase>, IEquipmentBaseRepository
    {
        public EquipmentBaseRepository(RallyContext dbContext) : base(dbContext)
        {
        }
    }
}