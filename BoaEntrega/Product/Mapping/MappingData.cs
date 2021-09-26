using AutoMapper;
using Product.Api.Model.Request;
using Product.Lib.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Api.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<ProductCreateRequest, ProductModel>()
                .ForMember(dest => dest.Id, m => m.MapFrom(x => Guid.NewGuid()))
                .ReverseMap();
        }
    }
}
