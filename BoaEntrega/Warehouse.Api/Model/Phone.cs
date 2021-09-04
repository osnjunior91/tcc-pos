using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Api.Model
{
    public class Phone
    {
        public string Number { get; set; }
        public TypePhone Type { get; set; }
        public bool IsWhatsapp { get; set; }
    }

    public enum TypePhone
    {
        Cellphone,
        LandLine
    }
}
