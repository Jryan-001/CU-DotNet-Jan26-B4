using AutoMapper;
using NorthwindCatalog.Services.Dtos;
using NorthwindCatalog.Services.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NorthwindCatalog.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
      .ForMember(dest => dest.ImageUrl,
          opt => opt.MapFrom(src =>
              "/images/" + src.CategoryName!
                  .Replace(" ", "_")
                  .Replace("/", "_") + ".jpeg"));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.UnitPrice,
                    opt => opt.MapFrom(src => src.UnitPrice ?? 0))
                .ForMember(dest => dest.UnitsInStock,
                    opt => opt.MapFrom(src => src.UnitsInStock ?? (short)0));
        }
    }
}