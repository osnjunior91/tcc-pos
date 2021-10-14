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
        public Guid UserId { get; set; }
        public Guid WarehouseId { get; set; }
        public List<ProductOrder> Products { get; set; }
        public double Weight { get; set; }
        public double? ShippingCost { get; set; }
        public int? DaysForShipping { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus {
        Placed,
        Separation,
        OnCarriage,
        Ready,
        Canceled
    }

}
