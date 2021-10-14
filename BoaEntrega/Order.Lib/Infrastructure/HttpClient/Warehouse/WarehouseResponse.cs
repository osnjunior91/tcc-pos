using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Order.Lib.Infrastructure.HttpClient.Warehouse
{
    public class WareHouseResponse
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("registerNumber")]
        public string RegisterNumber { get; set; }
        [JsonPropertyName("corporateName")]
        public string CorporateName { get; set; }
        [JsonPropertyName("fantasyName")]
        public string FantasyName { get; set; }
        [JsonPropertyName("address")]
        public AddressModel Address { get; set; }
    }
}
