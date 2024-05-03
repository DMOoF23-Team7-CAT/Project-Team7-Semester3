using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Core.Specifications;
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
            var spec = new SignBaseWithCategorySpecification(SignBaseId);
            var SignBase = (await GetAsync(spec)).FirstOrDefault();

            if (SignBase is null)
                throw new InfrastructureException("SignBase not found");

            return SignBase;
        }

        public async Task<SignBase> GetSignBaseWithEquipmentBaseAsync(int SignBaseId)
        {
            var spec = new SignBaseWithEquipmentBaseSpecification(SignBaseId);
            var SignBase = (await GetAsync(spec)).FirstOrDefault();

            if (SignBase is null)
                throw new InfrastructureException("SignBase not found");

            return SignBase;
        }
    }
}

