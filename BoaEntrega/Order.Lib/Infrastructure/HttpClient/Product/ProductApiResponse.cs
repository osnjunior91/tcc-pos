using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Lib.Infrastructure.HttpClient.Product
{
    public class ProductApiResponse
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public Guid WarehouseId { get; set; }
    }
}
