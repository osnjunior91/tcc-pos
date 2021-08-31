using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Model
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
