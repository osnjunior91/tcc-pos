using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Api.Model.Request
{
    public class WarehouseCreateRequest
    {
        public string RegisterNumber { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
        public Address Address { get; set; }
    }
}
