using AutoMapper;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using Utils.Api.Model.Request;

namespace Utils.Api.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<AddressRequest, AddressModel>().ReverseMap();
        }
    }
}
