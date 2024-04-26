using AutoMapper;
using Rally.Application.Dto.Category;
using Rally.Application.Dto.Equipment;
using Rally.Application.Dto.EquipmentBase;
using Rally.Application.Dto.Sign;
using Rally.Application.Dto.SignBase;
using Rally.Application.Dto.Track;
using Rally.Core.Entities;

namespace Rally.Application.Mapper
{
    public class RallyDtoMapper : Profile
    {
        public RallyDtoMapper()
        {
            // Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithSignBasesDto>().ReverseMap();

            // Equipment
            CreateMap<Equipment, EquipmentDto>().ReverseMap();

            // EquipmentBase
            CreateMap<EquipmentBase, EquipmentBaseDto>().ReverseMap();

            // SignBase
            CreateMap<SignBase, SignBaseDto>().ReverseMap();

            // Sign
            CreateMap<Sign, SignDto>().ReverseMap();

            // Track
            CreateMap<Track, TrackDto>().ReverseMap();
        }
    }
}