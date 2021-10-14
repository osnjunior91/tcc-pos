using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Model.Request
{
    public class CreateOrderRequest
    {
        public Guid UserId { get; set; }
        public Guid WarehouseId { get; set; }
        public List<OrderProductRequest> Items { get; set; }
    }

    public class OrderProductRequest
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
    }
}
