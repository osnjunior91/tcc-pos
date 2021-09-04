using Amazon.DynamoDBv2.DataModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse.Lib.Infrastructure.Data
{
    [DynamoDBTable("warehouse")]
    public class WarehouseModel : ModelBase
    {
        public string RegisterNumber { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public List<PhoneModel> Phones { get; set; }
        public AddressModel Address { get; set; }
    }
}
