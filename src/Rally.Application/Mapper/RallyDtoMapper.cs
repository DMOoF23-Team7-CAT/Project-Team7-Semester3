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
            // TODO: Add the mapper for the Entities to DTOs and vice versa

            CreateMap<Core.Entities.Sign, Dto.Sign.SignDto>().ReverseMap();
            CreateMap<Core.Entities.Category, Dto.Category.CategoryDto>().ReverseMap();
            CreateMap<Core.Entities.Equipment, Dto.Equipment.EquipmentDto>().ReverseMap();
            CreateMap<Core.Entities.Exercise, Dto.Exercise.ExerciseDto>().ReverseMap();
            CreateMap<Core.Entities.Track, Dto.Track.TrackDto>().ReverseMap();
        }
    }
}