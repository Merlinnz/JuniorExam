using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<User, GetUserDto>().ReverseMap();
        CreateMap<User, AddUserDto>().ReverseMap();

        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<Product, AddProductDto>().ReverseMap();
    }
}
