using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Data.Request
{
    public class VehicleCreateRequest
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Capacity { get; set; }
        public Guid WharehouseLocationId { get; set; }

    }
}
