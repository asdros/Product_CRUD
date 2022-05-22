using AutoMapper;
using Product_CRUD.Models.DTO;
using Product_CRUD.Models.Entities;
using System;

namespace Product_CRUD.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToDisplayDTO>()
                .ForMember(p => p.GrossPrice,
                opt => opt.MapFrom(x => 
                                    Math.Round(x.NetPrice * x.Tax.Value,2)))
                .ForMember(p=>p.NettoPrice,
                opt =>opt.MapFrom(x=>x.NetPrice));

            CreateMap<Category, CategoryToDisplayDTO>();
        }
    }
}
