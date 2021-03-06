using Amazon.DynamoDBv2.DataModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Lib.Infrastructure.Data
{
    [DynamoDBTable("order")]
    public class OrderModel : ModelBase
    {
        public Guid CustomerId { get; set; }
        public Guid WarehouseId { get; set; }
        public List<ItemOrder> Items { get; set; }
        public double Weight { get; set; }
        public double ShippingCost { get; set; }
        public DateTime? PrevisionDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus {
        Separation,
        OnCarriage,
        Ready,
        Canceled
    }

}
