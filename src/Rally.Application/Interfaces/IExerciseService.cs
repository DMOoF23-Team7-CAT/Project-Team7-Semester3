using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface IExerciseService : IService<ExerciseDto, Exercise>
    {
        Task<ExerciseDto> GetExerciseWithEquipmentBase(int exerciseId);
        Task<ExerciseDto> GetExerciseWithCategory(int exerciseId);
    }
}

