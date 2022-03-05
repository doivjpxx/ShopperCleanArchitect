using AutoMapper;
using Shop.ApplicationCore.DTOs;
using Shop.ApplicationCore.Entities;

namespace Shop.ApplicationCore.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}