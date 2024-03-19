using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Rally.Api.Models;

namespace Rally.Api.Data
{
    public class CategoryMapperConfig : Profile
    {
        public CategoryMapperConfig()
        {
            // CreateMap<Category, CreateCategoryDto>().ReverseMap();
            // CreateMap<Category, GetCategoryDto>().ReverseMap();
            // CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            // CreateMap<Category, GetCategoryDetailsDto>().ReverseMap();
            // CreateMap<Category, GetAllTracksInCategoryDto>().ReverseMap();
        }
    }
}