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
    public class SignRepository : Repository<Sign>, ISignRepository
    {
        public SignRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Sign> GetSignWithExercises(int id)
        {
            var spec = new SignWithExerciseSpecification(id);
            var sign = (await GetAsync(spec)).FirstOrDefault();

            if (sign is null)
            {
                throw new KeyNotFoundException("Sign not found");
            }
            return sign;
        }

        public async Task<Sign> GetSignWithTrack(int id)
        {
            var spec = new SignWithExerciseSpecification(id);
            var sign = (await GetAsync(spec)).FirstOrDefault();

            if (sign is null)
            {
                throw new KeyNotFoundException("Sign not found");
            }
            return sign;
        }
    }
}