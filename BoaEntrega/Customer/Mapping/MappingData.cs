using AutoMapper;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using Customer.Lib.Infrastructure.Data.Model;
using Customer.Model;
using System;

namespace Customer.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<CustomerCreateRequest, CustomerModel>()
                 .ForMember(dest => dest.Id, m => m.MapFrom(x => Guid.NewGuid()))
                 .ForMember(dest => dest.CreatedAt, m => m.MapFrom(x => DateTime.Now))
                 .ForMember(dest => dest.ModifiedAt, m => m.MapFrom(x => DateTime.Now));
            CreateMap<Address, AddressModel>().ReverseMap();
        }
    }
}
