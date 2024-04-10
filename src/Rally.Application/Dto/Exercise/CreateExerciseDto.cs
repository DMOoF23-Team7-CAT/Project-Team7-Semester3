using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Application.Dto.Exercise
{
    public class CreateExerciseDto
    {
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}