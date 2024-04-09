using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Rally.Application.Mapper
{
    public class RallyDtoMapper : Profile
    {
        
    }
}

// public class AspnetRunDtoMapper : Profile
// {
//     public AspnetRunDtoMapper()
//     {
//         CreateMap<Product, ProductModel>()
//             .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName)).ReverseMap();

//         CreateMap<Category, CategoryModel>().ReverseMap();
//     }
// }