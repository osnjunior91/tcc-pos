using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Api.Model.Request
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public Guid WarehouseId { get; set; }
    }
}
