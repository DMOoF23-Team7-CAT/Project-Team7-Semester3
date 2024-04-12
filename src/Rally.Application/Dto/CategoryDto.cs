using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;
using Rally.Application.Dto.Category;
using Rally.Application.Dto.Exercise;

namespace Rally.Application.Dto.Category
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;
        public ICollection<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
    }
}