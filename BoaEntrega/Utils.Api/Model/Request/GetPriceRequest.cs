using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utils.Api.Model.Request
{
    public class GetPriceRequest
    {
        public AddressRequest From { get; set; }
        public AddressRequest To { get; set; }
        public double Weight { get; set; }
    }
}
