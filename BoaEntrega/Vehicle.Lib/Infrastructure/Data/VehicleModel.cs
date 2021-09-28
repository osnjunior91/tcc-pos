using Amazon.DynamoDBv2.DataModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Lib.Infrastructure.Data
{
    [DynamoDBTable("vehicle")]
    public class VehicleModel : ModelBase
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Capacity { get; set; }
        public Guid WharehouseLocationId { get; set; }
        public Guid? WharehouseDestinyId { get; set; }

    }
}
