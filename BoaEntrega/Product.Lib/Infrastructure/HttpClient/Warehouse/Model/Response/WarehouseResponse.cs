using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Product.Lib.Infrastructure.HttpClient.WareHouse.Response
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
    }
}
