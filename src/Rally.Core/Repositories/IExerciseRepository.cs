using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories.Base;
using Rally.Core.Entities;

namespace Rally.Core.Repositories
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        Task<Exercise> GetExerciseWithCategoryAsync(int id);
        Task<Exercise> GetExerciseWithEquipmentBaseAsync(int id);
    }
}