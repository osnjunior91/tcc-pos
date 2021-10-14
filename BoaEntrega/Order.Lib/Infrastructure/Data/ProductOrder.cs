using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Lib.Infrastructure.Data
{
    public class ProductOrder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
    }
}
