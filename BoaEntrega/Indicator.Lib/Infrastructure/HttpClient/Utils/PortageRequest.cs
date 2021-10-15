using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicator.Lib.Infrastructure.HttpClient.Utils
{
    public class PortageRequest
    {
        public AddressModel From { get; set; }
        public AddressModel To { get; set; }
        public double Weight { get; set; }

        public PortageRequest(AddressModel from, AddressModel to, double weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}
