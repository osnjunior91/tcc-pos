using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Api.Model.Request
{
    public class GetDateRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
