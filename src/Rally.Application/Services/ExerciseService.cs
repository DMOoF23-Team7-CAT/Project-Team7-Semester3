using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Interfaces;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.

        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository ?? throw new ArgumentNullException(nameof(exerciseRepository));
        }
        // TODO: Implement the methods for the Exercise
    }
}

