using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories.Base;
using AutoMapper.Internal.Mappers;
using Rally.Application.Dto;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class ExerciseService : Service<ExerciseDto, Exercise>, IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseService(IRepository<Exercise> repository, IExerciseRepository exerciseRepository) : base(repository)
        {
            _exerciseRepository = exerciseRepository ?? throw new ArgumentNullException(nameof(exerciseRepository));
        }

        public async Task<ExerciseDto> GetExerciseWithCategory(int exerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseWithCategoryAsync(exerciseId);
            
            var mappedExercise = ObjectMapper.Mapper.Map<ExerciseDto>(exercise);
            if (mappedExercise is null)
                throw new ApplicationException("Exercise with Category could not be mapped");

            return mappedExercise;
        }

        public async Task<ExerciseDto> GetExerciseWithEquipmentBase(int exerciseId)
        {
            var exercise = await _exerciseRepository.GetExerciseWithEquipmentBaseAsync(exerciseId);
            
            var mappedExercise = ObjectMapper.Mapper.Map<ExerciseDto>(exercise);
            if (mappedExercise is null)
                throw new ApplicationException("Exercise with EquipmentBase could not be mapped");

            return mappedExercise;
        }
    }
}

