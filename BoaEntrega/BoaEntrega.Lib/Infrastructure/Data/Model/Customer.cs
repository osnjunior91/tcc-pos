using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.Lib.Infrastructure.Data.Model
{
    public class Customer : ModelBase
    {
        public string Document { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
    }
}
