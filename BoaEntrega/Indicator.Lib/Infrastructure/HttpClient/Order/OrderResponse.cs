using System;
using System.Collections.Generic;
using System.Text;

namespace Indicator.Lib.Infrastructure.HttpClient.Order
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid WarehouseId { get; set; }
        public double Weight { get; set; }
        public double ShippingCost { get; set; }
        public DateTime? PrevisionDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        Separation,
        OnCarriage,
        Ready,
        Canceled
    }
}
