using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Core.Specifications;
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
            var spec = new SignWithSignBaseSpecification(signId);
            var sign = (await GetAsync(spec)).FirstOrDefault();

            if (sign is null)
                throw new InfrastructureException("Sign not found");

            return sign;
        }

        public async Task<Sign> GetSignWithTrackAsync(int signId)
        {
            var spec = new SignWithSignBaseSpecification(signId);
            var sign = (await GetAsync(spec)).FirstOrDefault();

            if (sign is null)
                throw new InfrastructureException("Sign not found");

            return sign;
        }
    }
}