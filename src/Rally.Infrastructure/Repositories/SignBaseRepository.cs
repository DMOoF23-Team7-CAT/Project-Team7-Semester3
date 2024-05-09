using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Core.Repositories;

using Rally.Infrastructure.Data;
using Rally.Infrastructure.Exceptions;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class SignBaseRepository : Repository<SignBase>, ISignBaseRepository
    {
        public SignBaseRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<SignBase> GetSignBaseWithCategoryAsync(int SignBaseId)
        {
            try
            {
                var SignBase = await _dbContext.Set<SignBase>()
                    .Include(s => s.Category)
                    .FirstOrDefaultAsync(s => s.Id == SignBaseId);

                if (SignBase is null)
                    throw new InfrastructureException("SignBase not found");

                return SignBase;
            }
            catch (Exception)
            {
                throw new InfrastructureException("Error loading sign base with category");
            }
        }

        public async Task<SignBase> GetSignBaseWithEquipmentBaseAsync(int SignBaseId)
        {
            try {
                var SignBase = await _dbContext.Set<SignBase>()
                    .Include(s => s.EquipmentBase)
                    .FirstOrDefaultAsync(s => s.Id == SignBaseId);

                if (SignBase is null)
                    throw new InfrastructureException("SignBase not found");

                return SignBase;
            }
            catch (Exception)
            {
                throw new InfrastructureException("Error loading sign base with equipment base");
            }
        }
    }
}

