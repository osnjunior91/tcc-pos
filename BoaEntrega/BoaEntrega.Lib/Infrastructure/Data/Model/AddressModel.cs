using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.Lib.Infrastructure.Data.Model
{
    public class AddressModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }


        public override string ToString()
        {
            return $"{this.Street} {this.Number} {this.Neighborhood} {this.City} {this.State} {this.ZipCode}";
        }
    }
}
