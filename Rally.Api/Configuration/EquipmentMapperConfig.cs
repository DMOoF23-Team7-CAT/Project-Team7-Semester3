using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rally.Api.Models;

namespace Rally.Api.Configuration
{
    public class EquipmentMapperConfig : Profile
    {
        public EquipmentMapperConfig()
        {
            // CreateMap<Equipment, CreateEquipmentDto>().ReverseMap();
            // CreateMap<Equipment, UpdateEquipmentDto>().ReverseMap();
            // CreateMap<Equipment, GetEquipmentWithTypeDto>().ReverseMap();
        }
    }
}