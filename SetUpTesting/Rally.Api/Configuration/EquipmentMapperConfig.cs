using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rally.Api.Dtos.Equipment;
using Rally.Api.Dtos.Exercise;
using Rally.Api.Models;

namespace Rally.Api.Configuration
{
    public class EquipmentMapperConfig : Profile
    {
        public EquipmentMapperConfig()
        {
            CreateMap<Equipment, EquipmentDto>().ReverseMap();
            CreateMap<Equipment, EquipmentDetailsDto>()
            .ForMember(dest => dest.Exercises, opt => opt
            .MapFrom(src => src.Exercises ?? new List<Exercise>())).ReverseMap();
            CreateMap<Equipment, UpdateEquipmentDto>().ReverseMap();
            CreateMap<Equipment, CreateEquipmentDto>().ReverseMap();
        }
    }
}