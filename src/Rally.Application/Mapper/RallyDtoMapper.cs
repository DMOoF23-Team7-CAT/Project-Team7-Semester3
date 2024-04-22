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
            // Category
            CreateMap<Core.Entities.Category, CategoryDto>().ReverseMap();

            // Equipment
            CreateMap<Core.Entities.Equipment, EquipmentDto>().ReverseMap();

            // EquipmentBase
            CreateMap<Core.Entities.EquipmentBase, EquipmentBaseDto>().ReverseMap();

            // SignBase
            CreateMap<Core.Entities.SignBase, SignBaseDto>().ReverseMap();

            // Sign
            CreateMap<Core.Entities.Sign, SignDto>().ReverseMap();

            // Track
            CreateMap<Core.Entities.Track, TrackDto>().ReverseMap();
        }
    }
}