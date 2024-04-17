using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Core.Specifications;
using Rally.Infrastructure.Data;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Equipment> GetEquipmentWithEquipmentBaseAsync(int id)
        {
            var spec = new EquipmentWithEquipmentBaseSpecification(id);
            var equipment = (await GetAsync(spec)).FirstOrDefault();

            if (equipment is null)
            {
                throw new KeyNotFoundException("Equipment not found");
            }
            return equipment;
        }
    }
}

