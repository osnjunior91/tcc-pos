using AutoMapper;
using Order.Api.Model.Request;
using Order.Lib.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<CreateOrderRequest, OrderModel>()
            .ForMember(dest => dest.Id, m => m.MapFrom(x => Guid.NewGuid()))
            .ForMember(dest => dest.Items, m => m.MapFrom(x => MapItemsId(x.Items)))
            .ReverseMap();
        }

        private List<ItemOrder> MapItemsId(List<OrderProductRequest> items)
        {
            return items.Select(x => new ItemOrder() { Id = x.Id, Amount = x.Amount }).ToList();
        }
    }
}
