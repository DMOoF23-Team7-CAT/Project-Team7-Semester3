using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;

namespace Rally.Application.Dto
{
    public class ExerciseDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

    }
}