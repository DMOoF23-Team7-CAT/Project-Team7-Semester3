using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Core.Repositories;

using Rally.Infrastructure.Data;
using Rally.Infrastructure.Exceptions;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Equipment> GetEquipmentWithEquipmentBaseAsync(int equipmentId)
        {
            var equipment = await _dbContext.Set<Equipment>()
                .Include(e => e.EquipmentBase)
                .FirstOrDefaultAsync(e => e.Id == equipmentId);

            if (equipment is null)
                throw new InfrastructureException("Equipment not found");

            return equipment;
        }
    }
}

