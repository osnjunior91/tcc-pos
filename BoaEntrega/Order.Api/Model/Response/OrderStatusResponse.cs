using Order.Lib.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Model.Response
{
    public class OrderStatusResponse
    {
        public Guid CustomerId { get; set; }
        public DateTime? PrevisionDeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
