using Order.Lib.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Model.Response
{
    public class OrderCreateResponse
    {
        public Guid Id { get; set; }
        public double Weight { get; set; }
        public double ShippingCost { get; set; }
        public DateTime? PrevisionDeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
