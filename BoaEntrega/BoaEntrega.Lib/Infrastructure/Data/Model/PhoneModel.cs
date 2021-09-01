using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.Lib.Infrastructure.Data.Model
{
    public class PhoneModel
    {
        public string Number { get; set; }
        public TypePhone Type { get; set; }
        public bool IsWhatsapp { get; set; }
    }

    public enum TypePhone { 
        Cellphone,
        LandLine
    }
}
