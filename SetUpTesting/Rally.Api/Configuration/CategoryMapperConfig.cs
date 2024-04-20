using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rally.Api.Dtos.Category;
using Rally.Api.Models;

namespace Rally.Api.Data
{
    public class CategoryMapperConfig : Profile
    {
        public CategoryMapperConfig()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDetailsDto>()
                .ForMember(dest => dest.Exercises, opt => opt
                .MapFrom(src => src.Exercises ?? new List<Exercise>())).ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}