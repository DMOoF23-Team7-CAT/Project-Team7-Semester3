using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rally.Application.Dto;
using Rally.Core.Entities;

namespace Rally.Application.Mapper
{
    public class RallyDtoMapper : Profile
    {
        public RallyDtoMapper()
        {
            CreateMap<Sign, SignDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Equipment, EquipmentDto>().ReverseMap();
            CreateMap<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<Track, TrackDto>().ReverseMap();
        }
    }
}