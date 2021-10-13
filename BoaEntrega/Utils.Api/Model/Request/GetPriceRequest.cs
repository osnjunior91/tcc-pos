using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils.Api.Model.Request
{
    public class GetPriceRequest
    {
        public Guid UserId { get; set; }
        public Guid WarehouseId { get; set; }
        public double Weight { get; set; }
    }
}
