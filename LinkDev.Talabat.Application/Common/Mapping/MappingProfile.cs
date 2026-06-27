using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Domain.Entities.Products;

namespace LinkDev.Talabat.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductToReturnDto>()

            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand!.Name))

            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category!.Name));

        CreateMap<ProductBrand, BrandDto>();

        CreateMap<ProductCategory, CategoryDto>();
    }
}