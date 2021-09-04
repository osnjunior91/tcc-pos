using AutoMapper;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using Warehouse.Api.Model;
using Warehouse.Api.Model.Request;
using Warehouse.Api.Model.Response;
using Warehouse.Lib.Infrastructure.Data;

namespace Warehouse.Api.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<WarehouseCreateRequest, WarehouseModel>()
                 .ForMember(dest => dest.Id, m => m.MapFrom(x => Guid.NewGuid()))
                 .ForMember(dest => dest.CreatedAt, m => m.MapFrom(x => DateTime.Now))
                 .ForMember(dest => dest.ModifiedAt, m => m.MapFrom(x => DateTime.Now));
            CreateMap<Address, AddressModel>().ReverseMap();

            CreateMap<WarehouseCreateResponse, WarehouseModel>().ReverseMap();
        }
    }
}
