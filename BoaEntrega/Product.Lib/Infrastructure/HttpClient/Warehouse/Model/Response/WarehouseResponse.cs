using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Lib.Infrastructure.HttpClient.WareHouse.Response
{
    public class WareHouseResponse
    {
        public Guid Id { get; set; }
        public string RegisterNumber { get; set; }
        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
    }
}
