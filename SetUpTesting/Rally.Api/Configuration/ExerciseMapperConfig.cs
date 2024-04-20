using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rally.Api.Dtos.Exercise;
using Rally.Api.Models;

namespace Rally.Api.Configuration
{
    public class ExerciseMapperConfig : Profile
    {
        public ExerciseMapperConfig()
        {
            CreateMap<Exercise, ExerciseDto>()
                .ForMember(dest => dest.Equipment, opt => opt
                .MapFrom(src => src.Equipment)).ReverseMap();
            CreateMap<Exercise, ExerciseDetailsDto>()
                .ForMember(dest => dest.Equipment, opt => opt
                .MapFrom(src => src.Equipment))
                .ForMember(dest => dest.Categories, opt => opt
                .MapFrom(src => src.Categories ?? new List<Category>())).ReverseMap();
            CreateMap<Exercise, UpdateExerciseDto>().ReverseMap();
            CreateMap<Exercise, CreateExerciseDto>().ReverseMap();
        }
    }
}