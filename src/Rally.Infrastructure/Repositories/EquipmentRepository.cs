using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Core.Specifications;
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
            var spec = new EquipmentWithEquipmentBaseSpecification(equipmentId);
            var equipment = (await GetAsync(spec)).FirstOrDefault();

            if (equipment is null)
                throw new InfrastructureException("Equipment not found");

            return equipment;
        }
    }
}

