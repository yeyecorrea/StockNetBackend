using AutoMapper;
using StockNet.Application.DTOs.Dashboard;
using StockNet.Domain.Entities;

namespace StockNet.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessDto, Negocio>();
            CreateMap<BusinessEditDto, Negocio>()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());
            CreateMap<CustomerDto, Cliente>();
            CreateMap<Negocio, BusinessDto>();
        }

    }
}
