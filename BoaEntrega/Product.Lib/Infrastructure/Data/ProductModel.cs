using Amazon.DynamoDBv2.DataModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Lib.Infrastructure.Data

{
    [DynamoDBTable("product")]
    public class ProductModel : ModelBase
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public Guid WarehouseId { get; set; }

    }
}
