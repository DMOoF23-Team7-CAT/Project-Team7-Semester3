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
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Exercise> GetExerciseWithCategoryAsync(int exerciseId)
        {
            var spec = new ExerciseWithCategorySpecification(exerciseId);
            var exercise = (await GetAsync(spec)).FirstOrDefault();

            if (exercise is null)
                throw new InfrastructureException("Exercise not found");

            return exercise;
        }

        public async Task<Exercise> GetExerciseWithEquipmentBaseAsync(int exerciseId)
        {
            var spec = new ExerciseWithEquipmentBaseSpecification(exerciseId);
            var exercise = (await GetAsync(spec)).FirstOrDefault();

            if (exercise is null)
                throw new InfrastructureException("Exercise not found");

            return exercise;
        }
    }
}

