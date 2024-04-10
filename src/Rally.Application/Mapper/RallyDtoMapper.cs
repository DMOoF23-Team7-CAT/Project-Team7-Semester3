using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rally.Application.Dto;
using Rally.Core;

namespace Rally.Application.Mapper
{
    public class RallyDtoMapper : Profile
    {
        public RallyDtoMapper()
        {
            // TODO: Add the mapper for extra DTOes

            // Category
            CreateMap<Core.Entities.Category, Dto.Category.CategoryDto>().ReverseMap();
            CreateMap<Core.Entities.Category, Dto.Category.CreateCategoryDto>().ReverseMap();

            // Equipment
            CreateMap<Core.Entities.Equipment, Dto.Equipment.EquipmentDto>().ReverseMap();
            CreateMap<Core.Entities.Equipment, Dto.Equipment.CreateEquipmentDto>().ReverseMap();

            // EquipmentBase
            CreateMap<Core.Entities.EquipmentBase, Dto.EquipmentBase.EquipmentBaseDto>().ReverseMap();
            CreateMap<Core.Entities.EquipmentBase, Dto.EquipmentBase.CreateEquipmentBaseDto>().ReverseMap();

            CreateMap<Core.Entities.Exercise, Dto.Exercise.ExerciseDto>().ReverseMap();
            CreateMap<Core.Entities.Exercise, Dto.Exercise.CreateExerciseDto>().ReverseMap();

            // Sign
            CreateMap<Core.Entities.Sign, Dto.Sign.SignDto>().ReverseMap();
            CreateMap<Core.Entities.Sign, Dto.Sign.CreateSignDto>().ReverseMap();

            // Track
            CreateMap<Core.Entities.Track, Dto.Track.TrackDto>().ReverseMap();
            CreateMap<Core.Entities.Track, Dto.Track.CreateTrackDto>().ReverseMap();
        }
    }
}