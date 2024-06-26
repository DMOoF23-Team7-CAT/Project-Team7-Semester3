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
            CreateMap<Equipment, EquipmentWithEquipmentBaseDto>().ReverseMap();
            CreateMap<Equipment, EquipmentWithoutIdDto>().ReverseMap();

            // EquipmentBase
            CreateMap<EquipmentBase, EquipmentBaseDto>().ReverseMap();
            CreateMap<EquipmentBase, EquipmentBaseWithoutIdDto>().ReverseMap();

            // Sign
            CreateMap<Sign, SignDto>().ReverseMap();
            CreateMap<Sign, SignWithSignBaseDto>().ReverseMap();
            CreateMap<Sign, SignWithoutIdDto>().ReverseMap();
            CreateMap<Sign, SignWithEquipmentSignBase>().ReverseMap();

            // SignBase
            CreateMap<SignBase, SignBaseDto>().ReverseMap();
            CreateMap<SignBase, SignBaseWithEquipmentBaseDto>().ReverseMap();
            CreateMap<SignBase, SignBaseWithoutIdDto>().ReverseMap();

            // Track
            CreateMap<Track, TrackDto>().ReverseMap();
            CreateMap<Track, TrackWithOutIdDto>().ReverseMap();
            CreateMap<Track, LoadTrackDto>().ReverseMap();
            CreateMap<Track, TrackWithCategoryDto>().ReverseMap();
        }
    }
}