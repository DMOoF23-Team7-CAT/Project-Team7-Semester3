using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Category.Dto;
using Rally.Application.Dto.Base;
using Rally.Application.Dto.Category;
using Rally.Application.Dto.Equipment;

namespace Rally.Application.Dto.Exercise
{
    public class ExerciseDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public EquipmentDto? Equipment { get; set; }
        public CategoryDto? Category { get; set; }

        public ExerciseDto(string description, string image,
         EquipmentDto? equipment, CategoryDto? category)
        {
            Description = description;
            Image = image;
            Equipment = equipment;
            Category = category;
        }
    }
}