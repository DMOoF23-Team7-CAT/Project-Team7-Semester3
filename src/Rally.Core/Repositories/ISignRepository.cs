using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface ISignRepository : IRepository<Sign>
    {
        Task<Sign> GetSignWithExercisesAsync(int signId);
        Task<Sign> GetSignWithTrackAsync(int signId);
    }
}

