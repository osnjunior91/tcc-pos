using System;

namespace Vehicle.Api.Data.Response
{
    public class VehicleCreateResponse
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
    }
}
