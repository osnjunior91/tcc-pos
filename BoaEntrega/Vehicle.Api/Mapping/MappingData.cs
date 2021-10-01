using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Api.Data.Request;
using Vehicle.Api.Data.Response;
using Vehicle.Lib.Infrastructure.Data;

namespace Vehicle.Api.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<VehicleCreateRequest, VehicleModel>()
                .ForMember(dest => dest.Id, m => m.MapFrom(x => Guid.NewGuid()))
                .ReverseMap();

            CreateMap<VehicleCreateResponse, VehicleModel>().ReverseMap();
        }
    }
}
