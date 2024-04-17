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
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Exercise> GetExerciseWithCategoryAsync(int id)
        {
            var spec = new ExerciseWithCategorySpecification(id);
            var exercise = (await GetAsync(spec)).FirstOrDefault();

            if (exercise is null)
            {
                throw new KeyNotFoundException("Exercise not found");
            }
            return exercise;
        }   

        public async Task<Exercise> GetExerciseWithEquipmentBaseAsync(int id)
        {
            var spec = new ExerciseWithEquipmentBaseSpecification(id);
            var exercise = (await GetAsync(spec)).FirstOrDefault();

            if (exercise is null)
            {
                throw new KeyNotFoundException("Exercise not found");
            }
            return exercise;
        }
    }
}

