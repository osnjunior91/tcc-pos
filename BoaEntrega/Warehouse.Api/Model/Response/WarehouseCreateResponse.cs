using System;

namespace Warehouse.Api.Model.Response
{
    public class WarehouseCreateResponse
    {
        public Guid Id { get; set; }
        public string RegisterNumber { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
    }
}
