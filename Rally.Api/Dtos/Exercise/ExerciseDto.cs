using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Api.Dtos.Equipment;

namespace Rally.Api.Dtos.Exercise
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public EquipmentDto? Equipment { get; set; }
    }
}