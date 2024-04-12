using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Category.Dto;
using Rally.Application.Dto.Base;
using Rally.Application.Dto.Category;
using Rally.Application.Dto.EquipmentBase;

namespace Rally.Application.Dto.Exercise
{
    public class ExerciseDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public EquipmentBaseDto? EquipmentBase { get; private set; }
        public CategoryDto? Category { get; private set; }

        public ExerciseDto(string description, string image,
         EquipmentBaseDto? equipmentBase, CategoryDto? category)
        {
            Description = description;
            Image = image;
            EquipmentBase = equipmentBase;
            Category = category;
        }
    }
}