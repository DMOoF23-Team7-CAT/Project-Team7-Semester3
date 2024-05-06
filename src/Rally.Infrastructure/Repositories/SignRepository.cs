using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Core.Repositories;

using Rally.Infrastructure.Data;
using Rally.Infrastructure.Exceptions;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class SignRepository : Repository<Sign>, ISignRepository
    {
        public SignRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Sign> GetSignWithSignBasesAsync(int signId)
        {
            var sign = await _dbContext.Set<Sign>()
                .Include(s => s.SignBase)
                .FirstOrDefaultAsync(s => s.Id == signId);

            if (sign is null)
                throw new InfrastructureException("Sign not found");

            return sign;
        }

    }
}