using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;
using Rally.Application.Exercise.Dto;

namespace Rally.Application.Category.Dto
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;
        public ICollection<ExerciseDto> Exercises { get; set; }

        public CategoryDto(string name, string rules, ICollection<ExerciseDto> exercises)
        {
            Name = name;
            Rules = rules;
            Exercises = exercises ?? new List<ExerciseDto>();
        }
    }
}